<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMqttController
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnOn = New System.Windows.Forms.Button()
        Me.btnOff = New System.Windows.Forms.Button()
        Me.btnBlink = New System.Windows.Forms.Button()
        Me.trackSpeed = New System.Windows.Forms.TrackBar()
        Me.lblSpeed = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        CType(Me.trackSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(20, 20)
        Me.btnConnect.Size = New System.Drawing.Size(180, 30)
        Me.btnConnect.Text = "Connect"
        '
        'btnOn
        '
        Me.btnOn.Location = New System.Drawing.Point(20, 65)
        Me.btnOn.Size = New System.Drawing.Size(80, 30)
        Me.btnOn.Text = "ON"
        '
        'btnOff
        '
        Me.btnOff.Location = New System.Drawing.Point(120, 65)
        Me.btnOff.Size = New System.Drawing.Size(80, 30)
        Me.btnOff.Text = "OFF"
        '
        'btnBlink
        '
        Me.btnBlink.Location = New System.Drawing.Point(20, 105)
        Me.btnBlink.Size = New System.Drawing.Size(180, 30)
        Me.btnBlink.Text = "BLINK"
        '
        'trackSpeed
        '
        Me.trackSpeed.Location = New System.Drawing.Point(20, 150)
        Me.trackSpeed.Minimum = 0
        Me.trackSpeed.Maximum = 100
        Me.trackSpeed.TickFrequency = 10
        Me.trackSpeed.Value = 0
        Me.trackSpeed.Size = New System.Drawing.Size(180, 45)
        '
        'lblSpeed
        '
        Me.lblSpeed.Location = New System.Drawing.Point(20, 190)
        Me.lblSpeed.Size = New System.Drawing.Size(180, 20)
        Me.lblSpeed.Text = "Speed: 0%"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(20, 215)
        Me.lblStatus.Size = New System.Drawing.Size(180, 20)
        Me.lblStatus.Text = "Status: Disconnected"
        '
        'FrmMqttController
        '
        Me.ClientSize = New System.Drawing.Size(220, 260)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.btnOn)
        Me.Controls.Add(Me.btnOff)
        Me.Controls.Add(Me.btnBlink)
        Me.Controls.Add(Me.trackSpeed)
        Me.Controls.Add(Me.lblSpeed)
        Me.Controls.Add(Me.lblStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MQTT Controller"
        CType(Me.trackSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents btnConnect As Button
    Friend WithEvents btnOn As Button
    Friend WithEvents btnOff As Button
    Friend WithEvents btnBlink As Button
    Friend WithEvents trackSpeed As TrackBar
    Friend WithEvents lblSpeed As Label
    Friend WithEvents lblStatus As Label

End Class
