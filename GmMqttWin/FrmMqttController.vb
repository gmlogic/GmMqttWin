Imports System.Configuration
Imports MQTTnet
Imports MQTTnet.Client
Imports MQTTnet.Client.Options

Public Class FrmMqttController

    Private mqttClient As IMqttClient

    Private mqttServer As String
    Private mqttPort As Integer
    Private mqttUser As String
    Private mqttPass As String

    Private Const TOPIC_CMD As String = "gmiot/cmd"

    Private Sub FrmMqttController_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load

        mqttServer = ConfigurationManager.AppSettings("MQTT_SERVER")
        mqttPort = Integer.Parse(ConfigurationManager.AppSettings("MQTT_PORT"))
        mqttUser = ConfigurationManager.AppSettings("MQTT_USER")
        mqttPass = ConfigurationManager.AppSettings("MQTT_PASS")

        Dim factory As New MqttFactory()
        mqttClient = factory.CreateMqttClient()

        CreateServoControls()
    End Sub

    ' ===== CREATE 16 PCA9685 CHANNELS =====
    Private Sub CreateServoControls()

        For i As Integer = 0 To 15

            Dim trk As New TrackBar()
            trk.Name = $"trk{i}"
            trk.Minimum = 0
            trk.Maximum = 4095
            trk.TickFrequency = 256
            trk.Size = New Size(150, 45)

            Dim lbl As New Label()
            lbl.Name = $"lbl{i}"
            lbl.Size = New Size(150, 20)
            lbl.Text = $"CH{i}: 0°"

            Dim col = i Mod 4
            Dim row = i \ 4

            trk.Location = New Point(20 + col * 180, 70 + row * 90)
            lbl.Location = New Point(20 + col * 180, 115 + row * 90)

            AddHandler trk.Scroll, AddressOf ServoScroll

            Me.Controls.Add(trk)
            Me.Controls.Add(lbl)
        Next

    End Sub

    Private Async Sub btnConnect_Click(sender As Object, e As EventArgs) _
        Handles btnConnect.Click

        Dim options = New MqttClientOptionsBuilder().
            WithClientId("gm-pca9685-controller").
            WithTcpServer(mqttServer, mqttPort).
            WithCredentials(mqttUser, mqttPass).
            Build()

        Await mqttClient.ConnectAsync(options)
        lblStatus.Text = "Status: Connected"
    End Sub

    ' ===== SLIDER HANDLER =====
    Private Async Sub ServoScroll(sender As Object, e As EventArgs)

        If mqttClient Is Nothing OrElse Not mqttClient.IsConnected Then Exit Sub

        Dim trk = CType(sender, TrackBar)
        Dim ch As Integer = Integer.Parse(trk.Name.Replace("trk", ""))
        Dim pwm As Integer = trk.Value

        Dim angle As Integer = CInt((pwm / 4095.0) * 180)
        Dim lbl = CType(Me.Controls($"lbl{ch}"), Label)
        lbl.Text = $"CH{ch}: {angle}°"

        Dim cmd = $"SERVO:{ch}:{pwm}"

        Dim msg = New MqttApplicationMessageBuilder().
            WithTopic(TOPIC_CMD).
            WithPayload(cmd).
            Build()

        Await mqttClient.PublishAsync(msg)
    End Sub

End Class
