
Imports System.Text
Imports AlGebraCalculator.ExtendedMath

Public Class MathLine

    Private mSelectedControl As Control = Nothing
    Public Event FirstUse(ByVal sender As Object, ByVal e As EventArgs)
    Private selectedColor As Color = SystemColors.ActiveBorder
    Private UnselectedColor As Color = SystemColors.Window
    Friend Event Modified()


#Region "Adding Elements"
    ''' <summary>
    ''' This Method will Add a Matrix to this MathLine
    ''' this should view n and m dialogs.
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub AddMatrix(ByRef oldControl As Control)
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
                Me.AddElement(a, oldControl)

            End If
        End If
    End Sub

    ''' <summary>
    ''' This Method will Add an element to this MathLine
    ''' </summary>
    ''' <param name="ele">element to be added</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddElement(ByVal ele As Control, ByRef oldControl As Control)
        Me.SymFlow.Controls.Add(ele)
        If Not oldControl Is Nothing Then Me.SymFlow.Controls.SetChildIndex(ele, Me.SymFlow.Controls.GetChildIndex(oldControl))
    End Sub

    ''' <summary>
    ''' Adds an element to result panel
    ''' </summary>
    ''' <param name="ele">control to be added</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddToResult(ByVal ele As Control)
        Me.pnlres.Controls.Clear()
        Me.pnlres.Controls.Add(ele)
    End Sub
#End Region

#Region "Booleans"
    ''' <summary>
    ''' return a boolean value whether this control is operator or not
    ''' </summary>
    ''' <param name="ctrl">control to be verified</param>
    ''' <param name="c">type of operator</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsOperator(ByRef ctrl As Control, ByVal c As String) As Boolean
        If (TypeOf ctrl Is VOperator) AndAlso CType(ctrl, VOperator).Text = c Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IsPower(ByVal ctrl As Control) As Boolean
        Return (TypeOf ctrl Is VInput) AndAlso CType(ctrl, VInput).IsPower
    End Function

    Public Function IsNumber(ByVal ctrl As Control) As Boolean
        Return (TypeOf ctrl Is VInput) AndAlso Not CType(ctrl, VInput).IsPower
    End Function

#End Region

#Region "Selection"





    Private Sub SymFlow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SymFlow.Click, pnlres.Click ', Me.Click
        Me.Activate()
    End Sub

    Public Sub Activate()
        CType(Me.ParentForm, Document).ActiveLine = Me
    End Sub
 

    Private Sub SymFlow_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles SymFlow.ControlAdded
        If Me.SymFlow.Controls.Count = 1 Then
            RaiseEvent FirstUse(sender, e)
            RaiseEvent Modified()
        End If
    End Sub
#End Region

#Region "Calculations"

    ''' <summary>
    ''' Calculates the Mathematic Expression that is Typed in MathLine
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Calculate()
        ' we must determine clac Type
        If Me.SymFlow.Controls.Count = 0 Then

            Me.pnlres.Controls.Clear()
        Else

#If Not Debug Then
            Try
#End If
            Dim a As New VMatrix(calcMat)
            Me.AddToResult(a)
            a.LoadItems()
#If Not Debug Then
            Catch ex As Exception


                Mainfrm.SendError(Me, ex.Message)

            End Try
