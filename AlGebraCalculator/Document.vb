Imports AlGebraCalculator.ExtendedMath

Public Class Document
    Friend FileName As String = ""
    Friend isModified As Boolean = False
    Private Linepos As Integer = 0
    Private selectedColor As Color = SystemColors.ActiveBorder
    Private UnselectedColor As Color = SystemColors.Window
    Private mSelectedControl As Control = Nothing
    Public Property ActiveLine() As MathLine
        Get

            Return Me.ActiveControl

        End Get
        Set(ByVal value As MathLine)

            If Not Me.ActiveControl Is Nothing Then Me.ActiveControl.BackColor = Me.UnselectedColor

            Me.ActiveControl = value
            Me.ActiveControl.BackColor = Me.selectedColor


        End Set
    End Property


    Public Property SelectedControl() As Control
        Get
            Return mSelectedControl
        End Get
        Set(ByVal value As Control)
            If Not (mSelectedControl Is Nothing) Then
                mSelectedControl.BackColor = Me.UnselectedColor
                mSelectedControl = value
                mSelectedControl.BackColor = Me.selectedColor
            Else
                mSelectedControl = value
                If Not mSelectedControl Is Nothing Then mSelectedControl.BackColor = Me.selectedColor
            End If
        End Set
    End Property

    Public Sub DeleteSelected()
        Dim a As Control = Me.SelectedControl
        Me.ActiveLine.SymFlow.Controls.Remove(a)
        a.Dispose()
    End Sub
    Sub AddLine(ByVal Myline As MathLine)

        Me.Controls.Add(Myline)
        Myline.Width = Me.Width - 10
        Myline.Height = 150
        Myline.Top = Linepos
        Linepos += Myline.Height
        Myline.Anchor = AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top

        'AddHandler MyLine.Enter, AddressOf MathPad1_Enter
        AddHandler Myline.FirstUse, AddressOf LineFirstUse
   
    End Sub
    Function AddLine(ByVal sender As Object, ByVal e As EventArgs) As MathLine

        Dim MyLine As New MathLine
        AddLine(MyLine)
        OnResize(e)
        Return MyLine
    End Function

    Private Sub LineFirstUse(ByVal sender As Object, ByVal e As EventArgs)
        AddLine(sender, e)
    End Sub

    Private Sub Document_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Mainfrm.CalculateLineToolStripMenuItem.Enabled = True
        Mainfrm.InsertMenu.Enabled = True
        For Each ctrl As ToolStripMenuItem In Mainfrm.InsertMenu.DropDown.Items
            ctrl.Enabled = True
        Next
    End Sub
    Private Sub Document_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Mainfrm.CalculateLineToolStripMenuItem.Enabled = False
        Mainfrm.InsertMenu.Enabled = False
        For Each ctrl As ToolStripMenuItem In Mainfrm.InsertMenu.DropDown.Items
            ctrl.Enabled = False
        Next
    End Sub

    Private Sub Document_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        For Each ctrl As MathLine In Me.Controls
            ctrl.Width = Me.Width - 10
        Next
    End Sub



    Friend Sub Open(ByVal filename As String)
        Dim fs As New IO.FileStream(filename, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
        Dim binreader As New IO.BinaryReader(fs)

        With binreader
            Dim LinesCount As Integer = .ReadInt32
            For k As Integer = 1 To LinesCount
                Dim CompCount As Integer = .ReadInt32
                Dim CurLine As New MathLine
                Me.AddLine(CurLine)
                For h As Integer = 1 To CompCount
                    Dim compType As MathLine.DataType = .ReadByte
                    If compType = MathLine.DataType.Matrix Then
                        Dim mat As New VMatrix(.ReadInt32, .ReadInt32)
                        For i As Integer = 1 To mat.Matrix.m
                            For j As Integer = 1 To mat.Matrix.n
                                mat(i, j) = Polynom.Parse(.ReadString)
                                'later will be T
                            Next
                        Next
                        mat.LoadItems()
                        CurLine.AddElement(mat, Nothing)
                    ElseIf compType = MathLine.DataType.number Then
                        Dim num As New VInput With {.IsPower = False}
                        num.Number = Polynom.Parse(.ReadInt32)
                        CurLine.AddElement(num, Nothing)
                    ElseIf compType = MathLine.DataType.power Then
                        Dim num As New VInput With {.IsPower = True}
                        num.Number = Polynom.Parse(.ReadInt32)
                        CurLine.AddElement(num, Nothing)
                    ElseIf compType = MathLine.DataType.Operator Then
                        Dim oper As New VOperator
                        oper.Text = .ReadString
                        CurLine.AddElement(oper, Nothing)
                    End If
                Next
            Next
        End With


        Me.isModified = False

    End Sub
    Friend Sub save()
        save(Me.FileName)
    End Sub
    Friend Sub Save(ByVal FileName As String)
        Dim fs As New IO.FileStream(FileName, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.Write)
        Dim Binwriter As New IO.BinaryWriter(fs)
        Binwriter.Write(Me.Controls.Count)
        For Each line As MathLine In Me.Controls
            line.Save(Binwriter)
        Next
        Binwriter.Close()
    End Sub

    Sub Calculate()
        For Each line As MathLine In Me.Controls
            line.Calculate()
        Next
    End Sub
   

    Private Sub Document_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Me.ControlAdded
        Me.isModified = True
    End Sub

    Private Sub Document_ControlRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Me.ControlRemoved
        Me.isModified = True
    End Sub

    Private Sub Document_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.isModified Then
            Dim res As MsgBoxResult = MsgBox("Do you want to save your changes on " & _
                """" & Me.Text & """ ? ", MsgBoxStyle.YesNoCancel, "Algebra Claculator")
            If res = MsgBoxResult.Yes Then
                Mainfrm.SaveToolStripButton_Click(sender, e)
            ElseIf res = MsgBoxResult.Cancel Then
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub Document_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.isModified = False
    End Sub
End Class
