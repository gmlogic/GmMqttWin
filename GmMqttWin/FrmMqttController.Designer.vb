<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMqttController
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnConnect = New Button()
        Me.lblStatus = New Label()
        Me.SuspendLayout()
        '
        'btnConnect
        '
        Me.btnConnect.Location = New Point(20, 20)
        Me.btnConnect.Size = New Size(200, 30)
        Me.btnConnect.Text = "Connect"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New Point(240, 26)
        Me.lblStatus.Size = New Size(300, 20)
        Me.lblStatus.Text = "Status: Disconnected"
        '
        'FrmMqttController
        '
        Me.ClientSize = New Size(800, 500)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.lblStatus)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "MQTT PCA9685 Multi-Channel Controller"
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents btnConnect As Button
    Friend WithEvents lblStatus As Label
End Class
