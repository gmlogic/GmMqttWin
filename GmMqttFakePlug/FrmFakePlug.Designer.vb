<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFakePlug
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnConnect = New Button()
        Me.lblConn = New Label()
        Me.SuspendLayout()
        '
        'btnConnect
        '
        Me.btnConnect.Location = New Point(20, 20)
        Me.btnConnect.Size = New Size(150, 30)
        Me.btnConnect.Text = "Connect"
        '
        'lblConn
        '
        Me.lblConn.Location = New Point(190, 26)
        Me.lblConn.Size = New Size(200, 20)
        Me.lblConn.Text = "Disconnected"
        '
        'FrmFakePlug
        '
        Me.ClientSize = New Size(820, 520)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.lblConn)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Fake PCA9685 – 16ch Servo Simulator"
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents btnConnect As Button
    Friend WithEvents lblConn As Label
End Class
