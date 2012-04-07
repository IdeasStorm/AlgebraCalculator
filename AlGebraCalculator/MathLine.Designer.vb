<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MathLine
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
        Me.SymFlow = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlres = New System.Windows.Forms.TableLayoutPanel
        Me.SuspendLayout()
        '
        'SymFlow
        '
        Me.SymFlow.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SymFlow.BackColor = System.Drawing.SystemColors.Window
        Me.SymFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SymFlow.Location = New System.Drawing.Point(3, 3)
        Me.SymFlow.Name = "SymFlow"
        Me.SymFlow.Size = New System.Drawing.Size(478, 144)
        Me.SymFlow.TabIndex = 0
        Me.SymFlow.WrapContents = False
        '
        'pnlres
        '
        Me.pnlres.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlres.AutoSize = True
        Me.pnlres.BackColor = System.Drawing.Color.White
        Me.pnlres.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.pnlres.ColumnCount = 1
        Me.pnlres.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlres.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlres.Location = New System.Drawing.Point(487, 5)
        Me.pnlres.Name = "pnlres"
        Me.pnlres.RowCount = 1
        Me.pnlres.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlres.Size = New System.Drawing.Size(149, 140)
        Me.pnlres.TabIndex = 3
        '
        'MathLine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnlres)
        Me.Controls.Add(Me.SymFlow)
        Me.Name = "MathLine"
        Me.Size = New System.Drawing.Size(639, 150)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SymFlow As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlres As System.Windows.Forms.TableLayoutPanel

End Class