#End If
        End If

    End Sub

    ''' <summary>
    ''' Calculates the Multiply result of a specific Domain of MathLine
    ''' </summary>
    ''' <param name="a">Domain Begin</param>
    ''' <param name="b">Domain End</param>
    ''' <returns>Returns the Result As a Matrix</returns>
    ''' <remarks></remarks>
    Public Function CalcMul(ByVal a As Integer, ByVal b As Integer) As ExtendedMath.Matrix1(Of ExtendedMath.Polynom)
        Dim numISfirst As Boolean = False
        Dim firstnum As Polynom = Polynom.Zero
        Dim items As ControlCollection = Me.SymFlow.Controls
        Dim result As ExtendedMath.Matrix1(Of ExtendedMath.Polynom)

        result = ExtendedMath.Matrix1(Of ExtendedMath.Polynom).Null
        If IsNumber(items(a)) Then
            numISfirst = True
            firstnum = CType(items(a), VInput).Number
            a += 1
        End If
        For i = a To b
            If (TypeOf items(i) Is VMatrix) OrElse IsNumber(items(i)) Then
                If IsNumber(items(i)) Then
                    result = result * CType(items(i), VInput).Number
                Else
                    If IsPower(CType(items(i), VMatrix).NextControl) Then
                        CType(items(i), VMatrix).LoadNumbers()
                        result = result * (CType(items(i), VMatrix).Matrix ^ CType(CType(items(i), VMatrix).NextControl, VInput).Number)
                    ElseIf i <> 0 AndAlso IsOperator(items(i - 1), "Adj") Then
                        CType(items(i), VMatrix).LoadNumbers()
                        result = result * CType(items(i), VMatrix).Matrix.GetAdj()
                    Else
                        CType(items(i), VMatrix).LoadNumbers()
                        result = result * CObj(items(i)).Matrix
                    End If
                End If
            End If
        Next

        If firstnum Then result = result * firstnum
        Return result

    End Function

    ''' <summary>
    ''' This Method will calculate the result and put it in result panel
    ''' </summary>
    ''' <remarks></remarks>
    Function calcMat() As Matrix1(Of Polynom)
        Dim items As ControlCollection = Me.SymFlow.Controls
        Dim last As Integer = 0
        Dim Neg As Boolean
        Dim result As ExtendedMath.Matrix1(Of Polynom) = ExtendedMath.Matrix1(Of Polynom).Null
        For i As Integer = 0 To items.Count - 1
            If IsOperator(items(i), "+") Then
                Neg = False
                result = result + CalcMul(last, i - 1)
                last = i
            ElseIf IsOperator(items(i), "-") Then
                Neg = True

                result = result - CalcMul(last, i - 1)

                last = i
            End If
        Next

        If Neg = True Then
            result = result - CalcMul(last, items.Count - 1)
        Else
            result = result + CalcMul(last, items.Count - 1)
        End If

        Return result
    End Function

#End Region

    Enum DataType As Byte
        Matrix
        [Operator]
        number
        power
    End Enum

    Public Sub Save(ByVal binWriter As IO.BinaryWriter)
        binWriter.Write(Me.SymFlow.Controls.Count)
        For Each a As Control In Me.SymFlow.Controls
            With binWriter
                If TypeOf a Is VMatrix Then
                    Dim mat As VMatrix = CType(a, VMatrix)
                    .Write(DataType.Matrix)
                    .Write(mat.Matrix.m)
                    .Write(mat.Matrix.n)
                    mat.LoadNumbers()
                    For i As Integer = 1 To mat.Matrix.m
                        For j As Integer = 1 To mat.Matrix.n
                            .Write(mat.Matrix(i, j).ToString)
                        Next
                    Next
                ElseIf IsNumber(a) Then
                    Dim num As VInput = CType(a, VInput)
                    .Write(DataType.number)
                    .Write(num.Number.ToString)
                ElseIf IsPower(a) Then
                    Dim num As VInput = CType(a, VInput)
                    .Write(DataType.power)
                    .Write(CInt(num.Number))
                ElseIf TypeOf a Is VOperator Then
                    Dim oper As VOperator = CType(a, VOperator)
                    .Write(DataType.Operator)
                    .Write(oper.Text)
                End If
            End With

        Next
    End Sub
    Private Sub pnlres_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlres.Resize
        Me.SymFlow.Width = Me.Width - sender.width - 7
    End Sub

    Private Sub SymFlow_ControlRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles SymFlow.ControlRemoved
        RaiseEvent Modified()
    End Sub

    Private Sub MathLine_Modified() Handles Me.Modified
        If Not Me.ParentForm Is Nothing Then
            CType(Me.ParentForm, Document).isModified = True
        End If

    End Sub
End Class
