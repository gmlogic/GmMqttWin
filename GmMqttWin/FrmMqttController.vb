Imports System.Configuration
Imports MQTTnet
Imports MQTTnet.Client
Imports MQTTnet.Client.Options

Public Class FrmMqttController

    Private mqttClient As IMqttClient

    Private Sub FrmMqttController_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load

        Dim factory As New MqttFactory()
        mqttClient = factory.CreateMqttClient()
    End Sub

    Private Async Sub btnConnect_Click(sender As Object, e As EventArgs) _
        Handles btnConnect.Click

        Dim server = ConfigurationManager.AppSettings("MQTT_SERVER")
        Dim port = Integer.Parse(ConfigurationManager.AppSettings("MQTT_PORT"))
        Dim user = ConfigurationManager.AppSettings("MQTT_USER")
        Dim pass = ConfigurationManager.AppSettings("MQTT_PASS")

        Dim options = New MqttClientOptionsBuilder().
            WithClientId("gm-controller").
            WithTcpServer(server, port).
            WithCredentials(user, pass).
            Build()

        Await mqttClient.ConnectAsync(options)
        lblStatus.Text = "Status: Connected"
    End Sub

    Private Async Sub Publish(cmd As String)
        If mqttClient Is Nothing OrElse Not mqttClient.IsConnected Then Exit Sub

        Dim msg = New MqttApplicationMessageBuilder().
            WithTopic("gmiot/cmd").
            WithPayload(cmd).
            Build()

        Await mqttClient.PublishAsync(msg)
    End Sub

    Private Sub btnOn_Click(sender As Object, e As EventArgs) _
        Handles btnOn.Click
        Publish("ON")
    End Sub

    Private Sub btnOff_Click(sender As Object, e As EventArgs) _
        Handles btnOff.Click
        Publish("OFF")
    End Sub

    Private Sub btnBlink_Click(sender As Object, e As EventArgs) _
        Handles btnBlink.Click
        Publish("BLINK")
    End Sub

    Private Sub trackSpeed_Scroll(sender As Object, e As EventArgs) _
        Handles trackSpeed.Scroll

        lblSpeed.Text = $"Speed: {trackSpeed.Value}%"
        Publish($"SPEED:{trackSpeed.Value}")
    End Sub

End Class
