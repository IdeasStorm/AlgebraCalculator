Imports System.Windows.Forms

Public Class Mainfrm
    Private ClipBoard As Control
    Private mWorkField As Workfields = Workfields.Polynom
    Public Property WorkField() As Workfields
        Get
            Return mWorkField
        End Get
        Set(ByVal value As Workfields)
            mWorkField = value
            If value = Workfields.Complex Then
                Me.lnkComplex.LinkVisited = True
                Me.lnkPoly.LinkVisited = False
            Else
                Me.lnkComplex.LinkVisited = False
                Me.lnkPoly.LinkVisited = True
            End If
        End Set
    End Property
    Enum Workfields As Byte
        Complex
        Polynom
    End Enum

    Public ReadOnly Property ActiveDocument() As Document
        Get
            If TypeOf Me.ActiveMdiChild Is Document Then
                Return CType(Me.ActiveMdiChild, Document)
            Else

                Return Me.MdiChildren(0)
            End If
        End Get
     
    End Property
    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New Document
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me
        m_ChildFormNumber += 1
        ChildForm.Text = "MathDocument " & m_ChildFormNumber
        ChildForm.AddLine(sender, e)
        ChildForm.ActiveLine = ChildForm.Controls(0)
        ChildForm.Show()
    End Sub

    Private Sub open(ByVal FileName As String)
        Dim Doc As New Document
        Doc.Text = FileName.Substring(FileName.LastIndexOf("\") + 1, FileName.Length - FileName.LastIndexOf("\") - 1).Replace(".Gbr", "")
        Doc.Open(FILEname)
        Doc.MdiParent = Me
        Doc.FileName = FileName
        Doc.Show()

    End Sub
    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Algebra Claculations File Files (*.Gbr)|*.Gbr"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            open(FileName)
        End If
        Me.ActiveDocument.isModified = False
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Algebra Claculations File Files (*.Gbr)|*.Gbr"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            Me.ActiveDocument.Save(FileName)
        End If
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
        '' <Dr> sorry no time for this . we will send the object to a local clipboard ''

        ClipBoard = Me.ActiveDocument.SelectedControl

        Me.ActiveDocument.ActiveLine.SymFlow.Controls.Remove(ClipBoard)


    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
        ClipBoard = Me.ActiveDocument.SelectedControl
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
        Dim mycopy As Control = Nothing
        If TypeOf ClipBoard Is VMatrix Then
            CType(ClipBoard, VMatrix).LoadNumbers()
            mycopy = New VMatrix(CType(ClipBoard, VMatrix).Matrix)
            CType(mycopy, VMatrix).LoadItems()
        ElseIf TypeOf ClipBoard Is VMatrix Then
            mycopy = New VOperator() With {.Text = CType(ClipBoard, VOperator).Text}
        End If
        Me.ActiveDocument.ActiveLine.AddElement(mycopy, Nothing)

    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer


    Private Sub Mainfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Activate()
        If My.Application.CommandLineArgs.Count <> 0 Then
            open(My.Application.CommandLineArgs(0))
        Else
            Me.ShowNewForm(sender, e)
        End If

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.CalculateLineToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub MatrixToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MatrixToolStripMenuItem.Click
        Me.ActiveDocument.ActiveLine.AddMatrix(Nothing)
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click, ToolStripMenuItem3.Click, ToolStripMenuItem2.Click
        Dim myop As New VOperator With {.text = sender.text}
        Me.ActiveDocument.ActiveLine.AddElement(myop, Nothing)
    End Sub

    Private Sub CalculateLineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculateLineToolStripMenuItem.Click
        Me.ActiveDocument.Calculate()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Me.ActiveDocument.DeleteSelected()
    End Sub

    Private Sub NumberDecimalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PowerintegerToolStripMenuItem.Click, NumberDecimalToolStripMenuItem.Click
        Dim a As New VInput(sender.text = "Power")
        Me.ActiveDocument.ActiveLine.AddElement(a, Nothing)
    End Sub

    Public Sub SendError(ByVal sender As Object, ByVal msg As String)

        lstReport.Items.Add(sender.ToString & " : " & msg)
        lstReport.SetSelected(lstReport.Items.Count - 1, True)

        Me.StatusStrip.BackColor = Color.Red

    End Sub



    Sub SendMessage(ByVal msg As String)
        lstReport.Items.Add(msg)
        lstReport.SetSelected(lstReport.Items.Count - 1, True)
        Me.StatusStrip.BackColor = Color.Green

    End Sub

    Private Sub ToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip.ItemClicked

    End Sub

    Private Sub ReporterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporterToolStripMenuItem.Click
        lstReport.Visible = sender.checked
    End Sub

    Friend Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click, SaveToolStripMenuItem.Click
        If Me.ActiveDocument.FileName = "" Then
            SaveAsToolStripMenuItem_Click(sender, e)
        Else
            Me.ActiveDocument.save()

        End If
        Me.ActiveDocument.isModified = False
    End Sub

    Private Sub lnkPoly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkPoly.Click
        Me.WorkField = Workfields.Polynom
    End Sub

    Private Sub lnkComplex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkComplex.Click
        Me.WorkField = Workfields.Complex
    End Sub

    Private Sub txtClsz_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClsz.TextChanged
        If txtClsz.Text = "" Then
            My.Settings("CellSize") = 0
            VMatrix.cellSize = 0
        Else
            My.Settings("CellSize") = CInt(txtClsz.Text)
            VMatrix.cellSize = CInt(txtClsz.Text)
        End If

    End Sub



    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.Show()
    End Sub

  
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        'Me.ActiveDocument.AddLine(New MathLine)
        Dim a As New Document
        a.AddLine(New MathLine)
        a.Show()

    End Sub

    Private Sub lstReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstReport.Click
        StatusStrip.BackColor = SystemColors.Control
    End Sub

    Private Sub lstReport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstReport.SelectedIndexChanged

    End Sub

    Private Sub AdjToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjToolStripMenuItem.Click

        Dim a As New VOperator With {.Text = "Adj"}

        Me.ActiveDocument.ActiveLine.AddElement(a, Nothing)
    End Sub
End Class
