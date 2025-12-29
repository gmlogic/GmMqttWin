Imports System.Configuration
Imports MQTTnet
Imports MQTTnet.Client
Imports MQTTnet.Protocol
Imports System.Text

Public Class FrmFakePlug

    Private mqttClient As IMqttClient
    Private blinkTimer As New Timer()

    ' MQTT from App.config
    Private mqttServer As String
    Private mqttPort As Integer
    Private mqttUser As String
    Private mqttPass As String

    Private Const TOPIC_CMD As String = "gmiot/cmd"
    Private Const TOPIC_STATUS As String = "gmiot/status"

    ' ===== FORM LOAD =====
    Private Sub FrmFakePlug_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Read App.config
        mqttServer = ConfigurationManager.AppSettings("MQTT_SERVER")
        mqttPort = Integer.Parse(ConfigurationManager.AppSettings("MQTT_PORT"))
        mqttUser = ConfigurationManager.AppSettings("MQTT_USER")
        mqttPass = ConfigurationManager.AppSettings("MQTT_PASS")

        ' UI init
        pnlLed.BackColor = Color.DarkGray
        lblState.Text = "OFF"
        lblConn.Text = "Disconnected"

        ' Blink timer
        blinkTimer.Interval = 500
        AddHandler blinkTimer.Tick, AddressOf BlinkTick

        ' MQTT client
        Dim factory As New MqttFactory()
        mqttClient = factory.CreateMqttClient()

        ' MQTT receive (2.x / 3.x safe)
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
                WithClientId("fakeplug-1").
                WithTcpServer(mqttServer, mqttPort).
                WithCredentials(mqttUser, mqttPass).
                Build()

            Await mqttClient.ConnectAsync(options)
            Await mqttClient.SubscribeAsync(TOPIC_CMD)

            lblConn.Text = "Connected"
        Catch ex As Exception
            lblConn.Text = "Error: " & ex.Message
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

            Case "MOTOR_ON"
                blinkTimer.Stop()
                pnlLed.BackColor = Color.Orange
                lblState.Text = "MOTOR RUNNING"
                PublishStatus("MOTOR RUNNING")

            Case "MOTOR_OFF"
                blinkTimer.Stop()
                pnlLed.BackColor = Color.DarkGray
                lblState.Text = "MOTOR STOPPED"
                PublishStatus("MOTOR STOPPED")

        End Select
    End Sub

    ' ===== BLINK TIMER =====
    Private Sub BlinkTick(sender As Object, e As EventArgs)
        If pnlLed.BackColor = Color.DarkGray Then
            pnlLed.BackColor = Color.LimeGreen
        Else
            pnlLed.BackColor = Color.DarkGray
        End If
    End Sub

    ' ===== STATUS PUBLISH =====
    Private Async Sub PublishStatus(text As String)
        If mqttClient Is Nothing OrElse Not mqttClient.IsConnected Then Exit Sub

        Dim msg = New MqttApplicationMessageBuilder().
            WithTopic(TOPIC_STATUS).
            WithPayload(text).
            WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtMostOnce).
            Build()

        Await mqttClient.PublishAsync(msg)
    End Sub

End Class
