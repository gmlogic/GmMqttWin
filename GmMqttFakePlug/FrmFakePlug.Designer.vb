<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFakePlug
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
        Me.lblConn = New System.Windows.Forms.Label()
        Me.pnlLed = New System.Windows.Forms.Panel()
        Me.lblState = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(20, 20)
        Me.btnConnect.Size = New System.Drawing.Size(100, 30)
        Me.btnConnect.Text = "Connect"
        '
        'lblConn
        '
        Me.lblConn.AutoSize = True
        Me.lblConn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblConn.Location = New System.Drawing.Point(140, 26)
        Me.lblConn.Text = "Disconnected"
        '
        'pnlLed
        '
        Me.pnlLed.BackColor = System.Drawing.Color.DarkGray
        Me.pnlLed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLed.Location = New System.Drawing.Point(20, 70)
        Me.pnlLed.Size = New System.Drawing.Size(80, 80)
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblState.Location = New System.Drawing.Point(120, 95)
        Me.lblState.Text = "OFF"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.ForeColor = System.Drawing.Color.Gray
        Me.lblTitle.Location = New System.Drawing.Point(20, 170)
        Me.lblTitle.Text = "Fake Plug / Device Simulator"
        '
        'FrmFakePlug
        '
        Me.ClientSize = New System.Drawing.Size(400, 230)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblState)
        Me.Controls.Add(Me.pnlLed)
        Me.Controls.Add(Me.lblConn)
        Me.Controls.Add(Me.btnConnect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GmMqttFakePlug"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents btnConnect As Button
    Friend WithEvents lblConn As Label
    Friend WithEvents pnlLed As Panel
    Friend WithEvents lblState As Label
    Friend WithEvents lblTitle As Label
End Class
