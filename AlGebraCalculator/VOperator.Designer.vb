<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VOperator
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.MatrixToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.AdjToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "+"
        '
        'MatrixToolStripMenuItem
        '
        Me.MatrixToolStripMenuItem.Name = "MatrixToolStripMenuItem"
        Me.MatrixToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
        Me.MatrixToolStripMenuItem.Text = "Matrix"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(104, 22)
        Me.ToolStripMenuItem2.Text = "+"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(104, 22)
        Me.ToolStripMenuItem3.Text = "-"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(104, 22)
        Me.ToolStripMenuItem4.Text = "*"
        '
        'AdjToolStripMenuItem1
        '
        Me.AdjToolStripMenuItem1.Name = "AdjToolStripMenuItem1"
        Me.AdjToolStripMenuItem1.Size = New System.Drawing.Size(104, 22)
        Me.AdjToolStripMenuItem1.Text = "Adj"
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
        'VOperator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ContextMenuStrip = Me.cms
        Me.Controls.Add(Me.Label1)
        Me.Name = "VOperator"
        Me.Size = New System.Drawing.Size(44, 118)
        Me.cms.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MatrixToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdjToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
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
