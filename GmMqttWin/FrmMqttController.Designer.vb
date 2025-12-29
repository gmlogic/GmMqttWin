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
        Me.btnMotorOn = New System.Windows.Forms.Button()
        Me.btnMotorOff = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(40, 20)
        Me.btnConnect.Size = New System.Drawing.Size(180, 30)
        Me.btnConnect.Text = "Connect"
        '
        'btnOn
        '
        Me.btnOn.Location = New System.Drawing.Point(40, 65)
        Me.btnOn.Size = New System.Drawing.Size(80, 30)
        Me.btnOn.Text = "ON"
        '
        'btnOff
        '
        Me.btnOff.Location = New System.Drawing.Point(140, 65)
        Me.btnOff.Size = New System.Drawing.Size(80, 30)
        Me.btnOff.Text = "OFF"
        '
        'btnBlink
        '
        Me.btnBlink.Location = New System.Drawing.Point(40, 105)
        Me.btnBlink.Size = New System.Drawing.Size(180, 30)
        Me.btnBlink.Text = "BLINK"
        '
        'btnMotorOn
        '
        Me.btnMotorOn.Location = New System.Drawing.Point(40, 145)
        Me.btnMotorOn.Size = New System.Drawing.Size(80, 30)
        Me.btnMotorOn.Text = "MOTOR ON"
        '
        'btnMotorOff
        '
        Me.btnMotorOff.Location = New System.Drawing.Point(140, 145)
        Me.btnMotorOff.Size = New System.Drawing.Size(80, 30)
        Me.btnMotorOff.Text = "MOTOR OFF"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(40, 190)
        Me.lblStatus.Size = New System.Drawing.Size(200, 23)
        Me.lblStatus.Text = "Status: Disconnected"
        '
        'FrmMqttController
        '
        Me.ClientSize = New System.Drawing.Size(260, 230)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.btnOn)
        Me.Controls.Add(Me.btnOff)
        Me.Controls.Add(Me.btnBlink)
        Me.Controls.Add(Me.btnMotorOn)
        Me.Controls.Add(Me.btnMotorOff)
        Me.Controls.Add(Me.lblStatus)
        Me.Text = "MQTT Controller"
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents btnConnect As Button
    Friend WithEvents btnOn As Button
    Friend WithEvents btnOff As Button
    Friend WithEvents btnBlink As Button
    Friend WithEvents btnMotorOn As Button
    Friend WithEvents btnMotorOff As Button
    Friend WithEvents lblStatus As Label
End Class
