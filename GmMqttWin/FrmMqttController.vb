Imports MQTTnet
Imports MQTTnet.Client
Imports MQTTnet.Client.Options
Imports System.Configuration

Public Class FrmMqttController

    Private mqttClient As IMqttClient

    Private mqttServer As String
    Private mqttPort As Integer
    Private mqttUser As String
    Private mqttPass As String

    Private Sub FrmMqttController_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Διάβασμα από App.config
        mqttServer = ConfigurationManager.AppSettings("MQTT_SERVER")
        mqttPort = Integer.Parse(ConfigurationManager.AppSettings("MQTT_PORT"))
        mqttUser = ConfigurationManager.AppSettings("MQTT_USER")
        mqttPass = ConfigurationManager.AppSettings("MQTT_PASS")

        Dim factory As New MqttFactory()
        mqttClient = factory.CreateMqttClient()

        lblStatus.Text = "Status: Disconnected"
    End Sub

    Private Async Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            Dim options = New MqttClientOptionsBuilder() _
                .WithClientId("gm-controller") _
                .WithTcpServer(mqttServer, mqttPort) _
                .WithCredentials(mqttUser, mqttPass) _
                .Build()

            Await mqttClient.ConnectAsync(options)
            lblStatus.Text = "Status: Connected"
        Catch ex As Exception
            lblStatus.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Async Sub Publish(topic As String, payload As String)
        If mqttClient Is Nothing OrElse Not mqttClient.IsConnected Then Exit Sub

        Dim msg = New MqttApplicationMessageBuilder() _
            .WithTopic(topic) _
            .WithPayload(payload) _
            .Build()

        Await mqttClient.PublishAsync(msg)
    End Sub

    Private Sub btnOn_Click(sender As Object, e As EventArgs) Handles btnOn.Click
        Publish("gmiot/cmd", "ON")
        lblStatus.Text = "Status: ON"
    End Sub

    Private Sub btnOff_Click(sender As Object, e As EventArgs) Handles btnOff.Click
        Publish("gmiot/cmd", "OFF")
        lblStatus.Text = "Status: OFF"
    End Sub

    Private Sub btnBlink_Click(sender As Object, e As EventArgs) Handles btnBlink.Click
        Publish("gmiot/cmd", "BLINK")
        lblStatus.Text = "Status: BLINK"
    End Sub

    Private Sub btnMotorOn_Click(sender As Object, e As EventArgs) Handles btnMotorOn.Click
        Publish("gmiot/cmd", "MOTOR_ON")
        lblStatus.Text = "Status: MOTOR ON"
    End Sub

    Private Sub btnMotorOff_Click(sender As Object, e As EventArgs) Handles btnMotorOff.Click
        Publish("gmiot/cmd", "MOTOR_OFF")
        lblStatus.Text = "Status: MOTOR OFF"
    End Sub

End Class
