Public Class VOperator
    

    Public Overrides Property Text() As String
        Get
            Return Label1.Text
        End Get
        Set(ByVal value As String)
            Label1.Text = value
        End Set
    End Property

    Public Overloads Function MemberwiseClone() As VOperator
        Dim ctrl As New VOperator
        ctrl.Text = Me.Text
        Return ctrl
    End Function

    Private Sub VOperator_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter, Label1.Enter, Label1.Click
        CType(Me.Parent.Parent.Parent, Document).SelectedControl = Me
    End Sub

    Private Sub VOperator_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Label1.Top = Me.Height / 2 - Label1.Height / 2
    End Sub

 
    Private Sub VOperator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click, ToolStripMenuItem6.Click, ToolStripMenuItem5.Click, AdjToolStripMenuItem.Click
        Dim el As New VOperator
        el.Text = sender.text
        CType(Me.Parent.Parent, MathLine).AddElement(el, Me)
    End Sub

    Private Sub MatrixToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MatrixToolStripMenuItem1.Click
        CType(Me.Parent.Parent, MathLine).AddMatrix(Me)
    End Sub

    Private Sub PowerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PowerToolStripMenuItem.Click, NumberToolStripMenuItem.Click

        Dim a As New VInput
        If sender.text = "Number" Then
            a.IsPower = False
        ElseIf sender.text = "Power" Then
            a.IsPower = True
        End If
        CType(Me.Parent.Parent, MathLine).AddElement(a, Me)

    End Sub
End Class
