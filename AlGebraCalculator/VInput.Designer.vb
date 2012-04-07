<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VInput
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.txtInput = New System.Windows.Forms.TextBox
        Me.cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MatrixToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.OperatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem
        Me.AdjToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NumbersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PowerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cms.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(3, 51)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(28, 20)
        Me.txtInput.TabIndex = 0
        Me.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cms
        '
        Me.cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MatrixToolStripMenuItem1, Me.OperatorToolStripMenuItem, Me.NumbersToolStripMenuItem})
        Me.cms.Name = "cms"
        Me.cms.Size = New System.Drawing.Size(119, 70)
        '
        'MatrixToolStripMenuItem1
        '
        Me.MatrixToolStripMenuItem1.Name = "MatrixToolStripMenuItem1"
        Me.MatrixToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.MatrixToolStripMenuItem1.Text = "Matrix"
        '
        'OperatorToolStripMenuItem
        '
        Me.OperatorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.AdjToolStripMenuItem})
        Me.OperatorToolStripMenuItem.Name = "OperatorToolStripMenuItem"
        Me.OperatorToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OperatorToolStripMenuItem.Text = "Operator"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem5.Text = "+"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem6.Text = "-"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem7.Text = "*"
        '
        'AdjToolStripMenuItem
        '
        Me.AdjToolStripMenuItem.Name = "AdjToolStripMenuItem"
        Me.AdjToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AdjToolStripMenuItem.Text = "Adj"
        '
        'NumbersToolStripMenuItem
        '
        Me.NumbersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PowerToolStripMenuItem, Me.NumberToolStripMenuItem})
        Me.NumbersToolStripMenuItem.Name = "NumbersToolStripMenuItem"
        Me.NumbersToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NumbersToolStripMenuItem.Text = "Numbers"
        '
        'PowerToolStripMenuItem
        '
        Me.PowerToolStripMenuItem.Name = "PowerToolStripMenuItem"
        Me.PowerToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PowerToolStripMenuItem.Text = "Power"
        '
        'NumberToolStripMenuItem
        '
        Me.NumberToolStripMenuItem.Name = "NumberToolStripMenuItem"
        Me.NumberToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NumberToolStripMenuItem.Text = "Number"
        '
        'VInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.cms
        Me.Controls.Add(Me.txtInput)
        Me.Name = "VInput"
        Me.Size = New System.Drawing.Size(34, 118)
        Me.cms.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MatrixToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdjToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NumbersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PowerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NumberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
