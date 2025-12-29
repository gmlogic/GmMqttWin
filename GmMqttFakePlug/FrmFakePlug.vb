Imports MQTTnet
Imports MQTTnet.Client
Imports MQTTnet.Protocol
Imports System.Text

Public Class FrmFakePlug

    Private mqttClient As IMqttClient
    Private blinkTimer As New Timer()

    ' ===== MQTT SETTINGS =====
    Private Const MQTT_SERVER As String = "mqtt.gmiot.eu"
    Private Const MQTT_PORT As Integer = 1884
    Private Const MQTT_USER As String = "iotuser"
    Private Const MQTT_PASS As String = "0mgergm++"
    Private Const TOPIC_CMD As String = "gmiot/cmd"
    Private Const TOPIC_STATUS As String = "gmiot/status"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlLed.BackColor = Color.DarkGray
        lblState.Text = "OFF"
        lblConn.Text = "Disconnected"

        blinkTimer.Interval = 500
        AddHandler blinkTimer.Tick, AddressOf BlinkTick

        Dim factory As New MqttFactory()
        mqttClient = factory.CreateMqttClient()

        ' ✅ MQTTnet 2.x EVENT
        AddHandler mqttClient.ApplicationMessageReceivedAsync,
            Async Function(e2)
                Dim msg = Encoding.UTF8.GetString(e2.ApplicationMessage.Payload)
                Invoke(Sub() HandleCommand(msg))
                Await Task.CompletedTask
            End Function
    End Sub

    ' ===== CONNECT =====
    Private Async Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            Dim options = New MqttClientOptionsBuilder().
                WithTcpServer(MQTT_SERVER, MQTT_PORT).
                WithCredentials(MQTT_USER, MQTT_PASS).
                WithClientId("fakeplug-1").
                Build()

            Await mqttClient.ConnectAsync(options)
            Await mqttClient.SubscribeAsync(TOPIC_CMD)

            lblConn.Text = "Connected"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MQTT error")
        End Try
    End Sub

    ' ===== COMMAND HANDLER =====
    Private Sub HandleCommand(cmd As String)
        Select Case cmd

            Case "ON"
                blinkTimer.Stop()
                pnlLed.BackColor = Color.LimeGreen
                lblState.Text = "ON"
                PublishStatus("ON")

            Case "OFF"
                blinkTimer.Stop()
                pnlLed.BackColor = Color.DarkGray
                lblState.Text = "OFF"
                PublishStatus("OFF")

            Case "BLINK"
                blinkTimer.Start()
                lblState.Text = "BLINK"

            Case "MOTOR:START"
                blinkTimer.Stop()
                pnlLed.BackColor = Color.Orange
                lblState.Text = "MOTOR RUNNING"
                PublishStatus("MOTOR RUNNING")

            Case "MOTOR:STOP"
                blinkTimer.Stop()
                pnlLed.BackColor = Color.DarkGray
                lblState.Text = "MOTOR STOPPED"
                PublishStatus("MOTOR STOPPED")

        End Select
    End Sub

    ' ===== BLINK =====
    Private Sub BlinkTick(sender As Object, e As EventArgs)
        If pnlLed.BackColor = Color.DarkGray Then
            pnlLed.BackColor = Color.LimeGreen
        Else
            pnlLed.BackColor = Color.DarkGray
        End If
    End Sub

    ' ===== STATUS PUBLISH =====
    Private Async Sub PublishStatus(text As String)
        If Not mqttClient.IsConnected Then Return

        Dim msg = New MqttApplicationMessageBuilder().
            WithTopic(TOPIC_STATUS).
            WithPayload(text).
            WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtMostOnce).
            Build()

        Await mqttClient.PublishAsync(msg)
    End Sub

End Class
