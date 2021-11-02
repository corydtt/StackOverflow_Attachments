Option Strict Off

Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Collections.Generic
Imports NXOpen
Imports NXOpen.UF
Imports NXOpen.Assemblies
Imports NXOpenUI

Module BomToExcel

Public theSession As Session = Session.GetSession()
Public ufs As UFSession = UFSession.GetUFSession()
Public theUISession As UI = UI.GetUI
Public lw As ListingWindow = theSession.ListingWindow
Const xlCenter As Long = -4108
Const xlDown As Long = -4121
Const xlUp As Long = -4162
Const xlFormulas As Long = -4123
Const xlLeft As Long = -4131
Const xlAbove As Long = 0
Const xlWhole As Long = 1
Const xlByRows As Long = 1
Const xlNext As Long = 1
Const msoTrue As Long = -1
'Const strPicFilesPath As String = "c:\partimages\"
Dim lngLevelStart(20) As Long
Dim colLevel As Integer = 1
Dim colImage As Integer = 2
Dim colID As Integer = 3
Dim colDescription As Integer = 4
Dim colQuantity As Integer = 5
Dim colParentChild As Integer = 6
Dim colParent As Integer = 7
Dim colBranchTop As Integer = 8
Dim colBranchCreated As Integer = 9
Private IsTcEng As Boolean = False
Dim lg As LogFile = theSession.LogFile
Private _notLoaded As New List(Of String)

Sub Main()
Dim dispPart As Part = theSession.Parts.Display
Dim workPart As Part = theSession.Parts.Work
Dim objExcel As Object
Dim objWorkbook As Object
Dim objWorksheet As Object

lg.WriteLine("")
lg.WriteLine("~~~~ Start of BomToExcel journal ~~~~")
lg.WriteLine("Timestamp: " & Now)
lg.WriteLine("")

'determine if we are running under TC or native
ufs.UF.IsUgmanagerActive(IsTcEng)
lg.WriteLine("TC running? " & IsTcEng)

Dim markId1 As Session.UndoMarkId
markId1 = theSession.SetUndoMark(Session.MarkVisibility.Visible, "journal")

Dim excelFileName As String
Dim excelFileExists As Boolean = False
Dim row As Long = 1
Dim column As Long = 1

'Allow the user to create a new excel file or add to an existing one.
Dim SaveFileDialog1 As New SaveFileDialog
With SaveFileDialog1
.Title = "Save BoM to Excel File"
.InitialDirectory = "Z:\NX Macros"
.Filter = "Excel files (*.xlsx)|*.xlsx|Macro enabled Excel files (*.xlsm)|*.xlsm|All files (*.*)|*.*"
.FilterIndex = 1
.RestoreDirectory = True
.OverwritePrompt = False
.FileName = (dispPart.ComponentAssembly.RootComponent.DisplayName).Replace("/", "_")
If .ShowDialog() = DialogResult.OK Then
excelFileName = .FileName
lg.WriteLine("Excel file name specified: " & .FileName)
Else
lg.WriteLine("SaveFileDialog1: user pressed cancel, journal exiting")
Exit Sub
End If
End With

'This function will not complain if the directory already exists.
'System.IO.Directory.CreateDirectory(strPicFilesPath)

'lw.Open()

'create Excel object
objExcel = CreateObject("Excel.Application")
If objExcel Is Nothing Then
theUISession.NXMessageBox.Show("Error", NXMessageBox.DialogType.Error, "Could not start Excel, journal exiting")
lg.WriteLine("Could not start Excel, journal exiting")
theSession.UndoToMark(markId1, "journal")
Exit Sub
Else
lg.WriteLine("Excel started successfully")
End If

If File.Exists(excelFileName) Then
'Open the Excel file
excelFileExists = True
objWorkbook = objExcel.Workbooks.Open(excelFileName)
lg.WriteLine("Excel file: '" & excelFileName & "' exists, opening file")
Else
'Create the Excel file
objWorkbook = objExcel.Workbooks.Add
objWorkbook.SaveAs(excelFileName)
lg.WriteLine("Excel file: '" & excelFileName & "' does not exist, creating file")
End If
If objWorkbook Is Nothing Then
lg.WriteLine("Could not open/create specified Excel file: '" & excelFileName & "'")
lg.WriteLine("journal exiting")
theUISession.NXMessageBox.Show("Error", NXMessageBox.DialogType.Error, "Could not open Excel file: " & excelFileName & ControlChars.NewLine & "journal exiting.")
theSession.UndoToMark(markId1, "journal")
Exit Sub
Else
lg.WriteLine("objWorkbook created/opened successfully")
End If

