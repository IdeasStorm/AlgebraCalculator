Imports AlGebraCalculator.ExtendedMath

Public Class VInput
    Private mIsPower As Boolean
    Public Property IsPower() As Boolean
        Get
            Return mIsPower
        End Get
        Set(ByVal value As Boolean)
            mIsPower = value
            Align()
        End Set
    End Property

    Public Property Number() As polynom          'to polynom
        Get
            Dim res As Polynom = Polynom.Zero
            res = Polynom.Parse(txtInput.Text)
            Return res
        End Get
        Set(ByVal value As Polynom)
            txtInput.Text = value.ToString
        End Set
    End Property
    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.IsPower = False
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Sub New(ByVal IsPower As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.IsPower = IsPower
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Align()
        If IsPower Then
            txtInput.Top = 5
        Else
            txtInput.Top = Me.Height / 2 - txtInput.Height / 2

        End If
    End Sub

    Private Sub VInput_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        CType(Me.Parent.Parent.Parent, Document).SelectedControl = Me
    End Sub
    Private Sub VInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Align()

    End Sub

    Private Sub VInput_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Align()
    End Sub

    Private Sub MatrixToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MatrixToolStripMenuItem1.Click
        CType(Me.Parent.Parent, MathLine).AddMatrix(Me)
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click, ToolStripMenuItem6.Click, ToolStripMenuItem5.Click, AdjToolStripMenuItem.Click
        Dim el As New VOperator
        el.Text = sender.text
        CType(Me.Parent.Parent, MathLine).AddElement(el, Me)
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
