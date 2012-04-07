Imports System.Windows
Public Class MathPad1
    Inherits FlowLayoutPanel
    Private mCurrentIndex As Integer
    Private mSelectedControl As Control = Nothing
    Private Event KeyDown1 As KeyEventHandler
    Public Shared dict As New Dictionary(Of Keys, Char)
    Private cutTemp As Control






    Public Property SelectedControl() As Control
        Get
            Return mSelectedControl
        End Get
        Set(ByVal value As Control)
            If Not (mSelectedControl Is Nothing) Then
                mSelectedControl.BackColor = Color.White
                mSelectedControl = value
                mSelectedControl.BackColor = SystemColors.ActiveBorder
            Else
                mSelectedControl = value
                If Not mSelectedControl Is Nothing Then mSelectedControl.BackColor = SystemColors.ActiveBorder
            End If

        End Set
    End Property
    Public ReadOnly Property CurrentIndex() As Int32
        Get
            Return mCurrentIndex
        End Get
    End Property



    Public Sub OnKeyDown1(ByVal sender As Object, ByVal e As KeyEventArgs)
        RaiseEvent KeyDown1(sender, e)
    End Sub
    Public Sub MathPad_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim c As New Char


        If e.KeyCode = Keys.M And e.Control = True Then
            Dim m, n As New Integer
            Dim mdlg As New MatrixDlg
            mdlg.title.Text = "Enter M"
            If mdlg.ShowDialog = DialogResult.OK Then
                mdlg.title.Text = "Enter N"
                m = mdlg.value
                mdlg.Mytxt.Text = ""
                If mdlg.ShowDialog = DialogResult.OK Then
                    n = mdlg.value
                    Dim a As New VMatrix(m, n)
                    Me.Controls.Add(a)
                End If
            End If
        ElseIf e.KeyData = Keys.Delete Then
            Me.Controls.Remove(mSelectedControl)
            mSelectedControl.Dispose()

        ElseIf e.KeyData = Keys.P Then 'And e.Control Then
            Me.Controls.Add(cutTemp)
        ElseIf e.KeyCode And e.KeyCode = Keys.V Then
            cutTemp = mSelectedControl
        ElseIf e.Control = True Then
            If dict.ContainsKey(e.KeyCode) Then
                Dim plus As New VOperator With {.Height = Me.Height / 2, .opType = e.KeyCode}
                Me.Controls.Add(plus)
            End If
        ElseIf e.Control = True Then
            If e.KeyData = Keys.X Then
                cutTemp = mSelectedControl
                Me.Controls.Remove(mSelectedControl)
            End If
        End If






    End Sub
    Shared Sub New()
        dict.Add(Keys.OemMinus, "-")
        dict.Add(Keys.Subtract, "-")
        dict.Add(Keys.Oemplus, "+")
        dict.Add(Keys.Add, "+")
        dict.Add(Keys.Multiply, "×")
        dict.Add(Keys.Divide, "÷")
    End Sub
    Public Sub Calc()


    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()


        ' Add any initialization after the InitializeComponent() call.


        AddHandler KeyDown1, AddressOf MathPad_KeyDown
        'RaiseEvent KeyDown1(New Object, New KeyEventArgs(Keys.A))
    End Sub

    Public Function InsertMatrix(ByVal m As Integer, ByVal n As Integer) As VMatrix
        Dim a As New VMatrix(m, n)
        Me.Controls.Add(a)
        Return a
    End Function
    Public Sub InsertOperator(ByVal c As Char)
        Dim a As New VOperator With {.text = c}
        Me.Controls.Add(a)
    End Sub
    Public Sub Mul()
        Dim A, B, C As VMatrix
        A = CType(Me.Controls(0), VMatrix)
        B = CType(Me.Controls(1), VMatrix)
        A.LoadNumbers()
        B.LoadNumbers()
        Dim res As Byte 'rem convet
        C = InsertMatrix(A.mm, B.nn)
        C.mNumbers.Items = ExtendedMath.mult(A.mNumbers.Items, B.mNumbers.Items, A.mm, A.nn, B.mm, B.nn, CByte(res))
        C.LoadItems()
    End Sub
End Class