'Add a new sheet so that previously exported BoMs are not affected
objWorksheet = objWorkbook.Worksheets.Add()

'Add Column Titles
objWorksheet.Cells(1, colLevel).Value = "Level"
objWorksheet.Cells(1, colImage).EntireColumn.ColumnWidth = 10
objWorksheet.Cells(1, colImage).Value = "Blank"
objWorksheet.Cells(1, colID).Value = "ID"
objWorksheet.Cells(1, colDescription).Value = "Description"
objWorksheet.Cells(1, colQuantity).Value = "Quantity"
objWorksheet.Cells(1, colParentChild).Value = "Parent|Child"
objWorksheet.Cells(1, colParent).Value = "Parent"
objWorksheet.Cells.VerticalAlignment = xlCenter
lg.WriteLine("Column titles added")
Try
Dim c As ComponentAssembly = dispPart.ComponentAssembly
If Not IsNothing(c.RootComponent) Then
'Process 'root component' (assembly file)
Dim rootDispName As String = (c.RootComponent.DisplayName).Replace("/", "_")
lg.WriteLine("processing assembly file")
lg.WriteLine(" display name: " & c.RootComponent.DisplayName)
lg.WriteLine(" rootDispName: " & rootDispName)
lg.WriteLine("")
objWorksheet.Cells(2, colLevel).Value = 0
objWorksheet.Cells(2, colID).Value = rootDispName

If IsTcEng Then
objWorksheet.Cells(2, colDescription).Value = c.RootComponent.GetStringAttribute("DB_PART_NAME")
lg.WriteLine(" DB_PART_NAME: " & c.RootComponent.GetStringAttribute("DB_PART_NAME"))
Else
objWorksheet.cells(2, colDescription).Value = c.RootComponent.Prototype.OwningPart.Leaf
lg.WriteLine(" Part name: " & c.RootComponent.Prototype.OwningPart.Leaf)
End If

lngLevelStart(0) = 3
'Create a screenshot only if one does not already exist
'If Not File.Exists(strPicFilesPath & rootDispName & ".jpg") Then
'lg.WriteLine(" screenshot does not exist, creating: " & strPicFilesPath & rootDispName & ".jpg")
'CreateCroppedNxScreenshot()
'Else
'lg.WriteLine(" screenshot exists, using: " & strPicFilesPath & rootDispName & ".jpg")
'End If
lg.WriteLine(" calling reportComponentChildren(" & c.RootComponent.DisplayName & ", 1, objWorksheet)")
reportComponentChildren(c.RootComponent, 1, objWorksheet)
Dim partLoadStatus1 As PartLoadStatus
Dim status1 As PartCollection.SdpsStatus
status1 = theSession.Parts.SetDisplay(dispPart, False, False, partLoadStatus1)
partLoadStatus1.Dispose()
Else
'Process a piece part
End If
Catch e As Exception
theSession.ListingWindow.WriteLine("Failed: " & e.ToString)
lg.WriteLine("process root component error: ")
lg.WriteLine(" " & e.Message)
End Try

objWorksheet.Cells.EntireColumn.AutoFit()

'Some variables required within excel
Dim rngStart As Object
Dim rngEnd As Object
Dim intIndent As Single
Dim intLeft As Single
Dim intTopRow As Integer
Dim i As Integer
Dim j As Integer
Dim lngStart As Long
Dim lngLevel As Long
Dim lngLastRow As Long
intIndent = 6.75
lngLastRow = objWorksheet.Cells(2, colLevel).End(xlDown).Row

'####### Add pictures to excel structure ################
'####### End Add pictures to excel structure ################

'####### Add groupings to excel structure ################
With objWorksheet.Outline
.AutomaticStyles = False
.SummaryRow = xlAbove
.SummaryColumn = xlLeft
End With
For j = 8 To 1 Step -1
lngStart = 0
'Loop through rows
For i = 2 To lngLastRow
lngLevel = Int(objWorksheet.Cells(i, colLevel).Value)
If lngLevel = j And lngStart = 0 Then
lngStart = i
ElseIf lngLevel < j And lngStart > 0 Then
objWorksheet.Rows(lngStart & ":" & i - 1).EntireRow.Group()
lngStart = 0
ElseIf i = lngLastRow And lngStart > 0 Then
objWorksheet.Rows(lngStart & ":" & i).EntireRow.Group()
lngStart = 0
End If
Next i
Next j
'####### End Add groupings to excel structure ################

