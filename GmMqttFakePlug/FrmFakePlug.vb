Imports System.Configuration
Imports MQTTnet
Imports MQTTnet.Client
Imports MQTTnet.Client.Options
Imports System.Text

Public Class FrmFakePlug

    Private mqttClient As IMqttClient

    Private mqttServer As String
    Private mqttPort As Integer
    Private mqttUser As String
    Private mqttPass As String

    Private Const TOPIC_CMD As String = "gmiot/cmd"

    ' arrays για 16 κανάλια
    Private pnl(15) As Panel
    Private lbl(15) As Label

    Private Sub FrmFakePlug_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load

        mqttServer = ConfigurationManager.AppSettings("MQTT_SERVER")
        mqttPort = Integer.Parse(ConfigurationManager.AppSettings("MQTT_PORT"))
        mqttUser = ConfigurationManager.AppSettings("MQTT_USER")
        mqttPass = ConfigurationManager.AppSettings("MQTT_PASS")

        CreateUi()

        Dim factory As New MqttFactory()
        mqttClient = factory.CreateMqttClient()

        AddHandler mqttClient.ApplicationMessageReceivedAsync,
            Async Function(e2)
                Dim msg = Encoding.UTF8.GetString(
                    e2.ApplicationMessage.PayloadSegment.Array,
                    e2.ApplicationMessage.PayloadSegment.Offset,
                    e2.ApplicationMessage.PayloadSegment.Count
                )

                Invoke(Sub() HandleCommand(msg))
                Await Task.CompletedTask
            End Function
    End Sub

    ' ===== UI CREATION (runtime, ασφαλές) =====
    Private Sub CreateUi()

        For i As Integer = 0 To 15

            pnl(i) = New Panel()
            pnl(i).Size = New Size(60, 60)
            pnl(i).BackColor = Color.DarkGray

            lbl(i) = New Label()
            lbl(i).Size = New Size(80, 30)
            lbl(i).TextAlign = ContentAlignment.MiddleCenter
            lbl(i).Text = $"CH{i}" & vbCrLf & "0°"

            Dim col = i Mod 4
            Dim row = i \ 4

            pnl(i).Location = New Point(20 + col * 190, 70 + row * 100)
            lbl(i).Location = New Point(90 + col * 190, 75 + row * 100)

            Me.Controls.Add(pnl(i))
            Me.Controls.Add(lbl(i))
        Next

    End Sub

    Private Async Sub btnConnect_Click(sender As Object, e As EventArgs) _
        Handles btnConnect.Click

        Dim options = New MqttClientOptionsBuilder().
            WithClientId("fake-pca9685").
            WithTcpServer(mqttServer, mqttPort).
            WithCredentials(mqttUser, mqttPass).
            Build()

        Await mqttClient.ConnectAsync(options)
        Await mqttClient.SubscribeAsync(TOPIC_CMD)

        lblConn.Text = "Connected"
    End Sub

    ' ===== MQTT COMMAND =====
    Private Sub HandleCommand(cmd As String)

        If Not cmd.StartsWith("SERVO:") Then Return

        Dim parts = cmd.Split(":"c)
        If parts.Length <> 3 Then Return

        Dim ch = Integer.Parse(parts(1))
        Dim pwm = Integer.Parse(parts(2))

        If ch < 0 OrElse ch > 15 Then Return

        pwm = Math.Max(0, Math.Min(4095, pwm))

        Dim angle = CInt((pwm / 4095.0) * 180)

        lbl(ch).Text = $"CH{ch}" & vbCrLf & $"{angle}°"

        pnl(ch).BackColor = Color.FromArgb(
            255,
            Math.Min(255, angle * 2),
            Math.Max(0, 255 - angle * 2),
            100
        )

    End Sub

End Class
