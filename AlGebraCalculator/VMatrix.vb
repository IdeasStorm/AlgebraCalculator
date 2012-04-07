Imports AlGebraCalculator.ExtendedMath

Public Class VMatrix
    Friend Shared cellSize As Integer = My.Settings("CellSize")
    Private offset As Integer
    Private mMatrix As ExtendedMath.Matrix1(Of Polynom)
    Private mItems(,) As TextBox

    ' Matrix Object are Defined in ExtendedMath shared Class

    Public Property Matrix() As ExtendedMath.Matrix1(Of Polynom)
        Get
            Return mMatrix
        End Get
        Set(ByVal value As ExtendedMath.Matrix1(Of Polynom))
            mMatrix = value
        End Set
    End Property


    Default Public Property Item(ByVal i As Integer, ByVal j As Integer) As Polynom
        Get
            Return mMatrix(i, j)
        End Get
        Set(ByVal value As Polynom)
            mMatrix(i, j) = value
        End Set
    End Property

    Private Sub CreateBoxes(ByVal m As Integer, ByVal n As Integer)
        cellSize = My.Settings("CellSize")
        offset = Me.Lbrac.Width
        Me.Height = offset * 2 + m * 20
        Me.Width = offset * 2 + n * cellSize
        Dim MyMat(m - 1, n - 1) As TextBox
        mItems = MyMat
        Dim itm As TextBox
        For i As Byte = 0 To m - 1
            For j As Byte = 0 To n - 1
                itm = New MathTextBox

                itm.TextAlign = HorizontalAlignment.Center
                Me.Controls.Add(itm)
                itm.Location = New Point(offset + (j) * cellSize, offset + (i) * 20)
                itm.Width = cellSize
                MyMat(i, j) = itm

                AddHandler itm.Click, AddressOf VMatrix_Click
                AddHandler itm.TextChanged, AddressOf VMatrix_Changed

            Next
        Next


    End Sub

    Public Sub New(ByVal m As Byte, ByVal n As Byte)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        mMatrix = Matrix1(Of Polynom).zero(m, n)

        ' Add any initialization after the InitializeComponent() call.
        CreateBoxes(m, n)

    End Sub

    Public Sub New(ByVal Mat As ExtendedMath.Matrix1(Of Polynom))
        InitializeComponent()
        Me.Matrix = Mat
        CreateBoxes(Mat.m, Mat.n)
        LoadItems()

    End Sub

    Private Sub VMatrix_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click, Lbrac.Click, Rbrac.Click
        CType(Me.Parent.Parent.Parent, Document).SelectedControl = Me

    End Sub

    Private Sub VMatrix_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        CType(Me.Parent.Parent.Parent, Document).SelectedControl = Me
    End Sub
    Private Sub VMatrix_Changed(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Mainfrm.ActiveDocument.isModified = True

        Catch ex As Exception

        End Try
     
    End Sub
    Public Sub LoadItems()
        For i As Integer = 1 To mMatrix.m
            For j As Integer = 1 To mMatrix.n
                Me.mItems(i - 1, j - 1).Text = mMatrix(i, j).ToString
            Next
        Next

    End Sub
    Public Sub LoadNumbers()

        For i As Integer = 1 To mMatrix.m
            For j As Integer = 1 To mMatrix.n

                mMatrix(i, j) = Polynom.Parse(mItems(i - 1, j - 1).Text)

            Next
        Next

    End Sub

    'Public Overloads Function memberwiseClone() As VMatrix
    '    Dim ctrl As New VMatrix(mMatrix.m, mMatrix.n)
    '    ctrl.mMatrix = mMatrix
    '    'ctrl.mItems = New TextBox(mMatrix.m - 1, mMatrix.n - 1) {}
    '    'Array.ConstrainedCopy(mItems, 0, ctrl.mMatrix.Items, 0, mItems.Length)
    '    Return ctrl
    'End Function


    Private Sub MakeZToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakeZToolStripMenuItem.Click
        Me.Matrix = Matrix1(Of Polynom).zero(mMatrix.m, mMatrix.n)
        LoadItems()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click, ToolStripMenuItem3.Click, ToolStripMenuItem2.Click, AdjToolStripMenuItem1.Click
        Dim el As New VOperator
        el.Text = sender.text
        CType(Me.Parent.Parent, MathLine).AddElement(el, Me)
    End Sub

    Private Sub MatrixToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MatrixToolStripMenuItem.Click
        CType(Me.Parent.Parent, MathLine).AddMatrix(Me)
    End Sub
    Public ReadOnly Property NextControl() As Control
        Get
            If Me.Parent.Controls.GetChildIndex(Me) <> Me.Parent.Controls.Count - 1 Then
                Return Me.Parent.Controls(Me.Parent.Controls.GetChildIndex(Me) + 1)
            Else
                Return Nothing
            End If

        End Get
    End Property
    Private Sub GetRankToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetRankToolStripMenuItem.Click
        Me.LoadNumbers()
#If Not Debug Then
  Try
#End If

        Mainfrm.SendMessage("Matrix Rank = " & Matrix.rank().ToString)
#If Not Debug Then
        Catch ex As Exception
            Mainfrm.SendError(Me, ex.Message)
        End Try
#End If

    End Sub

    Private Sub GetDetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetDetToolStripMenuItem.Click
        Me.LoadNumbers()
#If Not Debug Then
        Try
#End If
        Mainfrm.SendMessage("Matrix Det = " & Matrix.Det.ToString)
#If Not Debug Then
        Catch ex As Exception
            Mainfrm.SendError(Me, ex.Message)
        End Try
#End If

    End Sub


    Private Sub VMatrix_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub MakeOneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakeOneToolStripMenuItem.Click
        Me.Matrix = Matrix1(Of Polynom).One(Matrix.m, Matrix.n)
        Me.LoadItems()
    End Sub

    Private Sub MakeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakeToolStripMenuItem.Click
        Dim numdlg As New MatrixDlg
        numdlg.title.Text = "Enter Number"
        If numdlg.ShowDialog = DialogResult.OK Then
            Dim num As Polynom = Polynom.Zero
            If Polynom.TryParse(numdlg.Mytxt.Text, num) Then
                Me.Matrix = Matrix1(Of Polynom).One(Matrix.m, Matrix.n) * num
                Me.LoadItems()
            End If
          
        End If
        numdlg.Dispose()
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
