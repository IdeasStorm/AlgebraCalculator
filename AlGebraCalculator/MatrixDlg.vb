Imports System.Windows.Forms

Public Class MatrixDlg

    Public value As Integer = 0
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If Integer.TryParse(Me.Mytxt.Text, Me.value) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Abort
        End If


        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Dim Ndlg As New MatrixDlg
        Me.Close()
    End Sub

    Private Sub Mytxt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mytxt.TextChanged

    End Sub

End Class