'####### Add branches to excel structure ################
For i = objWorksheet.Cells(3, colBranchTop).End(xlDown).Row To 3 Step -1
intTopRow = objWorksheet.Cells(i, colBranchTop).Value
rngEnd = objWorksheet.Cells(i, colID)
intLeft = rngEnd.offset(0, -1).Left + intIndent * (rngEnd.IndentLevel - 0.5)
If objWorksheet.Cells(intTopRow, colBranchCreated).Value <> 1 Then
'This is the first line with that parent, so need to draw a vertical line
rngStart = objWorksheet.Cells(intTopRow, colID)
With objWorksheet.Shapes.AddLine(intLeft, CSng(rngStart.Top), intLeft, CSng(rngEnd.Top + rngEnd.Height / 2))
.Line.Weight = 1.5
.Line.ForeColor.RGB = 0
End With
objWorksheet.Cells(intTopRow, colBranchCreated).Value = 1
End If
'Draw a horizontal line
With objWorksheet.Shapes.AddLine(intLeft, CSng(rngEnd.Top + rngEnd.Height / 2), intLeft + intIndent / 2, CSng(rngEnd.Top + rngEnd.Height / 2))
.Line.Weight = 1.5
.Line.ForeColor.RGB = 0
End With
Next i
objWorksheet.Cells(1, colLevel).EntireColumn.Delete()
objWorksheet.Cells(1, colParentChild).EntireColumn.Delete()
objWorksheet.Cells(1, colParent).EntireColumn.Delete()
objWorksheet.Cells(1, colBranchTop).EntireColumn.Delete()
objWorksheet.Cells(1, colBranchCreated).EntireColumn.Delete()
'####### End Add branches to excel structure ############

'lw.Close()

If excelFileExists Then
theUISession.NXMessageBox.Show("BoM to Excel Complete", NXMessageBox.DialogType.Information, "A new sheet has been added to the Excel file: " & excelFileName & ".")
Else
theUISession.NXMessageBox.Show("BoM to Excel Complete", NXMessageBox.DialogType.Information, "The Excel file: " & excelFileName & " has been created.")
End If

If _notLoaded.Count > 0 Then
lw.WriteLine("Warning: BOM information is incomplete!")
lw.WriteLine("The following components could not be loaded:")
For Each compName As String In _notLoaded
lw.WriteLine(" " & compName)
Next
End If

objWorkbook.Save()
objWorkbook.Close()
objExcel.Quit()
objWorksheet = Nothing
objWorkbook = Nothing
objExcel = Nothing

lg.WriteLine(" ~~~ End of BomToExcel journal ~~~ ")
lg.WriteLine(" timestamp: " & Now)
lg.WriteLine("")

End Sub

'**********************************************************
Sub reportComponentChildren(ByVal comp As Component, _
ByVal indent As Integer, ByRef xlsWorkSheet As Object)

lg.WriteLine("")
lg.WriteLine(" reportComponentChildren(" & comp.DisplayName & ", " & "indent: " & indent & ")")
lg.WriteLine(" component path: " & comp.Prototype.OwningPart.FullPath)

If Not LoadComponent(comp) Then
Return
End If

Dim compDispName As String = (comp.DisplayName).Replace("/", "_")
Dim childDispName As String

lg.WriteLine(" comp.DisplayName: " & comp.DisplayName)
lg.WriteLine(" compDispName: " & compDispName)

Dim strFindString As String
Dim intWriteRow As Integer
'Dim doSearch As Boolean = False
If lngLevelStart(indent) = 0 Then lngLevelStart(indent) = xlsWorkSheet.Cells(1, 1).end(xlDown).offset(1, 0).Row
lg.WriteLine(" lngLevelStart(" & indent.ToString & ") = " & lngLevelStart(indent).ToString)

For Each child As Component In comp.GetChildren()

childDispName = (child.DisplayName).Replace("/", "_")

lg.WriteLine(" *processing child component: " & child.Prototype.OwningPart.Leaf)
lg.WriteLine(" childDispName: " & childDispName)
'Search for Parent|Child to see if it already exists.
strFindString = compDispName & "|" & childDispName
lg.WriteLine(" strFindString = " & strFindString)
'On Error Resume Next

