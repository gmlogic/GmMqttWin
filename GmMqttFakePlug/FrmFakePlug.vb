Imports System.Configuration
Imports MQTTnet
Imports MQTTnet.Client
Imports MQTTnet.Client.Options
Imports MQTTnet.Protocol
Imports System.Text

Public Class FrmFakePlug

    Private mqttClient As IMqttClient
    Private blinkTimer As New Timer()

    Private mqttServer As String
    Private mqttPort As Integer
    Private mqttUser As String
    Private mqttPass As String

    Private Const TOPIC_CMD As String = "gmiot/cmd"
    Private Const TOPIC_STATUS As String = "gmiot/status"

    Private Sub FrmFakePlug_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mqttServer = ConfigurationManager.AppSettings("MQTT_SERVER")
        mqttPort = Integer.Parse(ConfigurationManager.AppSettings("MQTT_PORT"))
        mqttUser = ConfigurationManager.AppSettings("MQTT_USER")
        mqttPass = ConfigurationManager.AppSettings("MQTT_PASS")

        pnlLed.BackColor = Color.DarkGray
        lblState.Text = "OFF"
        lblConn.Text = "Disconnected"

        blinkTimer.Interval = 500
        AddHandler blinkTimer.Tick, AddressOf BlinkTick

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

    Private Async Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Dim options = New MqttClientOptionsBuilder().
            WithClientId("fakeplug-1").
            WithTcpServer(mqttServer, mqttPort).
            WithCredentials(mqttUser, mqttPass).
            Build()

        Await mqttClient.ConnectAsync(options)
        Await mqttClient.SubscribeAsync(TOPIC_CMD)

        lblConn.Text = "Connected"
    End Sub

    ' ===== COMMAND HANDLER =====
    Private Sub HandleCommand(cmd As String)

        ' -------- SPEED SIMULATION --------
        If cmd.StartsWith("SPEED:") Then
            blinkTimer.Stop()

            Dim speed As Integer = Integer.Parse(cmd.Split(":"c)(1))

            lblState.Text = $"SPEED {speed}%"

            ' Χρώμα ανάλογα με ταχύτητα
            pnlLed.BackColor = Color.FromArgb(
                255,
                Math.Min(255, speed * 2),
                Math.Max(0, 255 - speed * 2),
                0
            )

            Return
        End If

        Select Case cmd
            Case "ON"
                blinkTimer.Stop()
                pnlLed.BackColor = Color.LimeGreen
                lblState.Text = "ON"

            Case "OFF"
                blinkTimer.Stop()
                pnlLed.BackColor = Color.DarkGray
                lblState.Text = "OFF"

            Case "BLINK"
                blinkTimer.Start()
                lblState.Text = "BLINK"

            Case "MOTOR_ON"
                blinkTimer.Stop()
                pnlLed.BackColor = Color.Orange
                lblState.Text = "MOTOR RUNNING"

            Case "MOTOR_OFF"
                blinkTimer.Stop()
                pnlLed.BackColor = Color.DarkGray
                lblState.Text = "MOTOR STOPPED"
        End Select
    End Sub

    Private Sub BlinkTick(sender As Object, e As EventArgs)
        pnlLed.BackColor =
            If(pnlLed.BackColor = Color.DarkGray, Color.LimeGreen, Color.DarkGray)
    End Sub

End Class
