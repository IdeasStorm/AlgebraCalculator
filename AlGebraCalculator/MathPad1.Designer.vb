<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MathPad1
    Inherits System.Windows.Forms.FlowLayoutPanel

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
        Me.SuspendLayout()
        '
        'MathPad
        '
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Size = New System.Drawing.Size(324, 261)
        Me.WrapContents = False
        Me.ResumeLayout(False)

    End Sub

End Class
