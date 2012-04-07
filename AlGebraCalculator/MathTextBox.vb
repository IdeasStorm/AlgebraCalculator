Imports System.Text

Public Class MathTextBox
    Inherits TextBox
    Private sh As Integer = -1
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
    End Sub


    Private Sub MathTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        SmartPower()
    End Sub
    Private Sub SmartPower()
        Dim content As String = Me.Text

        sh = content.IndexOf("^")
        If sh <> -1 AndAlso content(content.Length - 1) = " " Then
            Me.Text = LSet(content, sh) & ExtendedMath.ToUpString(content.Substring(sh + 1))
            sh = -1
            Me.SelectionStart = content.Length - 1
        End If
    End Sub

  
End Class
