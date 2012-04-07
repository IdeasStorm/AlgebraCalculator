<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VMatrix
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VMatrix))
        Me.Lbrac = New System.Windows.Forms.PictureBox
        Me.Rbrac = New System.Windows.Forms.PictureBox
        Me.cmsProps = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MakeZToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InsertBeforeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MatrixToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.AdjToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.FunctionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GetRankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GetDetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MakeOneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MakeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PowerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.Lbrac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rbrac, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsProps.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbrac
        '
        Me.Lbrac.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbrac.Image = CType(resources.GetObject("Lbrac.Image"), System.Drawing.Image)
        Me.Lbrac.Location = New System.Drawing.Point(0, 0)
        Me.Lbrac.Name = "Lbrac"
        Me.Lbrac.Size = New System.Drawing.Size(18, 232)
        Me.Lbrac.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Lbrac.TabIndex = 0
        Me.Lbrac.TabStop = False
        '
        'Rbrac
        '
        Me.Rbrac.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rbrac.Image = CType(resources.GetObject("Rbrac.Image"), System.Drawing.Image)
        Me.Rbrac.Location = New System.Drawing.Point(280, 0)
        Me.Rbrac.Name = "Rbrac"
        Me.Rbrac.Size = New System.Drawing.Size(18, 232)
        Me.Rbrac.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Rbrac.TabIndex = 1
        Me.Rbrac.TabStop = False
        '
        'cmsProps
        '
        Me.cmsProps.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MakeZToolStripMenuItem, Me.InsertBeforeToolStripMenuItem, Me.FunctionsToolStripMenuItem, Me.MakeOneToolStripMenuItem, Me.MakeToolStripMenuItem})
        Me.cmsProps.Name = "cmsProps"
        Me.cmsProps.Size = New System.Drawing.Size(153, 136)
        '
        'MakeZToolStripMenuItem
        '
        Me.MakeZToolStripMenuItem.Name = "MakeZToolStripMenuItem"
        Me.MakeZToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MakeZToolStripMenuItem.Text = "Make Zero"
        '
        'InsertBeforeToolStripMenuItem
        '
        Me.InsertBeforeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MatrixToolStripMenuItem, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.AdjToolStripMenuItem1, Me.NumberToolStripMenuItem, Me.PowerToolStripMenuItem})
        Me.InsertBeforeToolStripMenuItem.Name = "InsertBeforeToolStripMenuItem"
        Me.InsertBeforeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.InsertBeforeToolStripMenuItem.Text = "Insert before"
        '
        'MatrixToolStripMenuItem
        '
        Me.MatrixToolStripMenuItem.Name = "MatrixToolStripMenuItem"
        Me.MatrixToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MatrixToolStripMenuItem.Text = "Matrix"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem2.Text = "+"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem3.Text = "-"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem4.Text = "*"
        '
        'AdjToolStripMenuItem1
        '
        Me.AdjToolStripMenuItem1.Name = "AdjToolStripMenuItem1"
        Me.AdjToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.AdjToolStripMenuItem1.Text = "Adj"
        '
        'FunctionsToolStripMenuItem
        '
        Me.FunctionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GetRankToolStripMenuItem, Me.GetDetToolStripMenuItem})
        Me.FunctionsToolStripMenuItem.Name = "FunctionsToolStripMenuItem"
        Me.FunctionsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FunctionsToolStripMenuItem.Text = "Functions"
        '
        'GetRankToolStripMenuItem
        '
        Me.GetRankToolStripMenuItem.Name = "GetRankToolStripMenuItem"
        Me.GetRankToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.GetRankToolStripMenuItem.Text = "Get Rank"
        '
        'GetDetToolStripMenuItem
        '
        Me.GetDetToolStripMenuItem.Name = "GetDetToolStripMenuItem"
        Me.GetDetToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.GetDetToolStripMenuItem.Text = "Get Det"
        '
        'MakeOneToolStripMenuItem
        '
        Me.MakeOneToolStripMenuItem.Name = "MakeOneToolStripMenuItem"
        Me.MakeOneToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MakeOneToolStripMenuItem.Text = "Make One"
        '
        'MakeToolStripMenuItem
        '
        Me.MakeToolStripMenuItem.Name = "MakeToolStripMenuItem"
        Me.MakeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MakeToolStripMenuItem.Text = "Make numerical"
        '
        'NumberToolStripMenuItem
        '
        Me.NumberToolStripMenuItem.Name = "NumberToolStripMenuItem"
        Me.NumberToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NumberToolStripMenuItem.Text = "Number"
        '
        'PowerToolStripMenuItem
        '
        Me.PowerToolStripMenuItem.Name = "PowerToolStripMenuItem"
        Me.PowerToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PowerToolStripMenuItem.Text = "Power"
        '
        'VMatrix
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ContextMenuStrip = Me.cmsProps
        Me.Controls.Add(Me.Lbrac)
        Me.Controls.Add(Me.Rbrac)
        Me.Name = "VMatrix"
        Me.Size = New System.Drawing.Size(298, 232)
        CType(Me.Lbrac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rbrac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsProps.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lbrac As System.Windows.Forms.PictureBox
    Friend WithEvents Rbrac As System.Windows.Forms.PictureBox
    Friend WithEvents cmsProps As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MakeZToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertBeforeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MatrixToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FunctionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GetRankToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GetDetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdjToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MakeOneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MakeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NumberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PowerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