Dim searchRange As Object = Nothing
Dim foundRange As Object = Nothing
Dim lngFoundInRow As Long = -1
Dim doSearch As Boolean = False

Try
lg.WriteLine(" xlsWorkSheet.Cells(" & indent.ToString & ", " & colParentChild.ToString & ").Value = " & """" & xlsWorkSheet.Cells(lngLevelStart(indent), colParentChild).Value & """")
If xlsWorkSheet.Cells(lngLevelStart(indent), colParentChild).Value = "" Then
'no data entered to search yet
lg.WriteLine(" no data available for search")
Else
If xlsWorkSheet.Cells(lngLevelStart(indent), colParentChild).Offset(1).Value = "" Then
'only 1 value entered
searchRange = xlsWorkSheet.Cells(lngLevelStart(indent), colParentChild)
doSearch = True
lg.WriteLine(" number of rows available for search: " & searchRange.Rows.Count.ToString)
Else
'2 or more values entered, select them all
searchRange = xlsWorkSheet.Range(xlsWorkSheet.Cells(lngLevelStart(indent), colParentChild), xlsWorkSheet.Cells(lngLevelStart(indent), colParentChild).End(xlDown))
doSearch = True
lg.WriteLine(" number of rows available for search: " & searchRange.Rows.Count.ToString)
End If

End If

lg.WriteLine(" doSearch = " & doSearch.ToString)
If doSearch Then
foundRange = searchRange.Find(strFindString, , xlFormulas, xlWhole, xlByRows, xlNext, False, , )
End If

If IsNothing(foundRange) Then
lg.WriteLine(" foundRange is Nothing")
Else
lngFoundInRow = foundRange.Row
lg.WriteLine(" lngFoundInRow = " & lngFoundInRow.ToString)
End If

Catch ex As Exception
lg.WriteLine(" ** excel search error")
lg.WriteLine(" ** " & ex.Message)
End Try

'If Not lngFoundInRow = 0 Then
If lngFoundInRow > -1 Then

lg.WriteLine(" found in row: " & lngFoundInRow.ToString & ", adding to quantity")
xlsWorkSheet.Cells(lngFoundInRow, colQuantity).Value = xlsWorkSheet.Cells(lngFoundInRow, colQuantity).Value + 1
lg.WriteLine(" new quantity: " & (xlsWorkSheet.cells(lngFoundInRow, colQuantity).Value).ToString)
lg.WriteLine("")
Else
lg.WriteLine(" not found, creating new record")
'Add new component or subassembly
intWriteRow = xlsWorkSheet.Cells(1, 1).end(xlDown).offset(1, 0).Row
xlsWorkSheet.Cells(intWriteRow, colLevel).Value = indent
xlsWorkSheet.Cells(intWriteRow, colID).Value = childDispName
xlsWorkSheet.Cells(intWriteRow, colID).IndentLevel = indent

If IsTcEng Then
xlsWorkSheet.Cells(intWriteRow, colDescription).Value = child.GetStringAttribute("DB_PART_NAME")
Else
xlsWorkSheet.cells(intWriteRow, colDescription).Value = child.Prototype.OwningPart.Leaf
End If

xlsWorkSheet.Cells(intWriteRow, colQuantity).Value = child.GetIntegerQuantity
xlsWorkSheet.Cells(intWriteRow, colParentChild).Value = strFindString
xlsWorkSheet.Cells(intWriteRow, colParent).Value = compDispName
xlsWorkSheet.Cells(intWriteRow, colBranchTop).Value = lngLevelStart(indent)
'Create a screenshot only if one does not already exist
'If Not File.Exists(strPicFilesPath & childDispName & ".jpg") Then

'lg.WriteLine(" screenshot does not exist, creating: " & strPicFilesPath & childDispName & ".jpg")

Dim Part1 As Part
If IsTcEng Then
Part1 = CType(theSession.Parts.FindObject("@DB/" & child.GetStringAttribute("DB_PART_NO") & "/" & child.GetStringAttribute("DB_PART_REV")), Part)
lg.WriteLine(" Part1: " & "@DB/" & child.GetStringAttribute("DB_PART_NO") & "/" & child.GetStringAttribute("DB_PART_REV"))
Else
Part1 = child.Prototype.OwningPart
lg.WriteLine(" Part1: " & Part1.FullPath)
End If

Dim partLoadStatus1 As PartLoadStatus
Dim status1 As PartCollection.SdpsStatus
status1 = theSession.Parts.SetDisplay(Part1, True, True, partLoadStatus1)
'++If child.GetNonGeometricState OrElse child.IsSuppressed Then
'if .GetNonGeometricState = True, comp is set as 'non-geometric'
'skip screenshot
'++Else
'++CreateCroppedNxScreenshot()
'++End If
partLoadStatus1.Dispose()
'Else
'lg.WriteLine(" screenshot exists, using: " & strPicFilesPath & childDispName & ".jpg")
'End If
lg.WriteLine("")
reportComponentChildren(child, indent + 1, xlsWorkSheet)
'On Error GoTo 0
End If
Next
lngLevelStart(indent) = 0

lg.WriteLine(" End of processing component: " & comp.DisplayName)
lg.WriteLine("")

End Sub

Private Function LoadComponent(ByVal theComponent As Component) As Boolean

lg.WriteLine("Sub LoadComponent()")

Dim thePart As Part = theComponent.Prototype.OwningPart

Dim partName As String = ""
Dim refsetName As String = ""
Dim instanceName As String = ""
Dim origin(2) As Double
Dim csysMatrix(8) As Double
Dim transform(3, 3) As Double

Try
If thePart.IsFullyLoaded Then
'component is fully loaded
Else
'component is partially loaded
End If
lg.WriteLine(" component: " & theComponent.DisplayName & " is already partially or fully loaded")
lg.WriteLine(" return: True")
lg.WriteLine("exiting Sub LoadComponent()")
lg.WriteLine("")
Return True
Catch ex As NullReferenceException
'component is not loaded
Try
lg.WriteLine(" component not loaded, retrieving part information")
ufs.Assem.AskComponentData(theComponent.Tag, partName, refsetName, instanceName, origin, csysMatrix, transform)
lg.WriteLine(" component part file: " & partName)

Dim theLoadStatus As PartLoadStatus
theSession.Parts.Open(partName, theLoadStatus)

If theLoadStatus.NumberUnloadedParts > 0 Then
If theLoadStatus.NumberUnloadedParts > 1 Then
lg.WriteLine(" problem loading " & theLoadStatus.NumberUnloadedParts.ToString & " components")
Else
lg.WriteLine(" problem loading 1 component")
End If

Dim allReadOnly As Boolean = True
For i As Integer = 0 To theLoadStatus.NumberUnloadedParts - 1
lg.WriteLine("part name: " & theLoadStatus.GetPartName(i))
lg.WriteLine("part status: " & theLoadStatus.GetStatus(i))
If theLoadStatus.GetStatus(i) = 641058 Then
'read-only warning, file loaded ok
Else
'641044: file not found
allReadOnly = False
If Not _notLoaded.Contains(partName) Then
_notLoaded.Add(partName)
End If
End If
lg.WriteLine("status description: " & theLoadStatus.GetStatusDescription(i))
lg.WriteLine("")
Next
If allReadOnly Then
lg.WriteLine(" 'read-only' warnings only")
lg.WriteLine(" return: True")
Return True
Else
'warnings other than read-only...
lg.WriteLine(" return: False")
lg.WriteLine("exiting Sub LoadComponent()")
lg.WriteLine("")
Return False
End If
Else
lg.WriteLine(" component(s) loaded successfully")
lg.WriteLine(" return: True")
lg.WriteLine("exiting Sub LoadComponent()")
lg.WriteLine("")
Return True
End If

Catch ex2 As NXException
lg.WriteLine(" Load error: " & ex2.Message)
lg.WriteLine(" error code: " & ex2.ErrorCode)
lg.WriteLine(" return: False")
lg.WriteLine("exiting Sub LoadComponent()")
lg.WriteLine("")
If ex2.Message.ToLower = "file not found" Then
If Not _notLoaded.Contains(partName) Then
_notLoaded.Add(partName)
End If
End If
Return False
End Try
Catch ex As NXException
'unexpected error
lg.WriteLine(" Error in Sub LoadComponent: " & ex.Message)
lg.WriteLine(" return: False")
lg.WriteLine("exiting Sub LoadComponent()")
lg.WriteLine("")
Return False
End Try

End Function

End Module