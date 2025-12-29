<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFakePlug
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
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
        Me.btnConnect.Location = New System.Drawing.Point(17, 17)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(86, 26)
        Me.btnConnect.TabIndex = 0
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'lblConn
        '
        Me.lblConn.AutoSize = True
        Me.lblConn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblConn.Location = New System.Drawing.Point(120, 23)
        Me.lblConn.Name = "lblConn"
        Me.lblConn.Size = New System.Drawing.Size(83, 15)
        Me.lblConn.TabIndex = 1
        Me.lblConn.Text = "Disconnected"
        '
        'pnlLed
        '
        Me.pnlLed.BackColor = System.Drawing.Color.DarkGray
        Me.pnlLed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLed.Location = New System.Drawing.Point(17, 61)
        Me.pnlLed.Name = "pnlLed"
        Me.pnlLed.Size = New System.Drawing.Size(69, 70)
        Me.pnlLed.TabIndex = 2
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblState.Location = New System.Drawing.Point(103, 82)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(38, 21)
        Me.lblState.TabIndex = 3
        Me.lblState.Text = "OFF"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.ForeColor = System.Drawing.Color.Gray
        Me.lblTitle.Location = New System.Drawing.Point(17, 147)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(146, 13)
        Me.lblTitle.TabIndex = 4
        Me.lblTitle.Text = "Fake Plug / Device Simulator"
        '
        'FrmFakePlug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 199)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblState)
        Me.Controls.Add(Me.pnlLed)
        Me.Controls.Add(Me.lblConn)
        Me.Controls.Add(Me.btnConnect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmFakePlug"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fake Plug / Device Simulator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnConnect As Button
    Friend WithEvents lblConn As Label
    Friend WithEvents pnlLed As Panel
    Friend WithEvents lblState As Label
    Friend WithEvents lblTitle As Label

End Class
