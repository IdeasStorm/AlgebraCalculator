Imports System.Text

Public Class ExtendedMath

    Public Shared Function UpNum(ByVal x As Char) As Char
        If x = "1" Then
            Return ChrW(185)
        ElseIf x = "2" Or x = "3" Then
            Return ChrW(176 + Val(x))
        ElseIf "0456789".Contains(x) Then
            Return ChrW(8304 + Val(x))
        Else
            Return ""
        End If
    End Function

    Public Shared Function ToUpString(ByVal s As String)
        Dim res As String = ""
        For i = 0 To s.Length - 1
            res = res & UpNum(s(i))
        Next
        Return res
    End Function

    Structure Complex
        Public re, im As Double
        Public Sub New(ByVal re As Double, ByVal im As Double)
            Me.re = re
            Me.im = im
        End Sub
        Public ReadOnly Property Abs() As Double
            Get
                Return Math.Sqrt((Me.re) * (Me.re) + (Me.im) * (Me.im))
            End Get
        End Property


        Public Shared Operator +(ByVal x As Complex, ByVal y As Complex) As Complex
            Return New Complex(x.re + y.re, x.im + y.im)
        End Operator
        Public Shared Operator -(ByVal x As Complex, ByVal y As Complex) As Complex
            Return New Complex(x.re - y.re, x.im - y.im)
        End Operator
        Public Shared Operator *(ByVal x As Complex, ByVal y As Complex) As Complex
            Return New Complex((x.re * y.re) + (x.im * y.im), (x.re * y.im) + (y.im * x.re))
        End Operator
        Public Shared Operator \(ByVal x As Complex, ByVal y As Complex) As Complex
            Dim resnum As Complex
            y.im = (-1) * y.im
            resnum = (x * y)
            y.im = (-1) * y.im
            resnum.re = resnum.re \ (y.Abs ^ 2)
            resnum.im = resnum.im \ (y.Abs ^ 2)
            Return resnum
        End Operator

        Public Shared Narrowing Operator CType(ByVal x As Complex) As Double
            If x.im = 0 Then
                Return x.re
            Else
                Throw New Exception("Cannot Convert " & x.ToString & " to Double")
            End If
        End Operator

        Public Overrides Function ToString() As String
            Dim fop, sOp, i, reS, imS As String
            fop = ""
            sOp = "+"
            reS = Me.re.ToString
            imS = Me.im.ToString
            i = "i"
            Dim sb As New StringBuilder
            If Me.re = 0 Then
                reS = ""
                fop = ""
            End If
            If Me.im = 0 Then
                imS = ""
                sOp = ""
            End If
            If Me.im = 1 Then
                imS = "+"
            ElseIf Me.im = -1 Then
                imS = "-"
            End If
            If Me.im < 0 Then
                sOp = ""
            Else
                sOp = "+"
            End If


            sb.AppendFormat("{0} {1}", fop, reS)
            sb.AppendFormat("{0} {1} {2}", sOp, imS, i)
            Return sb.ToString
        End Function

        ' Public Shared Widening Operator CType (x As Double) As 
    End Structure

    Structure Polynom
        Public IsZero As Boolean

        Public Shared ReadOnly Property Zero() As Polynom
            Get
                Dim a As New Polynom
                a.IsZero = True
                Return a
            End Get

        End Property
        Public items As Dictionary(Of Integer, Double)

        Default Public Property item(ByVal i As Integer) As Double
            Get
                If IsZero Then
                    Return 0
                Else
                    If items Is Nothing Then initialize()
                    Return items(i)
                End If

            End Get
            Set(ByVal value As Double)
                If value <> 0 Then
                    IsZero = False
                    If items Is Nothing Then initialize()
                    If items.ContainsKey(i) Then
                        items(i) = items(i) + value
                        If items(i) = 0 Then
                            items.Remove(i)
                        End If
                        If Count = 0 Then Me.IsZero = True
                    Else
                        items.Add(i, value)
                    End If
                End If

            End Set
        End Property

        

        Public Sub Add(ByVal p As Integer, ByVal c As Double)
            Me(p) = c
        End Sub

        Public ReadOnly Property Count() As Integer
            Get
                If Not Me.items Is Nothing Then
                    Return Me.items.Count
                Else
                    Return 0
                End If
            End Get
        End Property

        Public Function ContainsPower(ByVal x As Double) As Boolean
            Return Me.items.ContainsKey(x)
        End Function

        Private Sub initialize()
            items = New Dictionary(Of Integer, Double)

        End Sub


        Public Shared Function ParseOnePoly(ByVal s As String) As Polynom
            Dim p As Polynom = Polynom.Zero
            Dim cons As New Double
            Dim pow As New Integer
            Dim i As Integer = 0

            While i <> s.Length AndAlso s(i) <> "x"
                i += 1
            End While
            If s.Length = 1 Then
                If i < s.Length And i = 0 Then
                    If s(i) = "x" Then
                        p.Add(1, 1)
                    End If
                Else
                    p.Add(0, Double.Parse(s))
                End If
            Else
                If i = 0 Then
                    p.Add(Integer.Parse(ToDownString(s.Substring(i + 1, s.Length - i - 1))), 1)
                Else
                    If i = s.Length Then
                        p.Add(0, Double.Parse(s))
                    Else
                        If i = s.Length - 1 Then
                            If s(i - 1) = "-" Then
                                cons = -1
                            Else
                                If s(i - 1) = "+" Then
                                    cons = 1
                                Else
                                    cons = Double.Parse(s.Substring(0, i))
                                End If
                            End If
                            pow = 1
                        Else                         'if not any thing we calaulate
                            If s(i - 1) = "-" Then
                                cons = -1
                            Else
                                If s(i - 1) = "+" Then
                                    cons = 1
                                Else
                                    cons = Double.Parse(s.Substring(0, i))
                                End If
                            End If
                            pow = Integer.Parse(ToDownString(s.Substring(i + 1, s.Length - i - 1)))
                        End If
                    End If
                    p.Add(pow, cons)
                End If
            End If
            Return p
        End Function
        Public Shared Function Parse(ByVal S_Poly As String) As Polynom
            'mhd..
            S_Poly = S_Poly.ToLower
            S_Poly = S_Poly.Replace(" ", "")

            'sniper...
            Dim res As Polynom = Zero
            If S_Poly <> "" Then
                Dim st As String = ""
                Dim nPoly As New Polynom
                For i As Integer = 0 To S_Poly.Length - 1
                    If S_Poly(i) = "+" Or S_Poly(i) = "-" Then
                        If st.Length > 0 Then
                            nPoly = ParseOnePoly(st)
                            res = res + nPoly
                            st = ""
                        End If
                    End If
                    st = st + Convert.ToChar(S_Poly(i))
                Next
                res = res + ParseOnePoly(st)
            Else
                res = Zero
            End If
            Return res
        End Function

        Public Shared Function UpNum(ByVal x As Integer) As Char
            If x = 1 Then
                Return ChrW(185)
            ElseIf x = 2 Or x = 3 Then
                Return ChrW(176 + x)
            Else
                Return ChrW(8304 + x)
            End If
        End Function

        Public Shared Function ToDown(ByVal c As Char) As Char
            If c = ChrW(185) Then
                Return "1"
            ElseIf c = ChrW(178) Then
                Return "2"
            ElseIf c = ChrW(179) Then
                Return "3"
            ElseIf AscW(c) >= 8304 And AscW(c) <= (8304 + 9) Then
                Return (AscW(c) - 8304).ToString
            ElseIf c = "+" Or c = "-" Then
                Return c
            Else
                Throw New Exception("character " & c & "is invalid")
            End If
        End Function
        Public Shared Function ToDownString(ByVal s As String) As String
            Dim res As String = ""
            For i = 0 To s.Length - 1
                res = res & ToDown(s(i))
            Next
            Return res
        End Function

        Public Overrides Function ToString() As String
            If Not Me.IsZero Then
                Dim sb As New StringBuilder
                Dim oper, power, x, cons As New String("")

                For Each poly As KeyValuePair(Of Integer, Double) In Me.items
                    If poly.Value <> 0 Then
                        cons = poly.Value
                        power = UpNum(poly.Key)
                        x = "x"
                        oper = "+"
                        If poly.Value < 0 Then oper = ""
                        If poly.Key <> 0 Then
                            If poly.Value = 1 Then cons = "" : oper = "+" Else If poly.Value = -1 Then cons = "" : oper = "-"

                        End If

                        If poly.Key = 1 Then power = "" Else If poly.Key = 0 Then power = "" : x = ""
                        sb.AppendFormat("{0}{1}{2}{3}", oper, cons, x, power)
                    End If
                Next
                If sb.ToString = "" Then sb.Append("0")
                Return sb.ToString
            Else
                Return "0"
            End If

        End Function




        Public Shared Function TryParse(ByVal s As String, ByRef p As Polynom) As Boolean
            Try
                p = Parse(s)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Operator +(ByVal x As Polynom, ByVal y As Polynom) As Polynom
            Dim res As New Polynom
            If x.IsZero Then
                Return y
            ElseIf y.IsZero Then
                Return x
            Else
                For Each poly As KeyValuePair(Of Integer, Double) In x.items
                    res.Add(poly.Key, poly.Value)
                Next


                For Each poly As KeyValuePair(Of Integer, Double) In y.items
                    res.Add(poly.Key, poly.Value)
                Next

            End If

            Return res
        End Operator

        Public Shared Operator *(ByVal x As Polynom, ByVal y As Polynom) As Polynom

            If x.IsZero Or y.IsZero Then
                Return Polynom.Zero
            Else
                Dim res As New Polynom
                For Each poly1 As KeyValuePair(Of Integer, Double) In x.items
                    For Each poly2 As KeyValuePair(Of Integer, Double) In y.items
                        res.Add(poly1.Key + poly2.Key, poly1.Value * poly2.Value)
                    Next
                Next
                Return res
            End If

        End Operator

        Public Shared Operator -(ByVal x As Polynom, ByVal y As Polynom) As Polynom
            y = y * -1
            Return x + y
        End Operator

        Public Shared Widening Operator CType(ByVal x As Double) As Polynom
            If x <> 0 Then
                Dim res As New Polynom
                res(0) = x
                Return res
            Else
                Return Zero
            End If

        End Operator
        Public Shared Narrowing Operator CType(ByVal x As Polynom) As Double
            If x = Zero Then
                Return 0
            Else
                If x.Count = 1 AndAlso x.ContainsPower(0) Then
                    Return x(0)
                Else
                    Throw New Exception("cannot convert polynom " & x.ToString & " to double")
                End If
            End If


        End Operator

        Public Shared Shadows Operator =(ByVal x As Polynom, ByVal y As Polynom) As Boolean
            If x.IsZero And y.IsZero Then
                Return True
            ElseIf x.IsZero Xor x.IsZero Then
                Return False
            Else
                If x.Count = y.Count Then
                    Dim res As Boolean = True
                    For Each term As KeyValuePair(Of Integer, Double) In x.items
                        If Not (y.ContainsPower(term.Key) AndAlso y(term.Key) = term.Value) Then
                            res = False
                            Exit For
                        End If
                    Next
                Else
                    Return False
                End If
            End If

        End Operator
        Public Shared Shadows Operator <>(ByVal x As Polynom, ByVal y As Polynom) As Boolean
            If (x = y) Then
                Return False
            Else
                Return True
            End If
        End Operator
        Public Shared Shadows Operator /(ByVal x As Polynom, ByVal y As Double) As Polynom
            If x = Zero Then
                Return Zero
            ElseIf y = 0 Then
                Throw New ArithmeticException("Division by zero")
            Else
                Dim res As Polynom = Zero
                For Each term As KeyValuePair(Of Integer, Double) In x.items
                    res.Add(term.Key, term.Value / y)
                Next
                Return res
            End If

        End Operator

    End Structure

    ''' <summary>
    ''' Defines a Matrix and it's operations
    ''' </summary>
    Structure Matrix1(Of T As New)

        Private isnull As Boolean
        Public m, n As Int32
        Private Items(,) As T
        Public Shared ReadOnly Null As New Matrix1(Of T) With {.isnull = True}
        Public Shared ReadOnly Property One(ByVal m As Integer, ByVal n As Integer) As Matrix1(Of T)
            Get
                Dim a As New Matrix1(Of T)(m, n)
                For i As Integer = 1 To m
                    For j As Integer = 1 To n
                        If i = j Then
                            a(i, j) = 1
                        Else
                            a(i, j) = 0
                        End If
                    Next
                Next
                Return a
            End Get
        End Property

        Public Shared ReadOnly Property zero(ByVal m As Integer, ByVal n As Integer) As Matrix1(Of T)
            Get
                Dim a As New Matrix1(Of T)(m, n)
                For i As Integer = 1 To m
                    For j As Integer = 1 To n
                        a(i, j) = 0
                    Next
                Next
                Return a
            End Get

        End Property

        Public Sub New(ByVal m As Int32, ByVal n As Int32)
            If Not (m = 0 Or n = 0) Then
                Me.m = m
                Me.n = n
                Items = New T(m - 1, n - 1) {}
                Me.isnull = False
            Else
                Throw New ArithmeticException("Matrix Bounds Cannot be Null")
            End If

        End Sub

        Shared Sub New()

        End Sub

        Default Public Property Item(ByVal i As Integer, ByVal j As Integer) As Polynom
            Get
                Return CObj(Items(i - 1, j - 1))
            End Get
            Set(ByVal value As Polynom)
                Items(i - 1, j - 1) = CObj(value)
            End Set
        End Property

#Region "Operators"
        Public Shared Operator +(ByVal x As Matrix1(Of T), ByVal y As Matrix1(Of T)) As Matrix1(Of T)
            If x = Null Then
                Return y
            ElseIf y = Null Then
                Return x
            ElseIf (x.m = y.m) And (x.n = y.n) Then
                Dim Z As New Matrix1(Of T)(x.m, x.n)
                Z = add(x, y)
                Return Z
            Else
                Throw New ArithmeticException("The 1st and 2nd Matrix does not have the same m,n")
                Return Nothing

            End If

        End Operator

        Public Shared Operator -(ByVal x As Matrix1(Of T), ByVal y As Matrix1(Of T)) As Matrix1(Of T)
            If x = Null Then
                Return y
            ElseIf y = Null Then
                Return x
            ElseIf (x.m = y.m) And (x.n = y.n) Then
                Dim Z As New Matrix1(Of T)(x.m, x.n)
                Z = subt(x, y)
                Return Z
            Else
                Throw New ArithmeticException("The 1st and 2nd Matrix does not have the same m,n")
                Return Nothing

            End If
        End Operator

        Public Overloads Shared Operator *(ByVal x As Matrix1(Of T), ByVal y As Matrix1(Of T)) As Matrix1(Of T)
            If x = Null Then
                Return y
            ElseIf y = Null Then
                Return x
            End If
            If x.n = y.m Then
                Dim resmat As New Matrix1(Of T)(x.m, y.n)
                resmat = mult(x, y)
                Return resmat
            Else
                Throw New ArithmeticException("The 1st and 2nd Matrix does not meet the Multiply Condition")
                Return Nothing
            End If
        End Operator
        Public Overloads Shared Operator *(ByVal x As Double, ByVal y As Matrix1(Of T)) As Matrix1(Of T)
            Return mulnum(x, y)
        End Operator
        Public Overloads Shared Operator *(ByVal x As Matrix1(Of T), ByVal y As Polynom) As Matrix1(Of T)
            Return mulnum(y, x)
        End Operator

        Public Shared Operator =(ByVal x As Matrix1(Of T), ByVal y As Matrix1(Of T)) As Boolean
            If x.isnull = True And y.isnull = True Then
                Return True
            ElseIf x.m = y.m And x.n = y.n Then
                Return Array.Equals(x, y)
            End If
        End Operator

        Public Shared Operator <>(ByVal x As Matrix1(Of T), ByVal y As Matrix1(Of T)) As Boolean
            If x = y Then
                Return False
            Else
                Return True
            End If
        End Operator

        Public Shared Operator ^(ByVal x As Matrix1(Of T), ByVal y As Double) As Matrix1(Of T)
            Dim i As Integer = 1
            Dim res As Matrix1(Of T) = One(x.m, x.n)
            If y < 0 Then
                x = x.Invert()
                y = -y
            End If
            While i <= y
                res = res * x
                i += 1
            End While
            Return res
        End Operator
#End Region

        Public Function Invert() As Matrix1(Of T)

            Dim mydet As Double = Me.Det
            If mydet = 0 Then
                Throw New Exception("Matrix with Det Zero Cannot be Inverted")
            Else
                Return Me.GetAdj() * (1 / CDbl(Me.Det))
            End If

        End Function

        Private Function Small(ByVal lin As Integer, ByVal clm As Integer) As Matrix1(Of T)
            Dim hmat As New Matrix1(Of T)(Me.m - 1, Me.n - 1)
            Dim i3 As Integer = 0
            Dim j3 As Integer = 0
            For i2 As Integer = 1 To n
                If i2 <> lin Then
                    i3 += 1
                    j3 = 0
                    For j2 As Integer = 1 To n
                        If j2 <> clm Then
                            j3 += 1
                            hmat(i3, j3) = Me(i2, j2)
                        End If
                    Next
                End If
            Next
            Return hmat
        End Function
        REM poly -> T
        Public Function Det() As Polynom
            Dim hmat As Matrix1(Of T) = zero(Me.m, Me.n)
            If Me.m = Me.n Then
                Dim sum As Polynom = Polynom.Zero
                If n = 1 Then
                    sum = CObj(Me(Me.m, Me.n))
                Else
                    For j As Integer = 1 To Me.n
                        hmat = Me.Small(1, j)
                        If (j + 1) Mod 2 = 0 Then
                            sum = sum + CObj(Me(1, j) * hmat.Det())
                        Else
                            sum = sum + CObj((-1) * Me(1, j) * hmat.Det())
                        End If
                    Next
                End If
                If sum.Count = 0 Then sum = Polynom.Zero
                Return sum
            Else

                Throw New Exception("Non-Square Matrix Cannot have Det Value")

            End If

        End Function

        Public Function GetAdj() As Matrix1(Of T)
            Dim hmat As Matrix1(Of T) = zero(Me.m, Me.n)
            Dim resMat As Matrix1(Of T) = zero(Me.m, Me.n)
            For i As Integer = 1 To m
                For j As Integer = 1 To n
                    hmat = Me.Small(i, j)
                    If (j + i) Mod 2 = 0 Then
                        resMat(j, i) = hmat.Det()
                    Else
                        resMat(j, i) = (-1) * hmat.Det()
                    End If
                Next
            Next
            Return resMat
        End Function

        Public Shared Function mulnum(ByVal num As Polynom, ByVal x As Matrix1(Of T)) As Matrix1(Of T)
           
            Dim resmat As New Matrix1(Of T)(x.m, x.n)
            For i As Int32 = 1 To x.m
                For j As Integer = 1 To x.n
                    resmat(i, j) = num * x(i, j)
                Next
            Next

            Return resmat

            
        End Function

        'no need for min call Math.Min 
        Public Function rank() As Integer
            Dim mat2 As New Matrix1(Of Polynom)(Me.m, Me.n)
            Dim sum As Integer = Math.Min(Me.m, Me.n)
            For k As Integer = 1 To Math.Min(Me.m, Me.n)
                ''((Me.m) - 1)
                For i As Integer = k + 1 To ((Me.m))
                    Dim num As Double = Me(i, k)
                    For j As Integer = 1 To ((Me.n))
                        If Me(k, k) <> 0 Then
                            Me(i, j) = (Me(k, j) * -num / Me(k, k)) + Me(i, j)
                        Else : Me(i, j) = Me(k, j) + Me(i, j)
                        End If
                    Next
                Next
            Next
            For i As Integer = 1 To ((Me.m))
                For j As Integer = 1 To ((Me.n))
                    mat2(i, j) = Me(i, j)
                Next
            Next
            For i As Integer = 1 To Math.Min(Me.m, Me.n)
                Dim ok As Boolean = True
                Dim j As Integer = 0
                While ((ok) And (j < Me.n))
                    j += 1
                    If mat2(i, j) <> 0 Then
                        ok = False
                    End If
                End While
                If ok Then
                    sum -= 1
                End If
            Next
            Return sum

        End Function

        Public Shared Function mult(ByVal firmat As Matrix1(Of T), ByVal secmat As Matrix1(Of T)) As Matrix1(Of T)
            Dim resmat As Matrix1(Of T)
            resmat = zero(firmat.m, secmat.n) 'New Matrix1(Of T)(firmat.m, secmat.n)
            For i As Integer = 1 To firmat.m
                For j As Integer = 1 To secmat.n
                    For k As Integer = 1 To firmat.n
                        resmat(i, j) += firmat(i, k) * secmat(k, j)
                    Next
                Next
            Next
            Return resmat

        End Function
        Public Shared Function add(ByVal firmat As Matrix1(Of T), ByVal secmat As Matrix1(Of T)) As Matrix1(Of T)
            Dim resmat As New Matrix1(Of T)(firmat.m, firmat.n)
            For i As Integer = 1 To firmat.m
                For j As Integer = 1 To firmat.n
                    resmat(i, j) = firmat(i, j) + secmat(i, j)
                Next
            Next
            Return resmat
        End Function
        Public Shared Function subt(ByVal firmat As Matrix1(Of T), ByVal secmat As Matrix1(Of T)) As Matrix1(Of T)
            Dim resmat As Matrix1(Of T) = zero(firmat.m, firmat.n)
            For i As Integer = 1 To firmat.m
                For j As Integer = 1 To firmat.n
                    resmat(i, j) = firmat(i, j) - secmat(i, j)
                Next
            Next
            Return resmat
        End Function
        ' where is the A^-1
    End Structure


    Shared Sub dosth(ByVal b As String)
        Dim a As New Polynom

        a = Polynom.Parse(b)
        MsgBox("Ok")

        For Each k As KeyValuePair(Of Integer, Double) In a.items
            MsgBox(k.Value & "," & k.Key)
        Next

    End Sub

End Class