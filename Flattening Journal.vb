' NX 1953
' Journal created by coryd on Fri Nov  5 09:12:36 2021 Central Daylight Time
'
Imports System
Imports NXOpen

Module NXJournal
Sub Main (ByVal args() As String) 

Dim theSession As NXOpen.Session = NXOpen.Session.GetSession()
Dim workPart As NXOpen.Part = theSession.Parts.Work

Dim displayPart As NXOpen.Part = theSession.Parts.Display

Dim scaleAboutPoint1 As NXOpen.Point3d = New NXOpen.Point3d(-48.180529145946345, 22.360426980809542, 0.0)
Dim viewCenter1 As NXOpen.Point3d = New NXOpen.Point3d(48.180529145946309, -22.360426980809542, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(1.25, scaleAboutPoint1, viewCenter1)

' ----------------------------------------------
'   Menu: Application->Design->Sheet Metal
' ----------------------------------------------
Dim markId1 As NXOpen.Session.UndoMarkId = Nothing
markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Enter Sheet Metal")

theSession.ApplicationSwitchImmediate("UG_APP_SBSM")

theSession.CleanUpFacetedFacesAndEdges()

' ----------------------------------------------
'   Menu: Insert->Convert->Convert to Sheet Metal...
' ----------------------------------------------
Dim markId2 As NXOpen.Session.UndoMarkId = Nothing
markId2 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start")

Dim nullNXOpen_Features_Feature As NXOpen.Features.Feature = Nothing

Dim convertToSheetmetalBuilder1 As NXOpen.Features.SheetMetal.ConvertToSheetmetalBuilder = Nothing
convertToSheetmetalBuilder1 = workPart.Features.SheetmetalManager.CreateConvertToSheetmetalFeatureBuilder(nullNXOpen_Features_Feature)

convertToSheetmetalBuilder1.SetApplicationContext(NXOpen.Features.SheetMetal.ApplicationContext.NxSheetMetal)

Dim expression1 As NXOpen.Expression = Nothing
expression1 = workPart.Preferences.PartSheetmetal.GetBendReliefDepth()

Dim expression2 As NXOpen.Expression = Nothing
expression2 = workPart.Preferences.PartSheetmetal.GetBendReliefWidth()

Dim nullNXOpen_Features_SketchFeature As NXOpen.Features.SketchFeature = Nothing

convertToSheetmetalBuilder1.Sketch = nullNXOpen_Features_SketchFeature

Dim nullNXOpen_Face As NXOpen.Face = Nothing

convertToSheetmetalBuilder1.BaseFace = nullNXOpen_Face

Dim nullNXOpen_Section As NXOpen.Section = Nothing

convertToSheetmetalBuilder1.RipSection = nullNXOpen_Section

Dim scCollector1 As NXOpen.ScCollector = Nothing
scCollector1 = convertToSheetmetalBuilder1.AdditionalFacesToConvert

Dim face1 As NXOpen.Face = Nothing
face1 = convertToSheetmetalBuilder1.LocalBaseFace

Dim scCollector2 As NXOpen.ScCollector = Nothing
scCollector2 = convertToSheetmetalBuilder1.LocalRegionFaces

Dim expression3 As NXOpen.Expression = Nothing
expression3 = workPart.Preferences.PartSheetmetal.GetBendReliefDepth()

Dim expression4 As NXOpen.Expression = Nothing
expression4 = workPart.Preferences.PartSheetmetal.GetBendReliefWidth()

convertToSheetmetalBuilder1.BendReliefType = NXOpen.Features.SheetMetal.ConvertToSheetmetalBuilder.BendReliefTypeOptions.None

Dim expression5 As NXOpen.Expression = Nothing
expression5 = convertToSheetmetalBuilder1.BendReliefDepth

Dim expression6 As NXOpen.Expression = Nothing
expression6 = workPart.Preferences.PartSheetmetal.GetBendReliefDepth()

Dim name1 As String = Nothing
name1 = expression6.Name

expression5.RightHandSide = name1

Dim expression7 As NXOpen.Expression = Nothing
expression7 = convertToSheetmetalBuilder1.BendReliefWidth

Dim expression8 As NXOpen.Expression = Nothing
expression8 = workPart.Preferences.PartSheetmetal.GetBendReliefWidth()

Dim name2 As String = Nothing
name2 = expression8.Name

expression7.RightHandSide = name2

convertToSheetmetalBuilder1.MaintainZeroBendRadius = False

Dim convertInputListItemBuilderList1 As NXOpen.Features.SheetMetal.ConvertInputListItemBuilderList = Nothing
convertInputListItemBuilderList1 = convertToSheetmetalBuilder1.CornerList

theSession.SetUndoMarkName(markId2, "Convert to Sheet Metal Dialog")

Dim section1 As NXOpen.Section = Nothing
section1 = workPart.Sections.CreateSection(0.00037401574803149601, 0.0003937007874015748, 0.5)

Dim convertInputListItemBuilder1 As NXOpen.Features.SheetMetal.ConvertInputListItemBuilder = Nothing
convertInputListItemBuilder1 = convertToSheetmetalBuilder1.CreateConvertInputListItem()

convertInputListItemBuilderList1.Append(convertInputListItemBuilder1)

Dim markId3 As NXOpen.Session.UndoMarkId = Nothing
markId3 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Convert to Sheet Metal")

theSession.DeleteUndoMark(markId3, Nothing)

Dim markId4 As NXOpen.Session.UndoMarkId = Nothing
markId4 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Convert to Sheet Metal")

Dim brep1 As NXOpen.Features.Brep = CType(workPart.Features.FindObject("UNPARAMETERIZED_FEATURE(1)"), NXOpen.Features.Brep)

Dim face2 As NXOpen.Face = CType(brep1.FindObject("FACE 187 {(0.061413307086,33.2677165354331,-13.5580989295608) UNPARAMETERIZED_FEATURE(1)}"), NXOpen.Face)

convertToSheetmetalBuilder1.BaseFace = face2

Dim ripEdges1(-1) As NXOpen.Edge
convertToSheetmetalBuilder1.SetRipEdges(ripEdges1)

convertToSheetmetalBuilder1.Sketch = nullNXOpen_Features_SketchFeature

convertToSheetmetalBuilder1.RipSection = section1

convertToSheetmetalBuilder1.MaintainZeroBendRadius = False

Dim builderDataValidity1 As Integer = Nothing
builderDataValidity1 = convertToSheetmetalBuilder1.ValidateBuilderData()

Dim feature1 As NXOpen.Features.Feature = Nothing
feature1 = convertToSheetmetalBuilder1.CommitFeature()

theSession.DeleteUndoMark(markId4, Nothing)

theSession.SetUndoMarkName(markId2, "Convert to Sheet Metal")

convertToSheetmetalBuilder1.Destroy()

section1.Destroy()

theSession.CleanUpFacetedFacesAndEdges()

' ----------------------------------------------
'   Menu: Insert->Flat Pattern->Flat Solid...
' ----------------------------------------------
Dim markId5 As NXOpen.Session.UndoMarkId = Nothing
markId5 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start")

Dim flatSolidBuilder1 As NXOpen.Features.SheetMetal.FlatSolidBuilder = Nothing
flatSolidBuilder1 = workPart.Features.SheetmetalManager.CreateFlatSolidFeatureBuilder(nullNXOpen_Features_Feature)

flatSolidBuilder1.SetApplicationContext(NXOpen.Features.SheetMetal.ApplicationContext.NxSheetMetal)

flatSolidBuilder1.OuterCornerTreatment.Value.SetFormula("0.0999998")

flatSolidBuilder1.InnerCornerTreatment.Value.SetFormula("0.0999998")

theSession.SetUndoMarkName(markId5, "Flat Solid Dialog")

Dim innerCornerTreatmentType1 As NXOpen.Features.SheetMetal.FeatureProperty = Nothing
innerCornerTreatmentType1 = workPart.Preferences.PartSheetmetal.GetInnerCornerTreatmentType()

Dim cornerTreatmentBuilder1 As NXOpen.Features.SheetMetal.CornerTreatmentBuilder = Nothing
cornerTreatmentBuilder1 = flatSolidBuilder1.InnerCornerTreatment

cornerTreatmentBuilder1.TreatmentType = NXOpen.Features.SheetMetal.CornerTreatmentBuilder.CornerTreatmentType.None

Dim expression9 As NXOpen.Expression = Nothing
expression9 = cornerTreatmentBuilder1.Value

Dim expression10 As NXOpen.Expression = Nothing
expression10 = workPart.Preferences.PartSheetmetal.GetInnerCornerTreatmentValue()

Dim name3 As String = Nothing
name3 = expression10.Name

expression9.RightHandSide = name3

Dim outerCornerTreatmentType1 As NXOpen.Features.SheetMetal.FeatureProperty = Nothing
outerCornerTreatmentType1 = workPart.Preferences.PartSheetmetal.GetOuterCornerTreatmentType()

Dim cornerTreatmentBuilder2 As NXOpen.Features.SheetMetal.CornerTreatmentBuilder = Nothing
cornerTreatmentBuilder2 = flatSolidBuilder1.OuterCornerTreatment

cornerTreatmentBuilder2.TreatmentType = NXOpen.Features.SheetMetal.CornerTreatmentBuilder.CornerTreatmentType.None

Dim expression11 As NXOpen.Expression = Nothing
expression11 = cornerTreatmentBuilder2.Value

Dim expression12 As NXOpen.Expression = Nothing
expression12 = workPart.Preferences.PartSheetmetal.GetOuterCornerTreatmentValue()

Dim name4 As String = Nothing
name4 = expression12.Name

expression11.RightHandSide = name4

flatSolidBuilder1.StationaryFace.Value = face2

Dim selectFace1 As NXOpen.SelectFace = Nothing
selectFace1 = flatSolidBuilder1.StationaryFace

selectFace1.Value = face2

expression11.SetFormula(name4)

expression9.SetFormula(name3)

Dim markId6 As NXOpen.Session.UndoMarkId = Nothing
markId6 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Flat Solid")

theSession.DeleteUndoMark(markId6, Nothing)

Dim markId7 As NXOpen.Session.UndoMarkId = Nothing
markId7 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Flat Solid")

Dim feature2 As NXOpen.Features.Feature = Nothing
feature2 = flatSolidBuilder1.CommitFeature()

theSession.DeleteUndoMark(markId7, Nothing)

theSession.SetUndoMarkName(markId5, "Flat Solid")

flatSolidBuilder1.Destroy()

theSession.CleanUpFacetedFacesAndEdges()

Dim scaleAboutPoint2 As NXOpen.Point3d = New NXOpen.Point3d(-14.945796796293568, 1.514973554400121, 0.0)
Dim viewCenter2 As NXOpen.Point3d = New NXOpen.Point3d(14.945796796293536, -1.514973554400121, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(1.25, scaleAboutPoint2, viewCenter2)

Dim scaleAboutPoint3 As NXOpen.Point3d = New NXOpen.Point3d(-11.956637437034866, 1.0721351308062395, 0.0)
Dim viewCenter3 As NXOpen.Point3d = New NXOpen.Point3d(11.956637437034823, -1.0721351308062395, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(1.25, scaleAboutPoint3, viewCenter3)

Dim scaleAboutPoint4 As NXOpen.Point3d = New NXOpen.Point3d(-9.5653099496278919, 0.8577081046449917, 0.0)
Dim viewCenter4 As NXOpen.Point3d = New NXOpen.Point3d(9.5653099496278546, -0.8577081046449917, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(1.25, scaleAboutPoint4, viewCenter4)

Dim scaleAboutPoint5 As NXOpen.Point3d = New NXOpen.Point3d(-7.652247959702315, 0.68616648371599342, 0.0)
Dim viewCenter5 As NXOpen.Point3d = New NXOpen.Point3d(7.6522479597022812, -0.68616648371599342, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(1.25, scaleAboutPoint5, viewCenter5)

' ----------------------------------------------
'   Menu: Edit->Show and Hide->Hide...
' ----------------------------------------------
Dim markId8 As NXOpen.Session.UndoMarkId = Nothing
markId8 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Hide")

Dim objects1(0) As NXOpen.DisplayableObject
Dim body1 As NXOpen.Body = CType(workPart.Bodies.FindObject("UNPARAMETERIZED_FEATURE(1)"), NXOpen.Body)

objects1(0) = body1
theSession.DisplayManager.BlankObjects(objects1)

workPart.ModelingViews.WorkView.FitAfterShowOrHide(NXOpen.View.ShowOrHideType.HideOnly)

Dim matrix1 As NXOpen.Matrix3x3 = Nothing
matrix1.Xx = 1.0
matrix1.Xy = 0.0
matrix1.Xz = 0.0
matrix1.Yx = -0.0
matrix1.Yy = 0.0
matrix1.Yz = 1.0
matrix1.Zx = 0.0
matrix1.Zy = -1.0
matrix1.Zz = 0.0
workPart.ModelingViews.WorkView.Orient(matrix1)

Dim scaleAboutPoint6 As NXOpen.Point3d = New NXOpen.Point3d(-12.828329912951238, -0.62053316788228974, 0.0)
Dim viewCenter6 As NXOpen.Point3d = New NXOpen.Point3d(12.828329912951208, 0.62053316788228974, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(0.80000000000000004, scaleAboutPoint6, viewCenter6)

Dim scaleAboutPoint7 As NXOpen.Point3d = New NXOpen.Point3d(-16.184579018083827, -0.95466641212659953, 0.0)
Dim viewCenter7 As NXOpen.Point3d = New NXOpen.Point3d(16.184579018083802, 0.95466641212659953, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(0.80000000000000004, scaleAboutPoint7, viewCenter7)

Dim scaleAboutPoint8 As NXOpen.Point3d = New NXOpen.Point3d(-20.230723772604787, -1.1933330151582495, 0.0)
Dim viewCenter8 As NXOpen.Point3d = New NXOpen.Point3d(20.230723772604748, 1.1933330151582495, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(0.80000000000000004, scaleAboutPoint8, viewCenter8)

Dim scaleAboutPoint9 As NXOpen.Point3d = New NXOpen.Point3d(-25.3350192866606, -1.3052079853293352, 0.0)
Dim viewCenter9 As NXOpen.Point3d = New NXOpen.Point3d(25.335019286660557, 1.3052079853293352, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(0.80000000000000004, scaleAboutPoint9, viewCenter9)

Dim scaleAboutPoint10 As NXOpen.Point3d = New NXOpen.Point3d(-45.886218234234626, -5.5937485085542944, 0.0)
Dim viewCenter10 As NXOpen.Point3d = New NXOpen.Point3d(45.88621823423459, 5.5937485085542944, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(1.25, scaleAboutPoint10, viewCenter10)

Dim scaleAboutPoint11 As NXOpen.Point3d = New NXOpen.Point3d(-36.708974587387701, -4.474998806843435, 0.0)
Dim viewCenter11 As NXOpen.Point3d = New NXOpen.Point3d(36.708974587387658, 4.474998806843435, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(1.25, scaleAboutPoint11, viewCenter11)

Dim scaleAboutPoint12 As NXOpen.Point3d = New NXOpen.Point3d(-29.44176298335756, -3.5799990454747479, 0.0)
Dim viewCenter12 As NXOpen.Point3d = New NXOpen.Point3d(29.44176298335751, 3.5799990454747479, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(1.25, scaleAboutPoint12, viewCenter12)

Dim scaleAboutPoint13 As NXOpen.Point3d = New NXOpen.Point3d(-23.553410386686043, -2.8639992363797977, 0.0)
Dim viewCenter13 As NXOpen.Point3d = New NXOpen.Point3d(23.553410386686004, 2.8639992363797977, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(1.25, scaleAboutPoint13, viewCenter13)

Dim scaleAboutPoint14 As NXOpen.Point3d = New NXOpen.Point3d(-18.890461629955166, -2.2434660684975078, 0.0)
Dim viewCenter14 As NXOpen.Point3d = New NXOpen.Point3d(18.89046162995513, 2.2434660684975078, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(1.25, scaleAboutPoint14, viewCenter14)

Dim scaleAboutPoint15 As NXOpen.Point3d = New NXOpen.Point3d(-13.661276357531701, -0.43914654957823557, 0.0)
Dim viewCenter15 As NXOpen.Point3d = New NXOpen.Point3d(13.661276357531658, 0.43914654957823557, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(0.80000000000000004, scaleAboutPoint15, viewCenter15)

Dim scaleAboutPoint16 As NXOpen.Point3d = New NXOpen.Point3d(-17.004995466005127, -0.3579999045474746, 0.0)
Dim viewCenter16 As NXOpen.Point3d = New NXOpen.Point3d(17.004995466005081, 0.3579999045474746, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(0.80000000000000004, scaleAboutPoint16, viewCenter16)

Dim scaleAboutPoint17 As NXOpen.Point3d = New NXOpen.Point3d(-21.136911030990579, -0.14916662689478113, 0.0)
Dim viewCenter17 As NXOpen.Point3d = New NXOpen.Point3d(21.136911030990539, 0.14916662689478113, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(0.80000000000000004, scaleAboutPoint17, viewCenter17)

Dim scaleAboutPoint18 As NXOpen.Point3d = New NXOpen.Point3d(-26.383847132014509, 0.0, 0.0)
Dim viewCenter18 As NXOpen.Point3d = New NXOpen.Point3d(26.383847132014473, 0.0, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(0.80000000000000004, scaleAboutPoint18, viewCenter18)

Dim scaleAboutPoint19 As NXOpen.Point3d = New NXOpen.Point3d(-32.886579773208894, 0.41953113814157184, 0.0)
Dim viewCenter19 As NXOpen.Point3d = New NXOpen.Point3d(32.886579773208872, -0.41953113814157184, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(0.80000000000000004, scaleAboutPoint19, viewCenter19)

Dim scaleAboutPoint20 As NXOpen.Point3d = New NXOpen.Point3d(-40.758615434726472, 1.5732417680308941, 0.0)
Dim viewCenter20 As NXOpen.Point3d = New NXOpen.Point3d(40.758615434726444, -1.5732417680308941, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(0.80000000000000004, scaleAboutPoint20, viewCenter20)

Dim scaleAboutPoint21 As NXOpen.Point3d = New NXOpen.Point3d(-59.397160269870334, 29.935294752810169, 0.0)
Dim viewCenter21 As NXOpen.Point3d = New NXOpen.Point3d(59.397160269870298, -29.935294752810201, 0.0)
workPart.ModelingViews.WorkView.ZoomAboutPoint(1.25, scaleAboutPoint21, viewCenter21)

' ----------------------------------------------
'   Menu: Analysis->Measure...
' ----------------------------------------------
Dim markId9 As NXOpen.Session.UndoMarkId = Nothing
markId9 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start")

theSession.SetUndoMarkName(markId9, "Measure Dialog")

workPart.MeasureManager.SetPartTransientModification()

Dim scCollector3 As NXOpen.ScCollector = Nothing
scCollector3 = workPart.ScCollectors.CreateCollector()

scCollector3.SetMultiComponent()

workPart.MeasureManager.SetPartTransientModification()

Dim selectionIntentRuleOptions1 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions1 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions1.SetSelectedFromInactive(False)

Dim faces1(0) As NXOpen.Face
Dim brep2 As NXOpen.Features.Brep = CType(workPart.Features.FindObject("UNPARAMETERIZED_FEATURE(10)"), NXOpen.Features.Brep)

Dim face3 As NXOpen.Face = CType(brep2.FindObject("FACE 1 {(9.6932566993819,32.3228346456693,-4.7126377952756) UNPARAMETERIZED_FEATURE(10)}"), NXOpen.Face)

faces1(0) = face3
Dim faceDumbRule1 As NXOpen.FaceDumbRule = Nothing
faceDumbRule1 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces1, selectionIntentRuleOptions1)

selectionIntentRuleOptions1.Dispose()
Dim selectionIntentRuleOptions2 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions2 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions2.SetSelectedFromInactive(False)

Dim bodies1(0) As NXOpen.Body
Dim body2 As NXOpen.Body = CType(workPart.Bodies.FindObject("UNPARAMETERIZED_FEATURE(10)"), NXOpen.Body)

bodies1(0) = body2
Dim bodyDumbRule1 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule1 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies1, True, selectionIntentRuleOptions2)

selectionIntentRuleOptions2.Dispose()
Dim selectionIntentRuleOptions3 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions3 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions3.SetSelectedFromInactive(False)

Dim edges1(3) As NXOpen.Edge
Dim edge1 As NXOpen.Edge = CType(brep2.FindObject("EDGE * -3 * 1 {(9.6932566993819,32.3228346456693,-4.8882955721546)(9.5175989225028,32.3228346456693,-4.7126377952756)(9.6932566993819,32.3228346456693,-4.5369800183965) UNPARAMETERIZED_FEATURE(10)}"), NXOpen.Edge)

edges1(0) = edge1
Dim edge2 As NXOpen.Edge = CType(brep2.FindObject("EDGE * -4 * 1 {(9.6932566993819,32.3228346456693,-4.5369800183965)(9.8689144762609,32.3228346456693,-4.7126377952756)(9.6932566993819,32.3228346456693,-4.8882955721546) UNPARAMETERIZED_FEATURE(10)}"), NXOpen.Edge)

edges1(1) = edge2
Dim edge3 As NXOpen.Edge = CType(brep2.FindObject("EDGE * -1 * 1 {(9.5948315025315,32.3228346456693,-4.7126377952756)(9.6932566993819,32.3228346456693,-4.811062992126)(9.7916818962323,32.3228346456693,-4.7126377952756) UNPARAMETERIZED_FEATURE(10)}"), NXOpen.Edge)

edges1(2) = edge3
Dim edge4 As NXOpen.Edge = CType(brep2.FindObject("EDGE * -2 * 1 {(9.7916818962323,32.3228346456693,-4.7126377952756)(9.6932566993819,32.3228346456693,-4.6142125984252)(9.5948315025315,32.3228346456693,-4.7126377952756) UNPARAMETERIZED_FEATURE(10)}"), NXOpen.Edge)

edges1(3) = edge4
Dim edgeDumbRule1 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule1 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges1, selectionIntentRuleOptions3)

selectionIntentRuleOptions3.Dispose()
Dim selectionIntentRuleOptions4 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions4 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions4.SetSelectedFromInactive(False)

Dim faces2(0) As NXOpen.Face
Dim brep3 As NXOpen.Features.Brep = CType(workPart.Features.FindObject("UNPARAMETERIZED_FEATURE(7)"), NXOpen.Features.Brep)

Dim face4 As NXOpen.Face = CType(brep3.FindObject("FACE 1 {(9.5222047244095,32.3937007874016,-25.619842519685) UNPARAMETERIZED_FEATURE(7)}"), NXOpen.Face)

faces2(0) = face4
Dim faceDumbRule2 As NXOpen.FaceDumbRule = Nothing
faceDumbRule2 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces2, selectionIntentRuleOptions4)

selectionIntentRuleOptions4.Dispose()
Dim selectionIntentRuleOptions5 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions5 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions5.SetSelectedFromInactive(False)

Dim bodies2(0) As NXOpen.Body
Dim body3 As NXOpen.Body = CType(workPart.Bodies.FindObject("UNPARAMETERIZED_FEATURE(7)"), NXOpen.Body)

bodies2(0) = body3
Dim bodyDumbRule2 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule2 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies2, True, selectionIntentRuleOptions5)

selectionIntentRuleOptions5.Dispose()
Dim selectionIntentRuleOptions6 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions6 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions6.SetSelectedFromInactive(False)

Dim edges2(3) As NXOpen.Edge
Dim edge5 As NXOpen.Edge = CType(brep3.FindObject("EDGE * -1 * 1 {(9.7148940648422,32.3937007874016,-25.619842519685)(9.5222047244094,32.3937007874016,-25.8125318601178)(9.3295153839767,32.3937007874016,-25.619842519685) UNPARAMETERIZED_FEATURE(7)}"), NXOpen.Edge)

edges2(0) = edge5
Dim edge6 As NXOpen.Edge = CType(brep3.FindObject("EDGE * -2 * 1 {(9.3295153839767,32.3937007874016,-25.619842519685)(9.5222047244094,32.3937007874016,-25.4271531792523)(9.7148940648422,32.3937007874016,-25.619842519685) UNPARAMETERIZED_FEATURE(7)}"), NXOpen.Edge)

edges2(1) = edge6
Dim edge7 As NXOpen.Edge = CType(brep3.FindObject("EDGE * -3 * 1 {(9.4237795275591,32.3937007874016,-25.619842519685)(9.5222047244094,32.3937007874016,-25.7182677165354)(9.6206299212598,32.3937007874016,-25.619842519685) UNPARAMETERIZED_FEATURE(7)}"), NXOpen.Edge)

edges2(2) = edge7
Dim edge8 As NXOpen.Edge = CType(brep3.FindObject("EDGE * -4 * 1 {(9.6206299212598,32.3937007874016,-25.619842519685)(9.5222047244094,32.3937007874016,-25.5214173228346)(9.4237795275591,32.3937007874016,-25.619842519685) UNPARAMETERIZED_FEATURE(7)}"), NXOpen.Edge)

edges2(3) = edge8
Dim edgeDumbRule2 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule2 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges2, selectionIntentRuleOptions6)

selectionIntentRuleOptions6.Dispose()
Dim selectionIntentRuleOptions7 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions7 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions7.SetSelectedFromInactive(False)

Dim faces3(0) As NXOpen.Face
Dim brep4 As NXOpen.Features.Brep = CType(workPart.Features.FindObject("UNPARAMETERIZED_FEATURE(6)"), NXOpen.Features.Brep)

Dim face5 As NXOpen.Face = CType(brep4.FindObject("FACE 1 {(0,32.3937007874016,-25.619842519685) UNPARAMETERIZED_FEATURE(6)}"), NXOpen.Face)

faces3(0) = face5
Dim faceDumbRule3 As NXOpen.FaceDumbRule = Nothing
faceDumbRule3 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces3, selectionIntentRuleOptions7)

selectionIntentRuleOptions7.Dispose()
Dim selectionIntentRuleOptions8 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions8 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions8.SetSelectedFromInactive(False)

Dim bodies3(0) As NXOpen.Body
Dim body4 As NXOpen.Body = CType(workPart.Bodies.FindObject("UNPARAMETERIZED_FEATURE(6)"), NXOpen.Body)

bodies3(0) = body4
Dim bodyDumbRule3 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule3 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies3, True, selectionIntentRuleOptions8)

selectionIntentRuleOptions8.Dispose()
Dim selectionIntentRuleOptions9 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions9 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions9.SetSelectedFromInactive(False)

Dim edges3(3) As NXOpen.Edge
Dim edge9 As NXOpen.Edge = CType(brep4.FindObject("EDGE * -1 * 1 {(0.1926893404327,32.3937007874016,-25.619842519685)(0,32.3937007874016,-25.8125318601178)(-0.1926893404327,32.3937007874016,-25.619842519685) UNPARAMETERIZED_FEATURE(6)}"), NXOpen.Edge)

edges3(0) = edge9
Dim edge10 As NXOpen.Edge = CType(brep4.FindObject("EDGE * -2 * 1 {(-0.1926893404327,32.3937007874016,-25.619842519685)(-0,32.3937007874016,-25.4271531792523)(0.1926893404327,32.3937007874016,-25.619842519685) UNPARAMETERIZED_FEATURE(6)}"), NXOpen.Edge)

edges3(1) = edge10
Dim edge11 As NXOpen.Edge = CType(brep4.FindObject("EDGE * -4 * 1 {(0,32.3937007874016,-25.7182677165354)(0.0984251968504,32.3937007874016,-25.619842519685)(0,32.3937007874016,-25.5214173228346) UNPARAMETERIZED_FEATURE(6)}"), NXOpen.Edge)

edges3(2) = edge11
Dim edge12 As NXOpen.Edge = CType(brep4.FindObject("EDGE * -3 * 1 {(0,32.3937007874016,-25.5214173228346)(-0.0984251968504,32.3937007874016,-25.619842519685)(-0,32.3937007874016,-25.7182677165354) UNPARAMETERIZED_FEATURE(6)}"), NXOpen.Edge)

edges3(3) = edge12
Dim edgeDumbRule3 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule3 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges3, selectionIntentRuleOptions9)

selectionIntentRuleOptions9.Dispose()
Dim selectionIntentRuleOptions10 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions10 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions10.SetSelectedFromInactive(False)

Dim faces4(0) As NXOpen.Face
Dim brep5 As NXOpen.Features.Brep = CType(workPart.Features.FindObject("UNPARAMETERIZED_FEATURE(5)"), NXOpen.Features.Brep)

Dim face6 As NXOpen.Face = CType(brep5.FindObject("FACE 1 {(-9.5222047244094,32.3937007874016,-25.619842519685) UNPARAMETERIZED_FEATURE(5)}"), NXOpen.Face)

faces4(0) = face6
Dim faceDumbRule4 As NXOpen.FaceDumbRule = Nothing
faceDumbRule4 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces4, selectionIntentRuleOptions10)

selectionIntentRuleOptions10.Dispose()
Dim selectionIntentRuleOptions11 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions11 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions11.SetSelectedFromInactive(False)

Dim bodies4(0) As NXOpen.Body
Dim body5 As NXOpen.Body = CType(workPart.Bodies.FindObject("UNPARAMETERIZED_FEATURE(5)"), NXOpen.Body)

bodies4(0) = body5
Dim bodyDumbRule4 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule4 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies4, True, selectionIntentRuleOptions11)

selectionIntentRuleOptions11.Dispose()
Dim selectionIntentRuleOptions12 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions12 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions12.SetSelectedFromInactive(False)

Dim edges4(3) As NXOpen.Edge
Dim edge13 As NXOpen.Edge = CType(brep5.FindObject("EDGE * -2 * 1 {(-9.7148940648422,32.3937007874016,-25.619842519685)(-9.5222047244094,32.3937007874016,-25.4271531792523)(-9.3295153839767,32.3937007874016,-25.619842519685) UNPARAMETERIZED_FEATURE(5)}"), NXOpen.Edge)

edges4(0) = edge13
Dim edge14 As NXOpen.Edge = CType(brep5.FindObject("EDGE * -1 * 1 {(-9.3295153839767,32.3937007874016,-25.619842519685)(-9.5222047244094,32.3937007874016,-25.8125318601178)(-9.7148940648422,32.3937007874016,-25.619842519685) UNPARAMETERIZED_FEATURE(5)}"), NXOpen.Edge)

edges4(1) = edge14
Dim edge15 As NXOpen.Edge = CType(brep5.FindObject("EDGE * -4 * 1 {(-9.5222047244094,32.3937007874016,-25.7182677165354)(-9.4237795275591,32.3937007874016,-25.619842519685)(-9.5222047244094,32.3937007874016,-25.5214173228346) UNPARAMETERIZED_FEATURE(5)}"), NXOpen.Edge)

edges4(2) = edge15
Dim edge16 As NXOpen.Edge = CType(brep5.FindObject("EDGE * -3 * 1 {(-9.5222047244094,32.3937007874016,-25.5214173228346)(-9.6206299212598,32.3937007874016,-25.619842519685)(-9.5222047244094,32.3937007874016,-25.7182677165354) UNPARAMETERIZED_FEATURE(5)}"), NXOpen.Edge)

edges4(3) = edge16
Dim edgeDumbRule4 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule4 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges4, selectionIntentRuleOptions12)

selectionIntentRuleOptions12.Dispose()
Dim selectionIntentRuleOptions13 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions13 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions13.SetSelectedFromInactive(False)

Dim faces5(0) As NXOpen.Face
Dim brep6 As NXOpen.Features.Brep = CType(workPart.Features.FindObject("UNPARAMETERIZED_FEATURE(3)"), NXOpen.Features.Brep)

Dim face7 As NXOpen.Face = CType(brep6.FindObject("FACE 1 {(-10.0137007874016,32.4015748031496,-13.7177559055118) UNPARAMETERIZED_FEATURE(3)}"), NXOpen.Face)

faces5(0) = face7
Dim faceDumbRule5 As NXOpen.FaceDumbRule = Nothing
faceDumbRule5 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces5, selectionIntentRuleOptions13)

selectionIntentRuleOptions13.Dispose()
Dim selectionIntentRuleOptions14 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions14 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions14.SetSelectedFromInactive(False)

Dim bodies5(0) As NXOpen.Body
Dim body6 As NXOpen.Body = CType(workPart.Bodies.FindObject("UNPARAMETERIZED_FEATURE(3)"), NXOpen.Body)

bodies5(0) = body6
Dim bodyDumbRule5 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule5 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies5, True, selectionIntentRuleOptions14)

selectionIntentRuleOptions14.Dispose()
Dim selectionIntentRuleOptions15 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions15 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions15.SetSelectedFromInactive(False)

Dim edges5(3) As NXOpen.Edge
Dim edge17 As NXOpen.Edge = CType(brep6.FindObject("EDGE * -4 * 1 {(-10.0137007874016,32.4015748031496,-13.5407237140715)(-9.8366685959613,32.4015748031496,-13.7177559055118)(-10.0137007874016,32.4015748031496,-13.8947880969521) UNPARAMETERIZED_FEATURE(3)}"), NXOpen.Edge)

edges5(0) = edge17
Dim edge18 As NXOpen.Edge = CType(brep6.FindObject("EDGE * -3 * 1 {(-10.0137007874016,32.4015748031496,-13.8947880969521)(-10.1907329788419,32.4015748031496,-13.7177559055118)(-10.0137007874016,32.4015748031496,-13.5407237140715) UNPARAMETERIZED_FEATURE(3)}"), NXOpen.Edge)

edges5(1) = edge18
Dim edge19 As NXOpen.Edge = CType(brep6.FindObject("EDGE * -1 * 1 {(-10.112125984252,32.4015748031496,-13.7177559055118)(-10.0137007874016,32.4015748031496,-13.8161811023622)(-9.9152755905512,32.4015748031496,-13.7177559055118) UNPARAMETERIZED_FEATURE(3)}"), NXOpen.Edge)

edges5(2) = edge19
Dim edge20 As NXOpen.Edge = CType(brep6.FindObject("EDGE * -2 * 1 {(-9.9152755905512,32.4015748031496,-13.7177559055118)(-10.0137007874016,32.4015748031496,-13.6193307086614)(-10.112125984252,32.4015748031496,-13.7177559055118) UNPARAMETERIZED_FEATURE(3)}"), NXOpen.Edge)

edges5(3) = edge20
Dim edgeDumbRule5 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule5 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges5, selectionIntentRuleOptions15)

selectionIntentRuleOptions15.Dispose()
Dim selectionIntentRuleOptions16 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions16 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions16.SetSelectedFromInactive(False)

Dim faces6(0) As NXOpen.Face
Dim brep7 As NXOpen.Features.Brep = CType(workPart.Features.FindObject("UNPARAMETERIZED_FEATURE(8)"), NXOpen.Features.Brep)

Dim face8 As NXOpen.Face = CType(brep7.FindObject("FACE 1 {(9.6932566993819,32.3228346456693,-22.722874015748) UNPARAMETERIZED_FEATURE(8)}"), NXOpen.Face)

faces6(0) = face8
Dim faceDumbRule6 As NXOpen.FaceDumbRule = Nothing
faceDumbRule6 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces6, selectionIntentRuleOptions16)

selectionIntentRuleOptions16.Dispose()
Dim selectionIntentRuleOptions17 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions17 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions17.SetSelectedFromInactive(False)

Dim bodies6(0) As NXOpen.Body
Dim body7 As NXOpen.Body = CType(workPart.Bodies.FindObject("UNPARAMETERIZED_FEATURE(8)"), NXOpen.Body)

bodies6(0) = body7
Dim bodyDumbRule6 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule6 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies6, True, selectionIntentRuleOptions17)

selectionIntentRuleOptions17.Dispose()
Dim selectionIntentRuleOptions18 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions18 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions18.SetSelectedFromInactive(False)

Dim edges6(3) As NXOpen.Edge
Dim edge21 As NXOpen.Edge = CType(brep7.FindObject("EDGE * -3 * 1 {(9.6932566993819,32.3228346456693,-22.8985317926271)(9.5175989225028,32.3228346456693,-22.722874015748)(9.6932566993819,32.3228346456693,-22.547216238869) UNPARAMETERIZED_FEATURE(8)}"), NXOpen.Edge)

edges6(0) = edge21
Dim edge22 As NXOpen.Edge = CType(brep7.FindObject("EDGE * -4 * 1 {(9.6932566993819,32.3228346456693,-22.547216238869)(9.8689144762609,32.3228346456693,-22.722874015748)(9.6932566993819,32.3228346456693,-22.8985317926271) UNPARAMETERIZED_FEATURE(8)}"), NXOpen.Edge)

edges6(1) = edge22
Dim edge23 As NXOpen.Edge = CType(brep7.FindObject("EDGE * -1 * 1 {(9.5948315025315,32.3228346456693,-22.722874015748)(9.6932566993819,32.3228346456693,-22.8212992125984)(9.7916818962323,32.3228346456693,-22.722874015748) UNPARAMETERIZED_FEATURE(8)}"), NXOpen.Edge)

edges6(2) = edge23
Dim edge24 As NXOpen.Edge = CType(brep7.FindObject("EDGE * -2 * 1 {(9.7916818962323,32.3228346456693,-22.722874015748)(9.6932566993819,32.3228346456693,-22.6244488188976)(9.5948315025315,32.3228346456693,-22.722874015748) UNPARAMETERIZED_FEATURE(8)}"), NXOpen.Edge)

edges6(3) = edge24
Dim edgeDumbRule6 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule6 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges6, selectionIntentRuleOptions18)

selectionIntentRuleOptions18.Dispose()
Dim selectionIntentRuleOptions19 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions19 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions19.SetSelectedFromInactive(False)

Dim faces7(0) As NXOpen.Face
Dim brep8 As NXOpen.Features.Brep = CType(workPart.Features.FindObject("UNPARAMETERIZED_FEATURE(2)"), NXOpen.Features.Brep)

Dim face9 As NXOpen.Face = CType(brep8.FindObject("FACE 1 {(-10.0137007874016,32.4015748031496,-4.7126377952756) UNPARAMETERIZED_FEATURE(2)}"), NXOpen.Face)

faces7(0) = face9
Dim faceDumbRule7 As NXOpen.FaceDumbRule = Nothing
faceDumbRule7 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces7, selectionIntentRuleOptions19)

selectionIntentRuleOptions19.Dispose()
Dim selectionIntentRuleOptions20 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions20 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions20.SetSelectedFromInactive(False)

Dim bodies7(0) As NXOpen.Body
Dim body8 As NXOpen.Body = CType(workPart.Bodies.FindObject("UNPARAMETERIZED_FEATURE(2)"), NXOpen.Body)

bodies7(0) = body8
Dim bodyDumbRule7 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule7 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies7, True, selectionIntentRuleOptions20)

selectionIntentRuleOptions20.Dispose()
Dim selectionIntentRuleOptions21 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions21 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions21.SetSelectedFromInactive(False)

Dim edges7(3) As NXOpen.Edge
Dim edge25 As NXOpen.Edge = CType(brep8.FindObject("EDGE * -1 * 1 {(-10.112125984252,32.4015748031496,-4.7126377952756)(-10.0137007874016,32.4015748031496,-4.811062992126)(-9.9152755905512,32.4015748031496,-4.7126377952756) UNPARAMETERIZED_FEATURE(2)}"), NXOpen.Edge)

edges7(0) = edge25
Dim edge26 As NXOpen.Edge = CType(brep8.FindObject("EDGE * -2 * 1 {(-9.9152755905512,32.4015748031496,-4.7126377952756)(-10.0137007874016,32.4015748031496,-4.6142125984252)(-10.112125984252,32.4015748031496,-4.7126377952756) UNPARAMETERIZED_FEATURE(2)}"), NXOpen.Edge)

edges7(1) = edge26
Dim edge27 As NXOpen.Edge = CType(brep8.FindObject("EDGE * -3 * 1 {(-10.0137007874016,32.4015748031496,-4.8896699867159)(-10.1907329788419,32.4015748031496,-4.7126377952756)(-10.0137007874016,32.4015748031496,-4.5356056038353) UNPARAMETERIZED_FEATURE(2)}"), NXOpen.Edge)

edges7(2) = edge27
Dim edge28 As NXOpen.Edge = CType(brep8.FindObject("EDGE * -4 * 1 {(-10.0137007874016,32.4015748031496,-4.5356056038353)(-9.8366685959613,32.4015748031496,-4.7126377952756)(-10.0137007874016,32.4015748031496,-4.8896699867159) UNPARAMETERIZED_FEATURE(2)}"), NXOpen.Edge)

edges7(3) = edge28
Dim edgeDumbRule7 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule7 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges7, selectionIntentRuleOptions21)

selectionIntentRuleOptions21.Dispose()
Dim selectionIntentRuleOptions22 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions22 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions22.SetSelectedFromInactive(False)

Dim faces8(194) As NXOpen.Face
Dim extractFace1 As NXOpen.Features.ExtractFace = CType(workPart.Features.FindObject("SB_FLAT_SOLID(13:1B)"), NXOpen.Features.ExtractFace)

Dim face10 As NXOpen.Face = CType(extractFace1.FindObject("FACE 7 {(-7.7982677165354,33.3070866141732,-27.6051901078567) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(0) = face10
Dim face11 As NXOpen.Face = CType(extractFace1.FindObject("FACE 120 {(10.2851826135961,33.2677165354331,-13.4440705892654) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(1) = face11
Dim face12 As NXOpen.Face = CType(extractFace1.FindObject("FACE 121 {(10.2745311807839,33.30716825385,-1.5700548472185) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(2) = face12
Dim face13 As NXOpen.Face = CType(extractFace1.FindObject("FACE 18 {(-0,33.3070866141732,-3.8023382861142) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(3) = face13
Dim face14 As NXOpen.Face = CType(extractFace1.FindObject("FACE 68 {(11.5031749529352,33.3070866141732,-20.4921247159431) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(4) = face14
Dim face15 As NXOpen.Face = CType(extractFace1.FindObject("FACE 10 {(-1.9685039370079,33.3070866141732,-7.6703818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(5) = face15
Dim face16 As NXOpen.Face = CType(extractFace1.FindObject("FACE 107 {(11.045481177247,33.3070866141732,-26.1937923542403) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(6) = face16
Dim face17 As NXOpen.Face = CType(extractFace1.FindObject("FACE 206 {(9.1725679424408,33.3067653213654,-27.2437273870833) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(7) = face17
Dim face18 As NXOpen.Face = CType(extractFace1.FindObject("FACE 34 {(-10.186752495941,33.3070866141732,-0.7094548298734) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(8) = face18
Dim face19 As NXOpen.Face = CType(extractFace1.FindObject("FACE 12 {(-1.4763779527559,33.3070866141732,-5.465657480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(9) = face19
Dim face20 As NXOpen.Face = CType(extractFace1.FindObject("FACE 99 {(10.3108086258134,33.3070866141735,-1.4731241709024) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(10) = face20
Dim face21 As NXOpen.Face = CType(extractFace1.FindObject("FACE 163 {(-10.3382094796284,33.3070866141731,-1.5333245439896) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(11) = face21
Dim face22 As NXOpen.Face = CType(extractFace1.FindObject("FACE 35 {(-0.000694884269,33.3464566929134,-0.7094548298731) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(12) = face22
Dim face23 As NXOpen.Face = CType(extractFace1.FindObject("FACE 41 {(11.2862871576596,33.3070866141732,-3.6172980670986) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(13) = face23
Dim face24 As NXOpen.Face = CType(extractFace1.FindObject("FACE 87 {(11.581210386006,33.3464566929134,-14.4480067156803) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(14) = face24
Dim face25 As NXOpen.Face = CType(extractFace1.FindObject("FACE 204 {(10.223792866567,33.3070866141732,-28.3459768314001) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(15) = face25
Dim face26 As NXOpen.Face = CType(extractFace1.FindObject("FACE 104 {(10.6911504685856,33.2677165354331,-26.1937923542403) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(16) = face26
Dim face27 As NXOpen.Face = CType(extractFace1.FindObject("FACE 172 {(-10.9020980387864,33.3070866141735,-0.7881902999438) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(17) = face27
Dim face28 As NXOpen.Face = CType(extractFace1.FindObject("FACE 102 {(10.8290336077669,33.2677165354331,-1.5751653466992) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(18) = face28
Dim face29 As NXOpen.Face = CType(extractFace1.FindObject("FACE 49 {(11.8669958190769,33.3070866141732,-7.7952743222424) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(19) = face29
Dim face30 As NXOpen.Face = CType(extractFace1.FindObject("FACE 153 {(-11.1727262256822,33.3070866123346,-1.7482473784119) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(20) = face30
Dim face31 As NXOpen.Face = CType(extractFace1.FindObject("FACE 5 {(1.1062992125984,33.3070866141732,-27.6051901078567) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(21) = face31
Dim face32 As NXOpen.Face = CType(extractFace1.FindObject("FACE 161 {(-10.3382095237197,33.3070868470959,-1.5775699040927) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(22) = face32
Dim face33 As NXOpen.Face = CType(extractFace1.FindObject("FACE 133 {(-11.3713796773606,33.3070866141732,-4.5714960629921) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(23) = face33
Dim face34 As NXOpen.Face = CType(extractFace1.FindObject("FACE 82 {(11.6890442378052,33.3070866141732,-22.5817314088565) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(24) = face34
Dim face35 As NXOpen.Face = CType(extractFace1.FindObject("FACE 22 {(-0.0787401574803,33.3070866141732,-2.0275590551181) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(25) = face35
Dim face36 As NXOpen.Face = CType(extractFace1.FindObject("FACE 59 {(12.0142812521478,33.3070866141732,-14.2913373143683) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(26) = face36
Dim face37 As NXOpen.Face = CType(extractFace1.FindObject("FACE 74 {(11.5031749529352,33.3070866141732,-24.6259829836597) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(27) = face37
Dim face38 As NXOpen.Face = CType(extractFace1.FindObject("FACE 189 {(0.0550214489482,33.2677165354331,-26.8380674948615) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(28) = face38
Dim face39 As NXOpen.Face = CType(extractFace1.FindObject("FACE 80 {(11.6890442378052,33.3070866141732,-13.5766132986203) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(29) = face39
Dim face40 As NXOpen.Face = CType(extractFace1.FindObject("FACE 64 {(11.9912187939735,33.3070866141732,-16.6766044969521) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(30) = face40
Dim face41 As NXOpen.Face = CType(extractFace1.FindObject("FACE 152 {(-10.8233376441033,33.2677165354331,-13.3804460109994) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(31) = face41
Dim face42 As NXOpen.Face = CType(extractFace1.FindObject("FACE 180 {(-10.3382095237197,33.3070866141732,-26.1948842298605) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(32) = face42
Dim face43 As NXOpen.Face = CType(extractFace1.FindObject("FACE 148 {(-11.0468709410425,33.3070866141732,-25.2984012782402) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(33) = face43
Dim face44 As NXOpen.Face = CType(extractFace1.FindObject("FACE 164 {(-10.3121983896076,33.3070866141734,-1.4731250198357) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(34) = face44
Dim face45 As NXOpen.Face = CType(extractFace1.FindObject("FACE 137 {(-11.3713796773606,33.3070866141732,-22.8640157480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(35) = face45
Dim face46 As NXOpen.Face = CType(extractFace1.FindObject("FACE 191 {(-9.9096114812056,33.3070866141732,-27.5920813222426) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(36) = face46
Dim face47 As NXOpen.Face = CType(extractFace1.FindObject("FACE 100 {(10.3368197158338,33.3070866141733,-1.5333236950723) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(37) = face47
Dim face48 As NXOpen.Face = CType(extractFace1.FindObject("FACE 85 {(11.6890442378052,33.3070866141732,-4.5714951883841) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(38) = face48
Dim face49 As NXOpen.Face = CType(extractFace1.FindObject("FACE 38 {(10.2341614173228,33.3070866141732,-1.3261126673839) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(39) = face49
Dim face50 As NXOpen.Face = CType(extractFace1.FindObject("FACE 193 {(-9.7627315376673,33.3070866141732,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(40) = face50
Dim face51 As NXOpen.Face = CType(extractFace1.FindObject("FACE 92 {(11.0570123522487,33.3070866141732,-3.550089192791) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(41) = face51
Dim face52 As NXOpen.Face = CType(extractFace1.FindObject("FACE 109 {(10.8219522342779,33.3464566929134,-13.3804415912914) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(42) = face52
Dim face53 As NXOpen.Face = CType(extractFace1.FindObject("FACE 156 {(-11.3226372992741,33.3070866144138,-1.5572291569798) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(43) = face53
Dim face54 As NXOpen.Face = CType(extractFace1.FindObject("FACE 145 {(-11.0586666925598,33.3070866141732,-3.6058655411794) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(44) = face54
Dim face55 As NXOpen.Face = CType(extractFace1.FindObject("FACE 201 {(9.5222047244094,33.3070866141732,-28.1974342023448) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(45) = face55
Dim face56 As NXOpen.Face = CType(extractFace1.FindObject("FACE 185 {(0.061413307086,33.3464566929134,-13.5580989295608) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(46) = face56
Dim face57 As NXOpen.Face = CType(extractFace1.FindObject("FACE 213 {(0.0000104337244,33.3464566929134,-27.2437273748433) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(47) = face57
Dim face58 As NXOpen.Face = CType(extractFace1.FindObject("FACE 162 {(-10.3382095237197,33.3070863112283,-1.5675155582089) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(48) = face58
Dim face59 As NXOpen.Face = CType(extractFace1.FindObject("FACE 146 {(-11.0982001123512,33.3464566929134,-14.3632202657357) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(49) = face59
Dim face60 As NXOpen.Face = CType(extractFace1.FindObject("FACE 52 {(11.9912187939735,33.3070866141732,-8.408887961519) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(50) = face60
Dim face61 As NXOpen.Face = CType(extractFace1.FindObject("FACE 2 {(8.1732283464567,33.3070866141732,-28.195741288959) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(51) = face61
Dim face62 As NXOpen.Face = CType(extractFace1.FindObject("FACE 154 {(-11.3126624004589,33.3070866122307,-1.575159991629) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(52) = face62
Dim face63 As NXOpen.Face = CType(extractFace1.FindObject("FACE 150 {(-10.6925402323811,33.3070866141732,-27.0716821421107) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(53) = face63
Dim face64 As NXOpen.Face = CType(extractFace1.FindObject("FACE 105 {(10.3368197599241,33.3070866141732,-26.1937927915443) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(54) = face64
Dim face65 As NXOpen.Face = CType(extractFace1.FindObject("FACE 111 {(11.3112716807475,33.3070866121415,-1.5751627379977) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(55) = face65
Dim face66 As NXOpen.Face = CType(extractFace1.FindObject("FACE 75 {(11.8669958190769,33.3070866141732,-24.9212585742109) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(56) = face66
Dim face67 As NXOpen.Face = CType(extractFace1.FindObject("FACE 57 {(11.8669958190769,33.3070866141732,-12.5196837710612) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(57) = face67
Dim face68 As NXOpen.Face = CType(extractFace1.FindObject("FACE 20 {(-8.3464566929134,33.3070866141732,-2.0275590551181) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(58) = face68
Dim face69 As NXOpen.Face = CType(extractFace1.FindObject("FACE 13 {(1.9685039370079,33.3070866141732,-7.9193818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(59) = face69
Dim face70 As NXOpen.Face = CType(extractFace1.FindObject("FACE 175 {(-11.2110307927384,33.3070866141715,-1.2848388571791) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(60) = face70
Dim face71 As NXOpen.Face = CType(extractFace1.FindObject("FACE 207 {(9.1725381876693,33.3070866141713,-26.8358337193604) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(61) = face71
Dim face72 As NXOpen.Face = CType(extractFace1.FindObject("FACE 73 {(11.8669958190769,33.3070866141732,-24.3307073931085) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(62) = face72
Dim face73 As NXOpen.Face = CType(extractFace1.FindObject("FACE 26 {(-0.000694884269,33.2677165354331,-0.7094548298731) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(63) = face73
Dim face74 As NXOpen.Face = CType(extractFace1.FindObject("FACE 90 {(11.0968103485556,33.2677165354331,-14.3632193911299) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(64) = face74
Dim face75 As NXOpen.Face = CType(extractFace1.FindObject("FACE 16 {(1.4763779527559,33.3070866141732,-5.465657480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(65) = face75
Dim face76 As NXOpen.Face = CType(extractFace1.FindObject("FACE 79 {(11.9912187939735,33.3070866141732,-24.9443210323851) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(66) = face76
Dim face77 As NXOpen.Face = CType(extractFace1.FindObject("FACE 42 {(11.4801124947609,33.3070866141732,-3.6403605252729) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(67) = face77
Dim face78 As NXOpen.Face = CType(extractFace1.FindObject("FACE 14 {(1.9685039370079,33.3070866141732,-7.6703818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(68) = face78
Dim face79 As NXOpen.Face = CType(extractFace1.FindObject("FACE 199 {(-9.5222047244094,33.3070866141732,-27.9151507377779) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(69) = face79
Dim face80 As NXOpen.Face = CType(extractFace1.FindObject("FACE 202 {(9.5222047244094,33.3070866141732,-27.9151507377779) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(70) = face80
Dim face81 As NXOpen.Face = CType(extractFace1.FindObject("FACE 155 {(-11.3170975961154,33.3070866141729,-1.5028790342004) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(71) = face81
Dim face82 As NXOpen.Face = CType(extractFace1.FindObject("FACE 149 {(-11.0468709410425,33.3070866141732,-26.1948842298605) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(72) = face82
Dim face83 As NXOpen.Face = CType(extractFace1.FindObject("FACE 117 {(10.8290336077668,33.3464566929134,-1.5751623164255) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(73) = face83
Dim face84 As NXOpen.Face = CType(extractFace1.FindObject("FACE 37 {(10.211420115748,33.3070866141732,-0.9086449515379) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(74) = face84
Dim face85 As NXOpen.Face = CType(extractFace1.FindObject("FACE 130 {(-11.6036841618461,33.3070866141732,-3.6749550871424) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(75) = face85
Dim face86 As NXOpen.Face = CType(extractFace1.FindObject("FACE 209 {(0.0550406024938,33.3464566929134,-26.4324076179602) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(76) = face86
Dim face87 As NXOpen.Face = CType(extractFace1.FindObject("FACE 118 {(10.3368197599241,33.3070868470914,-1.5775690551475) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(77) = face87
Dim face88 As NXOpen.Face = CType(extractFace1.FindObject("FACE 122 {(10.3258035415962,33.3070866083141,-1.5700548472185) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(78) = face88
Dim face89 As NXOpen.Face = CType(extractFace1.FindObject("FACE 147 {(-11.0982001123512,33.3070866141732,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(79) = face89
Dim face90 As NXOpen.Face = CType(extractFace1.FindObject("FACE 40 {(11.1167766021145,33.3070866141732,-3.6172980670986) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(80) = face90
Dim face91 As NXOpen.Face = CType(extractFace1.FindObject("FACE 143 {(-11.1059260591527,33.3070866141732,-3.5385587842264) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(81) = face91
Dim face92 As NXOpen.Face = CType(extractFace1.FindObject("FACE 25 {(-10.2128098819055,33.3070866141732,-0.908644933385) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(82) = face92
Dim face93 As NXOpen.Face = CType(extractFace1.FindObject("FACE 173 {(-11.0475731643231,33.3070866141733,-1.0568101758135) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(83) = face93
Dim face94 As NXOpen.Face = CType(extractFace1.FindObject("FACE 71 {(12.0142812521478,33.3070866141732,-22.5590538498014) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(84) = face94
Dim face95 As NXOpen.Face = CType(extractFace1.FindObject("FACE 129 {(-11.3070095986204,33.3070866141732,-3.6172989417067) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(85) = face95
Dim face96 As NXOpen.Face = CType(extractFace1.FindObject("FACE 36 {(10.1853627274027,33.3070866141732,-0.7094548298732) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(86) = face96
Dim face97 As NXOpen.Face = CType(extractFace1.FindObject("FACE 72 {(11.9912187939735,33.3070866141732,-24.3076449349342) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(87) = face97
Dim face98 As NXOpen.Face = CType(extractFace1.FindObject("FACE 3 {(3.1653543307087,33.3070866141732,-27.6051901078567) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(88) = face98
Dim face99 As NXOpen.Face = CType(extractFace1.FindObject("FACE 181 {(-10.286880352411,33.3070866141732,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(89) = face99
Dim face100 As NXOpen.Face = CType(extractFace1.FindObject("FACE 203 {(0.0000000001024,33.3464566929134,-27.8265526091441) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(90) = face100
Dim face101 As NXOpen.Face = CType(extractFace1.FindObject("FACE 11 {(-1.4763779527559,33.3070866141732,-5.714657480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(91) = face101
Dim face102 As NXOpen.Face = CType(extractFace1.FindObject("FACE 83 {(11.6890442378052,33.3070866141732,-22.8640148734235) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(92) = face102
Dim face103 As NXOpen.Face = CType(extractFace1.FindObject("FACE 46 {(11.9912187939735,33.3070866141732,-4.2750296938025) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(93) = face103
Dim face104 As NXOpen.Face = CType(extractFace1.FindObject("FACE 95 {(10.3368197599241,33.3070863112341,-1.5675147092926) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(94) = face104
Dim face105 As NXOpen.Face = CType(extractFace1.FindObject("FACE 110 {(11.1713364526658,33.3070866123346,-1.7482465228731) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(95) = face105
Dim face106 As NXOpen.Face = CType(extractFace1.FindObject("FACE 125 {(9.9206571609365,33.3068482746501,-26.0732693973832) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(96) = face106
Dim face107 As NXOpen.Face = CType(extractFace1.FindObject("FACE 47 {(12.0142812521478,33.3070866141732,-6.0236207789353) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(97) = face107
Dim face108 As NXOpen.Face = CType(extractFace1.FindObject("FACE 165 {(-10.3027764087623,33.3070866141731,-1.0967225144071) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(98) = face108
Dim face109 As NXOpen.Face = CType(extractFace1.FindObject("FACE 63 {(11.8669958190769,33.3070866141732,-16.6535420387778) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(99) = face109
Dim face110 As NXOpen.Face = CType(extractFace1.FindObject("FACE 76 {(11.5615253466359,33.3070866141732,-25.278715364262) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(100) = face110
Dim face111 As NXOpen.Face = CType(extractFace1.FindObject("FACE 119 {(10.3368869389957,33.3069858815649,-1.5776817195246) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(101) = face111
Dim face112 As NXOpen.Face = CType(extractFace1.FindObject("FACE 23 {(8.3464566929134,33.3070866141732,-2.0275590551181) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(102) = face112
Dim face113 As NXOpen.Face = CType(extractFace1.FindObject("FACE 65 {(12.0142812521478,33.3070866141732,-18.4251955820849) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(103) = face113
Dim face114 As NXOpen.Face = CType(extractFace1.FindObject("FACE 187 {(0.061413307086,33.2677165354331,-13.5580989295608) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(104) = face114
Dim face115 As NXOpen.Face = CType(extractFace1.FindObject("FACE 135 {(-11.3713796773606,33.3070866141732,-13.8588976377953) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(105) = face115
Dim face116 As NXOpen.Face = CType(extractFace1.FindObject("FACE 197 {(-0,33.3070866141732,-27.9151507377779) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(106) = face116
Dim face117 As NXOpen.Face = CType(extractFace1.FindObject("FACE 210 {(-9.1725590551181,33.3070866141732,-26.4324076149031) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(107) = face117
Dim face118 As NXOpen.Face = CType(extractFace1.FindObject("FACE 61 {(11.8669958190769,33.3070866141732,-16.0629908576754) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(108) = face118
Dim face119 As NXOpen.Face = CType(extractFace1.FindObject("FACE 174 {(-11.1016416692913,33.3070866141728,-1.0860928394152) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(109) = face119
Dim face120 As NXOpen.Face = CType(extractFace1.FindObject("FACE 67 {(11.8669958190769,33.3070866141732,-20.196849125392) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(110) = face120
Dim face121 As NXOpen.Face = CType(extractFace1.FindObject("FACE 178 {(-10.8233420145892,33.3464566929134,-13.3804424527709) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(111) = face121
Dim face122 As NXOpen.Face = CType(extractFace1.FindObject("FACE 6 {(1.1062992125984,33.3070866141732,-28.195741288959) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(112) = face122
Dim face123 As NXOpen.Face = CType(extractFace1.FindObject("FACE 19 {(-8.1889763779528,33.3070866141732,-2.0275590551181) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(113) = face123
Dim face124 As NXOpen.Face = CType(extractFace1.FindObject("FACE 198 {(-9.5222047244094,33.3070866141732,-28.1974342023448) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(114) = face124
Dim face125 As NXOpen.Face = CType(extractFace1.FindObject("FACE 126 {(-9.9242079957495,33.3070866141732,-26.0697352582416) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(115) = face125
Dim face126 As NXOpen.Face = CType(extractFace1.FindObject("FACE 21 {(0.0787401574803,33.3070866141732,-2.0275590551181) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(116) = face126
Dim face127 As NXOpen.Face = CType(extractFace1.FindObject("FACE 171 {(-10.7678882646845,33.3070866141728,-0.5137683868284) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(117) = face127
Dim face128 As NXOpen.Face = CType(extractFace1.FindObject("FACE 15 {(1.4763779527559,33.3070866141732,-5.714657480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(118) = face128
Dim face129 As NXOpen.Face = CType(extractFace1.FindObject("FACE 50 {(11.5031749529352,33.3070866141732,-8.0905499127935) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(119) = face129
Dim face130 As NXOpen.Face = CType(extractFace1.FindObject("FACE 131 {(-11.6613403072819,33.3070866141732,-14.5267477477687) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(120) = face130
Dim face131 As NXOpen.Face = CType(extractFace1.FindObject("FACE 8 {(-7.7982677165354,33.3070866141732,-28.195741288959) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(121) = face131
Dim face132 As NXOpen.Face = CType(extractFace1.FindObject("FACE 195 {(9.7620366558799,33.3070866141732,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(122) = face132
Dim face133 As NXOpen.Face = CType(extractFace1.FindObject("FACE 205 {(9.9060897337168,33.3070866141732,-27.5887080428345) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(123) = face133
Dim face134 As NXOpen.Face = CType(extractFace1.FindObject("FACE 43 {(11.5031749529352,33.3070866141732,-3.826364934828) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(124) = face134
Dim face135 As NXOpen.Face = CType(extractFace1.FindObject("FACE 103 {(10.8219478638751,33.2677165354331,-13.3804451494528) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(125) = face135
Dim face136 As NXOpen.Face = CType(extractFace1.FindObject("FACE 194 {(-0.0006948818898,33.3070866141732,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(126) = face136
Dim face137 As NXOpen.Face = CType(extractFace1.FindObject("FACE 136 {(-11.3713796773606,33.3070866141732,-22.5817322834646) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(127) = face137
Dim face138 As NXOpen.Face = CType(extractFace1.FindObject("FACE 124 {(10.2861854705133,33.3070866141732,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(128) = face138
Dim face139 As NXOpen.Face = CType(extractFace1.FindObject("FACE 158 {(-10.8304233894513,33.2677165354331,-1.5751648751138) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(129) = face139
Dim face140 As NXOpen.Face = CType(extractFace1.FindObject("FACE 56 {(11.5031749529352,33.3070866141732,-12.2244081805101) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(130) = face140
Dim face141 As NXOpen.Face = CType(extractFace1.FindObject("FACE 93 {(11.1045362953572,33.3070866141732,-3.5385579096183) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(131) = face141
Dim face142 As NXOpen.Face = CType(extractFace1.FindObject("FACE 69 {(11.8669958190769,33.3070866141732,-20.7874003064943) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(132) = face142
Dim face143 As NXOpen.Face = CType(extractFace1.FindObject("FACE 112 {(11.3212474996999,33.3070866143013,-1.557228308044) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(133) = face143
Dim face144 As NXOpen.Face = CType(extractFace1.FindObject("FACE 108 {(11.045481177247,33.3070866141732,-25.2984004036321) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(134) = face144
Dim face145 As NXOpen.Face = CType(extractFace1.FindObject("FACE 184 {(-10.286880352411,33.3464566929134,-13.4440705695781) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(135) = face145
Dim face146 As NXOpen.Face = CType(extractFace1.FindObject("FACE 62 {(11.5031749529352,33.3070866141732,-16.3582664482266) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(136) = face146
Dim face147 As NXOpen.Face = CType(extractFace1.FindObject("FACE 53 {(12.0142812521478,33.3070866141732,-10.1574790466518) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(137) = face147
Dim face148 As NXOpen.Face = CType(extractFace1.FindObject("FACE 166 {(-10.3086438737007,33.3070866141731,-0.7278438657655) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(138) = face148
Dim face149 As NXOpen.Face = CType(extractFace1.FindObject("FACE 54 {(11.9912187939735,33.3070866141732,-11.9060701317846) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(139) = face149
Dim face150 As NXOpen.Face = CType(extractFace1.FindObject("FACE 139 {(-11.3713796773606,33.3070866141732,-4.8537795275591) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(140) = face150
Dim face151 As NXOpen.Face = CType(extractFace1.FindObject("FACE 134 {(-11.3713796773606,33.3070866141732,-13.5766141732283) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(141) = face151
Dim face152 As NXOpen.Face = CType(extractFace1.FindObject("FACE 48 {(11.9912187939735,33.3070866141732,-7.7722118640681) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(142) = face152
Dim face153 As NXOpen.Face = CType(extractFace1.FindObject("FACE 1 {(8.1732283464567,33.3070866141732,-27.6051901078567) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(143) = face153
Dim face154 As NXOpen.Face = CType(extractFace1.FindObject("FACE 24 {(8.1889763779528,33.3070866141732,-2.0275590551181) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(144) = face154
Dim face155 As NXOpen.Face = CType(extractFace1.FindObject("FACE 177 {(-10.8304233894513,33.3464566929134,-1.5751618460059) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(145) = face155
Dim face156 As NXOpen.Face = CType(extractFace1.FindObject("FACE 141 {(-11.0982001123512,33.2677165354331,-14.3632202657357) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(146) = face156
Dim face157 As NXOpen.Face = CType(extractFace1.FindObject("FACE 196 {(0,33.3070866141732,-28.1974342023448) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(147) = face157
Dim face158 As NXOpen.Face = CType(extractFace1.FindObject("FACE 77 {(12.0027500230606,33.3070866141732,-25.2671841351749) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(148) = face158
Dim face159 As NXOpen.Face = CType(extractFace1.FindObject("FACE 192 {(-10.2237928663623,33.3070866141732,-28.3459768314001) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(149) = face159
Dim face160 As NXOpen.Face = CType(extractFace1.FindObject("FACE 88 {(11.0968103485556,33.3464566929134,-14.3632193911301) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(150) = face160
Dim face161 As NXOpen.Face = CType(extractFace1.FindObject("FACE 89 {(11.0968103485556,33.3070866141732,-25.278715364262) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(151) = face161
Dim face162 As NXOpen.Face = CType(extractFace1.FindObject("FACE 188 {(0.0550347350513,33.2677165354331,-26.4324076175233) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(152) = face162
Dim face163 As NXOpen.Face = CType(extractFace1.FindObject("FACE 4 {(3.1653543307087,33.3070866141732,-28.195741288959) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(153) = face163
Dim face164 As NXOpen.Face = CType(extractFace1.FindObject("FACE 17 {(0,33.3070866141732,-5.8023382861142) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(154) = face164
Dim face165 As NXOpen.Face = CType(extractFace1.FindObject("FACE 45 {(11.8669958190769,33.3070866141732,-4.2519672356282) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(155) = face165
Dim face166 As NXOpen.Face = CType(extractFace1.FindObject("FACE 86 {(11.6890442378052,33.3070866141732,-4.853778652951) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(156) = face166
Dim face167 As NXOpen.Face = CType(extractFace1.FindObject("FACE 113 {(11.3157077965413,33.3070866141729,-1.5028781852668) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(157) = face167
Dim face168 As NXOpen.Face = CType(extractFace1.FindObject("FACE 151 {(-10.6925402323811,33.2677165354331,-26.1948842298605) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(158) = face168
Dim face169 As NXOpen.Face = CType(extractFace1.FindObject("FACE 179 {(-10.6925402323811,33.3464566929134,-26.1948842298605) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(159) = face169
Dim face170 As NXOpen.Face = CType(extractFace1.FindObject("FACE 97 {(10.3072541099064,33.3070866141726,-0.7278429907206) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(160) = face170
Dim face171 As NXOpen.Face = CType(extractFace1.FindObject("FACE 132 {(-11.6498090781947,33.3070866141732,-25.2671850097829) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(161) = face171
Dim face172 As NXOpen.Face = CType(extractFace1.FindObject("FACE 58 {(11.9912187939735,33.3070866141732,-12.5427462292355) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(162) = face172
Dim face173 As NXOpen.Face = CType(extractFace1.FindObject("FACE 123 {(10.2856669664085,33.3464566929134,-13.4440705846874) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(163) = face173
Dim face174 As NXOpen.Face = CType(extractFace1.FindObject("FACE 190 {(0.0550452488116,33.2677165354331,-27.2437273712735) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(164) = face174
Dim face175 As NXOpen.Face = CType(extractFace1.FindObject("FACE 159 {(-10.286880352411,33.3070866141732,-1.5700548215461) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(165) = face175
Dim face176 As NXOpen.Face = CType(extractFace1.FindObject("FACE 106 {(10.6911504685856,33.3464566929134,-26.1937923542403) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(166) = face176
Dim face177 As NXOpen.Face = CType(extractFace1.FindObject("FACE 212 {(-9.1725590551181,33.3070866141732,-27.2437273748433) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(167) = face177
Dim face178 As NXOpen.Face = CType(extractFace1.FindObject("FACE 84 {(11.581210386006,33.2677165354331,-14.4480067156803) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(168) = face178
Dim face179 As NXOpen.Face = CType(extractFace1.FindObject("FACE 208 {(9.1725600285154,33.3142947820054,-26.4323004813931) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(169) = face179
Dim face180 As NXOpen.Face = CType(extractFace1.FindObject("FACE 60 {(11.9912187939735,33.3070866141732,-16.0399283995011) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(170) = face180
Dim face181 As NXOpen.Face = CType(extractFace1.FindObject("FACE 182 {(-10.286880352411,33.2677165354331,-13.4440705695781) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(171) = face181
Dim face182 As NXOpen.Face = CType(extractFace1.FindObject("FACE 55 {(11.8669958190769,33.3070866141732,-11.9291325899589) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(172) = face182
Dim face183 As NXOpen.Face = CType(extractFace1.FindObject("FACE 44 {(11.5896591710887,33.3070866141732,-4.1654830174746) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(173) = face183
Dim face184 As NXOpen.Face = CType(extractFace1.FindObject("FACE 138 {(-11.4054347954708,33.3464566929134,-14.4480075902884) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(174) = face184
Dim face185 As NXOpen.Face = CType(extractFace1.FindObject("FACE 127 {(-11.3857497561008,33.3070866141732,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(175) = face185
Dim face186 As NXOpen.Face = CType(extractFace1.FindObject("FACE 128 {(-11.11816636591,33.3070866141732,-3.6172989417067) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(176) = face186
Dim face187 As NXOpen.Face = CType(extractFace1.FindObject("FACE 39 {(10.6911504685856,33.3070866141732,-27.0694992654784) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(177) = face187
Dim face188 As NXOpen.Face = CType(extractFace1.FindObject("FACE 9 {(-1.9685039370079,33.3070866141732,-7.9193818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(178) = face188
Dim face189 As NXOpen.Face = CType(extractFace1.FindObject("FACE 200 {(0.0000000001024,33.2677165354331,-27.8265526067016) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(179) = face189
Dim face190 As NXOpen.Face = CType(extractFace1.FindObject("FACE 142 {(-11.1256110985228,33.3070866141732,-2.7462359495807) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(180) = face190
Dim face191 As NXOpen.Face = CType(extractFace1.FindObject("FACE 144 {(-11.0584021160457,33.3070866141732,-3.5500900673976) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(181) = face191
Dim face192 As NXOpen.Face = CType(extractFace1.FindObject("FACE 214 {(0.0550458506562,33.3464566929134,-26.8380674948732) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(182) = face192
Dim face193 As NXOpen.Face = CType(extractFace1.FindObject("FACE 98 {(10.3013866449676,33.3070866141738,-1.096721652417) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(183) = face193
Dim face194 As NXOpen.Face = CType(extractFace1.FindObject("FACE 94 {(11.1242213347273,33.3070866141732,-2.7462350749727) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(184) = face194
Dim face195 As NXOpen.Face = CType(extractFace1.FindObject("FACE 51 {(11.8669958190769,33.3070866141732,-8.3858255033447) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(185) = face195
Dim face196 As NXOpen.Face = CType(extractFace1.FindObject("FACE 160 {(-10.3382095237196,33.3070866141732,-1.5776366363648) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(186) = face196
Dim face197 As NXOpen.Face = CType(extractFace1.FindObject("FACE 186 {(-10.2355511811024,33.3070866141732,-1.3261126363945) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(187) = face197
Dim face198 As NXOpen.Face = CType(extractFace1.FindObject("FACE 91 {(11.0572785808394,33.3070866141732,-3.6058653114857) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(188) = face198
Dim face199 As NXOpen.Face = CType(extractFace1.FindObject("FACE 211 {(-9.1725590551181,33.3070866141732,-26.8380674948732) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(189) = face199
Dim face200 As NXOpen.Face = CType(extractFace1.FindObject("FACE 66 {(11.9912187939735,33.3070866141732,-20.1737866672177) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(190) = face200
Dim face201 As NXOpen.Face = CType(extractFace1.FindObject("FACE 140 {(-11.4054347954708,33.2677165354331,-14.4480075902884) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(191) = face201
Dim face202 As NXOpen.Face = CType(extractFace1.FindObject("FACE 81 {(11.6890442378052,33.3070866141732,-13.8588967631872) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(192) = face202
Dim face203 As NXOpen.Face = CType(extractFace1.FindObject("FACE 78 {(12.0142812521478,33.3070866141732,-25.1196720086065) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(193) = face203
Dim face204 As NXOpen.Face = CType(extractFace1.FindObject("FACE 70 {(11.9912187939735,33.3070866141732,-20.8104627646686) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces8(194) = face204
Dim faceDumbRule8 As NXOpen.FaceDumbRule = Nothing
faceDumbRule8 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces8, selectionIntentRuleOptions22)

selectionIntentRuleOptions22.Dispose()
Dim selectionIntentRuleOptions23 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions23 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions23.SetSelectedFromInactive(False)

Dim edges8(519) As NXOpen.Edge
Dim edge29 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 204 * 205 {(10.2347646535433,33.2677165354331,-28.3171643596007)(10.2347646535433,33.3070866141732,-28.3171643596007)(10.2347646535433,33.3464566929134,-28.3171643596007) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(0) = edge29
Dim edge30 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 200 * 205 {(9.1725787260542,33.2677165354331,-27.2950565461292)(9.9096185685279,33.2677165354331,-27.5920881418007)(10.2347646535445,33.2677165354331,-28.3171643596007) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(1) = edge30
Dim edge31 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 205 * 206 {(9.1725799225666,33.3464566816721,-27.295056546152)(9.1725793243104,33.3070866086755,-27.2950565461404)(9.1725787260545,33.2677165356788,-27.2950565461292) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(2) = edge31
Dim edge32 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 203 * 204 {(10.234764653543,33.3464566929134,-28.3171643596008)(10.223792866567,33.3464566929134,-28.3459768314001)(10.1954237054606,33.3464566929134,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(3) = edge32
Dim edge33 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 203 * 205 {(9.1725799225669,33.3464566929134,-27.295056546152)(9.9096189996135,33.3464566929134,-27.5920885566209)(10.2347646535445,33.3464566929134,-28.3171643596007) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(4) = edge33
Dim edge34 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 203 * 213 {(-9.1725590551181,33.3464566929134,-27.2950565461519)(0.0000104337244,33.3464566929134,-27.2950565461519)(9.1725799225669,33.3464566929134,-27.2950565461519) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(5) = edge34
Dim edge35 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 191 * 203 {(-10.2347646533396,33.3464566929134,-28.3171643596007)(-9.9096114812056,33.3464566929134,-27.5920813222426)(-9.1725590551181,33.3464566929134,-27.2950565461519) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(6) = edge35
Dim edge36 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 192 * 203 {(-10.1954237052559,33.3464566929134,-28.3580486721362)(-10.2237928663623,33.3464566929134,-28.3459768314001)(-10.2347646533383,33.3464566929134,-28.3171643596008) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(7) = edge36
Dim edge37 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 195 * 203 {(10.1954237054606,33.3464566929134,-28.3580486721362)(9.7620366558799,33.3464566929134,-28.3580486721362)(9.3286496062992,33.3464566929134,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(8) = edge37
Dim edge38 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 2 * 203 {(7.8779527559055,33.3464566929134,-27.9004656984078)(8.1732283464567,33.3464566929134,-28.195741288959)(8.4685039370079,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(9) = edge38
Dim edge39 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 1 * 203 {(8.4685039370079,33.3464566929134,-27.9004656984078)(8.1732283464567,33.3464566929134,-27.6051901078566)(7.8779527559055,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(10) = edge39
Dim edge40 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 203 * 4 {(2.8700787401575,33.3464566929134,-27.9004656984078)(3.1653543307087,33.3464566929134,-28.195741288959)(3.4606299212598,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(11) = edge40
Dim edge41 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 203 * 3 {(3.4606299212598,33.3464566929134,-27.9004656984078)(3.1653543307087,33.3464566929134,-27.6051901078566)(2.8700787401575,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(12) = edge41
Dim edge42 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 203 * 6 {(0.8110236220472,33.3464566929134,-27.9004656984078)(1.1062992125984,33.3464566929134,-28.195741288959)(1.4015748031496,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(13) = edge42
Dim edge43 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 203 * 5 {(1.4015748031496,33.3464566929134,-27.9004656984078)(1.1062992125984,33.3464566929134,-27.6051901078566)(0.8110236220472,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(14) = edge43
Dim edge44 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 203 * 8 {(-8.0935433070866,33.3464566929134,-27.9004656984078)(-7.7982677165354,33.3464566929134,-28.195741288959)(-7.5029921259843,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(15) = edge44
Dim edge45 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 203 * 7 {(-7.5029921259843,33.3464566929134,-27.9004656984078)(-7.7982677165354,33.3464566929134,-27.6051901078566)(-8.0935433070866,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(16) = edge45
Dim edge46 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 191 * 200 {(-10.2347646533396,33.2677165354331,-28.3171643596007)(-9.9096114812056,33.2677165354331,-27.5920813222426)(-9.1725590551181,33.2677165354331,-27.2950565461519) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(17) = edge46
Dim edge47 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 200 * 204 {(10.1954237054606,33.2677165354331,-28.3580486721362)(10.223792866567,33.2677165354331,-28.3459768314001)(10.234764653543,33.2677165354331,-28.3171643596008) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(18) = edge47
Dim edge48 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 194 * 200 {(-9.3300393700787,33.2677165354331,-28.3580486721362)(-0.0006948818898,33.2677165354331,-28.3580486721362)(9.3286496062992,33.2677165354331,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(19) = edge48
Dim edge49 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 193 * 200 {(-10.1954237052559,33.2677165354331,-28.3580486721362)(-9.7627315376673,33.2677165354331,-28.3580486721362)(-9.3300393700787,33.2677165354331,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(20) = edge49
Dim edge50 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 192 * 200 {(-10.2347646533383,33.2677165354331,-28.3171643596008)(-10.2237928663623,33.2677165354331,-28.3459768314001)(-10.1954237052559,33.2677165354331,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(21) = edge50
Dim edge51 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 197 * 200 {(-0.1411417322835,33.2677165354331,-28.0562924700614)(-0,33.2677165354331,-27.9151507377779)(0.1411417322835,33.2677165354331,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(22) = edge51
Dim edge52 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 196 * 200 {(0.1411417322835,33.2677165354331,-28.0562924700614)(0,33.2677165354331,-28.1974342023448)(-0.1411417322835,33.2677165354331,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(23) = edge52
Dim edge53 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 200 * 202 {(9.381062992126,33.2677165354331,-28.0562924700614)(9.5222047244094,33.2677165354331,-27.9151507377779)(9.6633464566929,33.2677165354331,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(24) = edge53
Dim edge54 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 200 * 201 {(9.6633464566929,33.2677165354331,-28.0562924700614)(9.5222047244094,33.2677165354331,-28.1974342023448)(9.381062992126,33.2677165354331,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(25) = edge54
Dim edge55 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 199 * 200 {(-9.6633464566929,33.2677165354331,-28.0562924700614)(-9.5222047244094,33.2677165354331,-27.9151507377779)(-9.381062992126,33.2677165354331,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(26) = edge55
Dim edge56 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 198 * 200 {(-9.381062992126,33.2677165354331,-28.0562924700614)(-9.5222047244094,33.2677165354331,-28.1974342023448)(-9.6633464566929,33.2677165354331,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(27) = edge56
Dim edge57 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 1 * 2 {(7.8779527559055,33.2677165354331,-27.9004656984078)(7.8779527559055,33.3070866141732,-27.9004656984078)(7.8779527559055,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(28) = edge57
Dim edge58 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 1 * 200 {(8.4685039370079,33.2677165354331,-27.9004656984078)(8.1732283464567,33.2677165354331,-27.6051901078566)(7.8779527559055,33.2677165354331,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(29) = edge58
Dim edge59 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 1 * 2 1 {(8.4685039370079,33.2677165354331,-27.9004656984078)(8.4685039370079,33.3070866141732,-27.9004656984078)(8.4685039370079,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(30) = edge59
Dim edge60 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 2 * 200 {(7.8779527559055,33.2677165354331,-27.9004656984078)(8.1732283464567,33.2677165354331,-28.195741288959)(8.4685039370079,33.2677165354331,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(31) = edge60
Dim edge61 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 3 * 4 {(2.8700787401575,33.2677165354331,-27.9004656984078)(2.8700787401575,33.3070866141732,-27.9004656984078)(2.8700787401575,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(32) = edge61
Dim edge62 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 200 * 3 {(3.4606299212598,33.2677165354331,-27.9004656984078)(3.1653543307087,33.2677165354331,-27.6051901078566)(2.8700787401575,33.2677165354331,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(33) = edge62
Dim edge63 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 3 * 4 1 {(3.4606299212598,33.2677165354331,-27.9004656984078)(3.4606299212598,33.3070866141732,-27.9004656984078)(3.4606299212598,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(34) = edge63
Dim edge64 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 200 * 4 {(2.8700787401575,33.2677165354331,-27.9004656984078)(3.1653543307087,33.2677165354331,-28.195741288959)(3.4606299212598,33.2677165354331,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(35) = edge64
Dim edge65 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 5 * 6 {(0.8110236220472,33.2677165354331,-27.9004656984078)(0.8110236220472,33.3070866141732,-27.9004656984078)(0.8110236220472,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(36) = edge65
Dim edge66 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 200 * 5 {(1.4015748031496,33.2677165354331,-27.9004656984078)(1.1062992125984,33.2677165354331,-27.6051901078566)(0.8110236220472,33.2677165354331,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(37) = edge66
Dim edge67 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 5 * 6 1 {(1.4015748031496,33.2677165354331,-27.9004656984078)(1.4015748031496,33.3070866141732,-27.9004656984078)(1.4015748031496,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(38) = edge67
Dim edge68 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 200 * 6 {(0.8110236220472,33.2677165354331,-27.9004656984078)(1.1062992125984,33.2677165354331,-28.195741288959)(1.4015748031496,33.2677165354331,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(39) = edge68
Dim edge69 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 7 * 8 {(-8.0935433070866,33.2677165354331,-27.9004656984078)(-8.0935433070866,33.3070866141732,-27.9004656984078)(-8.0935433070866,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(40) = edge69
Dim edge70 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 200 * 7 {(-7.5029921259843,33.2677165354331,-27.9004656984078)(-7.7982677165354,33.2677165354331,-27.6051901078566)(-8.0935433070866,33.2677165354331,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(41) = edge70
Dim edge71 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 7 * 8 1 {(-7.5029921259843,33.2677165354331,-27.9004656984078)(-7.5029921259843,33.3070866141732,-27.9004656984078)(-7.5029921259843,33.3464566929134,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(42) = edge71
Dim edge72 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 200 * 8 {(-8.0935433070866,33.2677165354331,-27.9004656984078)(-7.7982677165354,33.2677165354331,-28.195741288959)(-7.5029921259843,33.2677165354331,-27.9004656984078) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(43) = edge72
Dim edge73 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 198 * 203 {(-9.381062992126,33.3464566929134,-28.0562924700614)(-9.5222047244094,33.3464566929134,-28.1974342023448)(-9.6633464566929,33.3464566929134,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(44) = edge73
Dim edge74 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 198 * 199 {(-9.6633464566929,33.3464566929134,-28.0562924700614)(-9.6633464566929,33.3070866141732,-28.0562924700614)(-9.6633464566929,33.2677165354331,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(45) = edge74
Dim edge75 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 199 * 203 {(-9.6633464566929,33.3464566929134,-28.0562924700614)(-9.5222047244094,33.3464566929134,-27.9151507377779)(-9.381062992126,33.3464566929134,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(46) = edge75
Dim edge76 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 198 * 199 1 {(-9.381062992126,33.3464566929134,-28.0562924700614)(-9.381062992126,33.3070866141732,-28.0562924700614)(-9.381062992126,33.2677165354331,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(47) = edge76
Dim edge77 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 201 * 203 {(9.6633464566929,33.3464566929134,-28.0562924700614)(9.5222047244094,33.3464566929134,-28.1974342023448)(9.381062992126,33.3464566929134,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(48) = edge77
Dim edge78 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 201 * 202 {(9.381062992126,33.3464566929134,-28.0562924700614)(9.381062992126,33.3070866141732,-28.0562924700614)(9.381062992126,33.2677165354331,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(49) = edge78
Dim edge79 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 202 * 203 {(9.381062992126,33.3464566929134,-28.0562924700614)(9.5222047244094,33.3464566929134,-27.9151507377779)(9.6633464566929,33.3464566929134,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(50) = edge79
Dim edge80 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 201 * 202 1 {(9.6633464566929,33.3464566929134,-28.0562924700614)(9.6633464566929,33.3070866141732,-28.0562924700614)(9.6633464566929,33.2677165354331,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(51) = edge80
Dim edge81 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 196 * 203 {(0.1411417322835,33.3464566929134,-28.0562924700614)(0,33.3464566929134,-28.1974342023448)(-0.1411417322835,33.3464566929134,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(52) = edge81
Dim edge82 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 196 * 197 {(-0.1411417322835,33.3464566929134,-28.0562924700614)(-0.1411417322835,33.3070866141732,-28.0562924700614)(-0.1411417322835,33.2677165354331,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(53) = edge82
Dim edge83 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 197 * 203 {(-0.1411417322835,33.3464566929134,-28.0562924700614)(-0,33.3464566929134,-27.9151507377779)(0.1411417322835,33.3464566929134,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(54) = edge83
Dim edge84 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 196 * 197 1 {(0.1411417322835,33.3464566929134,-28.0562924700614)(0.1411417322835,33.3070866141732,-28.0562924700614)(0.1411417322835,33.2677165354331,-28.0562924700614) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(55) = edge84
Dim edge85 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 191 * 192 {(-10.2347646533386,33.2677165354331,-28.3171643596007)(-10.2347646533386,33.3070866141732,-28.3171643596007)(-10.2347646533386,33.3464566929134,-28.3171643596007) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(56) = edge85
Dim edge86 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 192 * 193 {(-10.1954237052559,33.2677165354331,-28.3580486721362)(-10.1954237052559,33.3070866141732,-28.3580486721362)(-10.1954237052559,33.3464566929134,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(57) = edge86
Dim edge87 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 193 * 194 {(-9.3300393700787,33.3464566929134,-28.3580486721362)(-9.3300393700787,33.3070866141732,-28.3580486721362)(-9.3300393700787,33.2677165354331,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(58) = edge87
Dim edge88 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 193 * 203 {(-10.1954237052559,33.3464566929134,-28.3580486721362)(-9.7627315376673,33.3464566929134,-28.3580486721362)(-9.3300393700787,33.3464566929134,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(59) = edge88
Dim edge89 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 194 * 195 {(9.3286496062992,33.3464566929134,-28.3580486721362)(9.3286496062992,33.3070866141732,-28.3580486721362)(9.3286496062992,33.2677165354331,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(60) = edge89
Dim edge90 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 194 * 203 {(-9.3300393700787,33.3464566929134,-28.3580486721362)(-0.0006948818898,33.3464566929134,-28.3580486721362)(9.3286496062992,33.3464566929134,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(61) = edge90
Dim edge91 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 195 * 200 {(10.1954237054606,33.2677165354331,-28.3580486721362)(9.7620366558799,33.2677165354331,-28.3580486721362)(9.3286496062992,33.2677165354331,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(62) = edge91
Dim edge92 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 195 * 204 {(10.1954237054606,33.2677165354331,-28.3580486721362)(10.1954237054606,33.3070866141732,-28.3580486721362)(10.1954237054606,33.3464566929134,-28.3580486721362) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(63) = edge92
Dim edge93 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 191 * 212 {(-9.1725590551181,33.3464566929134,-27.2950565461519)(-9.1725590551181,33.3070866141732,-27.2950565461519)(-9.1725590551181,33.2677165354331,-27.2950565461519) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(64) = edge93
Dim edge94 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 190 * 200 {(-9.1725590551181,33.2677165354331,-27.2950565461519)(0.0000098354681,33.2677165354331,-27.2950565461519)(9.1725787260543,33.2677165354331,-27.2950565461519) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(65) = edge94
Dim edge95 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 190 * 212 {(-9.1725590551181,33.2677165354331,-27.1923982035346)(-9.1725590551181,33.2677165354331,-27.2437273748433)(-9.1725590551181,33.2677165354331,-27.2950565461519) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(66) = edge95
Dim edge96 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 212 * 213 {(-9.1725590551181,33.3464566929134,-27.1923982035346)(-9.1725590551181,33.3464566929134,-27.2437273748433)(-9.1725590551181,33.3464566929134,-27.2950565461519) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(67) = edge96
Dim edge97 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 206 * 213 {(9.1725799225669,33.3464566929134,-27.1923982046533)(9.1725799225669,33.3464566929134,-27.2437273754026)(9.1725799225669,33.3464566929134,-27.2950565461519) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(68) = edge97
Dim edge98 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 190 * 206 {(9.1725314102181,33.2677165354331,-27.1923981963951)(9.1725560854716,33.2677165354331,-27.2437273659918)(9.1725787260541,33.2677165354331,-27.295056536405) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(69) = edge98
Dim edge99 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 189 * 207 {(9.1724964527729,33.2677165354304,-26.4837367861882)(9.1724964527729,33.2677165354305,-26.8380674948614)(9.1724964527729,33.2677165354305,-27.1923982035346) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(70) = edge99
Dim edge100 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 207 * 208 {(9.1725799225422,33.3464566707925,-26.4837367862118)(9.17255359718,33.3216229782574,-26.4835224895229)(9.1724964527729,33.2677165354304,-26.4837367861882) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(71) = edge100
Dim edge101 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 207 * 214 {(9.1725642719724,33.3464566929134,-26.4837367860966)(9.1725720972684,33.3464566929134,-26.8380674948156)(9.1725799225645,33.3464566929134,-27.1923982035346) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(72) = edge101
Dim edge102 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 209 * 214 {(-9.1725590551181,33.3464566929134,-26.4837367862118)(0.0000002385911,33.3464566901483,-26.4837367862118)(9.1725595323002,33.3464566873832,-26.4837367862118) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(73) = edge102
Dim edge103 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 211 * 212 {(-9.1725590551181,33.3464566929134,-27.1923982035346)(-9.1725590551181,33.3070866141732,-27.1923982035346)(-9.1725590551181,33.2677165354331,-27.1923982035346) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(74) = edge103
Dim edge104 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 211 * 214 {(-9.1725590551181,33.3464566929134,-26.4837367862118)(-9.1725590551181,33.3464566929134,-26.8380674948732)(-9.1725590551181,33.3464566929134,-27.1923982035346) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(75) = edge104
Dim edge105 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 189 * 190 {(-9.1725590551181,33.2677165354331,-27.1923982035346)(-0.0000138224478,33.2677165354331,-27.1923982035346)(9.1725314102225,33.2677165354331,-27.1923982035346) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(76) = edge105
Dim edge106 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 189 * 211 {(-9.1725590551181,33.2677165354331,-26.4837367862118)(-9.1725590551181,33.2677165354331,-26.8380674948732)(-9.1725590551181,33.2677165354331,-27.1923982035346) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(77) = edge106
Dim edge107 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 213 * 214 {(-9.1725590551181,33.3464566929134,-27.1923982035346)(0.0000054844085,33.3464566929134,-27.1923982035346)(9.1725700239351,33.3464566929134,-27.1923982035346) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(78) = edge107
Dim edge108 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 206 * 207 {(9.1725799225603,33.3464566872741,-27.1923982048321)(9.1725556664013,33.3070866226981,-27.1923982014634)(9.1725314102424,33.2677165581221,-27.1923981980948) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(79) = edge108
Dim edge109 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 210 * 211 {(-9.1725590551181,33.3464566929134,-26.4837367862118)(-9.1725590551181,33.3070866141732,-26.4837367862118)(-9.1725590551181,33.2677165354331,-26.4837367862118) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(80) = edge109
Dim edge110 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 188 * 189 {(-9.1725590551181,33.2677165354331,-26.4837367862118)(-0.0000203689734,33.2677165381981,-26.4837367862001)(9.1725183171714,33.2677165409632,-26.4837367861883) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(81) = edge110
Dim edge111 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 188 * 210 {(-9.1725590551181,33.2677165354331,-26.3810784435945)(-9.1725590551181,33.2677165354331,-26.4324076149031)(-9.1725590551181,33.2677165354331,-26.4837367862118) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(82) = edge111
Dim edge112 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 209 * 210 {(-9.1725590551181,33.3464566929134,-26.3810784435945)(-9.1725590551181,33.3464566929134,-26.4324076149031)(-9.1725590551181,33.3464566929134,-26.4837367862118) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(83) = edge112
Dim edge113 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 208 * 209 {(9.1725590551181,33.3464566929134,-26.3810784539801)(9.1725642719738,33.3464566929134,-26.432407623154)(9.1725694888419,33.3464566929134,-26.4837367923259) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(84) = edge113
Dim edge114 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 188 * 208 {(9.1725578239463,33.2677165354331,-26.3810784460483)(9.1725404027728,33.2677165354331,-26.4324076190241)(9.1725209255923,33.2677165354331,-26.4837367914521) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(85) = edge114
Dim edge115 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 103 * 104 {(10.3368197599241,33.2677165354331,-25.3180854430022)(10.6911504685856,33.2677165354331,-25.3180854430022)(11.045481177247,33.2677165354331,-25.3180854430022) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(86) = edge115
Dim edge116 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 102 * 103 {(11.3012891514767,33.2677165354331,-1.5852089976914)(10.8190544557004,33.2677165354331,-1.5852132999695)(10.3368197599241,33.2677165354331,-1.5852176022477) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(87) = edge116
Dim edge117 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 103 * 94 {(11.1242213347273,33.2677165354331,-3.5385579096183)(11.1242213347273,33.2677165354331,-2.7462350749727)(11.1242213347273,33.2677165354331,-1.953912240327) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(88) = edge117
Dim edge118 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 103 * 108 {(11.045481177247,33.2677165354331,-25.3180854430022)(11.045481177247,33.2677165354331,-25.2984004036321)(11.045481177247,33.2677165354331,-25.278715364262) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(89) = edge118
Dim edge119 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 108 * 109 {(11.045481177247,33.3464566929134,-25.3180854430022)(11.045481177247,33.3464566929134,-25.2984004036321)(11.045481177247,33.3464566929134,-25.278715364262) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(90) = edge119
Dim edge120 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 109 * 88 {(11.045481177247,33.3464566929134,-3.5779281413368)(11.045481177247,33.3464566929134,-14.4283217527994)(11.045481177247,33.3464566929134,-25.278715364262) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(91) = edge120
Dim edge121 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 109 * 92 {(11.0848512559871,33.3464566929134,-3.5385579096183)(11.0570123522482,33.3464566929134,-3.5500891927915)(11.0454811772473,33.3464566929134,-3.5779281413368) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(92) = edge121
Dim edge122 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 109 * 93 {(11.1242213347273,33.3464566929134,-3.5385579096183)(11.1045362953572,33.3464566929134,-3.5385579096183)(11.0848512559871,33.3464566929134,-3.5385579096183) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(93) = edge122
Dim edge123 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 109 * 110 {(11.3012843803506,33.3464566929134,-1.5851950817481)(11.1707813923744,33.3464566929134,-1.749398386789)(11.1242213347273,33.3464566929134,-1.953912240327) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(94) = edge123
Dim edge124 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 109 * 123 {(10.3368197599241,33.3464566929134,-25.3180854430022)(10.3368197599241,33.3464566929134,-13.451651522625)(10.3368197599241,33.3464566929134,-1.5852176022479) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(95) = edge124
Dim edge125 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 103 * 90 {(11.045481177247,33.2677165354331,-25.278715364262)(11.045481177247,33.2677165354331,-14.4283217527986)(11.045481177247,33.2677165354331,-3.5779281413353) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(96) = edge125
Dim edge126 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 40 * 90 {(11.0854136843647,33.2677165354331,-3.6172980670986)(11.1167766021145,33.2677165354331,-3.6172980670986)(11.1481395198643,33.2677165354331,-3.6172980670986) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(97) = edge126
Dim edge127 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 84 * 90 {(11.1481395198643,33.2677165354331,-25.278715364262)(11.1481395198643,33.2677165354331,-14.4480067156803)(11.1481395198643,33.2677165354331,-3.6172980670987) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(98) = edge127
Dim edge128 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 89 * 90 {(11.1481395198643,33.2677165354331,-25.278715364262)(11.0968103485556,33.2677165354331,-25.278715364262)(11.045481177247,33.2677165354331,-25.278715364262) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(99) = edge128
Dim edge129 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 91 * 92 {(11.0454811772473,33.2677165354331,-3.5779281413353)(11.0454811772473,33.3070866141732,-3.5779281413355)(11.0454811772473,33.3464566929134,-3.5779281413357) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(100) = edge129
Dim edge130 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 103 * 92 {(11.0848512559871,33.2677165354331,-3.5385579096183)(11.0570123522487,33.2677165354331,-3.550089192791)(11.0454811772473,33.2677165354331,-3.5779281413353) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(101) = edge130
Dim edge131 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 92 * 93 {(11.0848512559871,33.3464566929134,-3.5385579096183)(11.0848512559871,33.3070866141732,-3.5385579096183)(11.0848512559871,33.2677165354331,-3.5385579096183) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(102) = edge131
Dim edge132 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 103 * 93 {(11.1242213347273,33.2677165354331,-3.5385579096183)(11.1045362953572,33.2677165354331,-3.5385579096183)(11.0848512559871,33.2677165354331,-3.5385579096183) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(103) = edge132
Dim edge133 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 93 * 94 {(11.1242213347273,33.2677165354331,-3.5385579096183)(11.1242213347273,33.3070866141732,-3.5385579096183)(11.1242213347273,33.3464566929134,-3.5385579096183) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(104) = edge133
Dim edge134 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 110 * 94 {(11.1242213347273,33.3464566929134,-1.953912240327)(11.1242213347273,33.3070866141732,-1.953912240327)(11.1242213347273,33.2677165354331,-1.953912240327) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(105) = edge134
Dim edge135 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 109 * 94 {(11.1242213347273,33.3464566929134,-3.5385579096183)(11.1242213347273,33.3464566929134,-2.7462350749727)(11.1242213347273,33.3464566929134,-1.953912240327) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(106) = edge135
Dim edge136 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 103 * 110 {(11.301275550317,33.2677165354331,-1.5852021556277)(11.1707789435339,33.2677165354331,-1.7494034863475)(11.1242213347273,33.2677165354331,-1.953912240327) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(107) = edge136
Dim edge137 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 110 * 111 {(11.3012992334504,33.3464566877164,-1.5851831834781)(11.3012945212807,33.3070866097361,-1.585186958117)(11.3012898091592,33.2677165317559,-1.5851907328161) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(108) = edge137
Dim edge138 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 101 * 102 {(11.3212474996999,33.2677165354331,-1.5651119589752)(10.8290336077669,33.2677165354331,-1.5651119589752)(10.3368197158338,33.2677165354331,-1.5651119589752) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(109) = edge138
Dim edge139 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 102 * 118 {(10.3368197599241,33.2677165354331,-1.5699205765846)(10.3368197599241,33.2677165354331,-1.5775690894162)(10.3368197599241,33.2677165354331,-1.5852176022479) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(110) = edge139
Dim edge140 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 102 * 95 {(10.3368197599241,33.2677165354331,-1.5651119589752)(10.3368197599241,33.2677165354331,-1.5675162677799)(10.3368197599241,33.2677165354331,-1.5699205765846) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(111) = edge140
Dim edge141 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 117 * 118 {(10.3368197599241,33.3464566929134,-1.5699173418394)(10.3368197599241,33.3464566929134,-1.5775674720436)(10.3368197599241,33.3464566929134,-1.5852176022478) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(112) = edge141
Dim edge142 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 118 * 119 {(10.3368197599241,33.3464566929134,-1.5852176022479)(10.3368197599241,33.3070866141732,-1.5852176022479)(10.3368197599241,33.2677165354331,-1.5852176022479) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(113) = edge142
Dim edge143 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 105 * 124 {(10.3368197599241,33.3462872054098,-25.3180863176102)(10.3368197599241,33.3070018704214,-25.3180863176102)(10.3368197599241,33.2677165354331,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(114) = edge143
Dim edge144 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 104 * 105 {(10.3368197599241,33.2677165354331,-25.3180854430022)(10.3368197599241,33.2677165354331,-26.1937923542403)(10.3368197599241,33.2677165354331,-27.0694992654784) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(115) = edge144
Dim edge145 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 105 * 106 {(10.3368197599241,33.3464566929134,-25.3180854430022)(10.3368197599241,33.3464566929134,-26.1937923542403)(10.3368197599241,33.3464566929134,-27.0694992654784) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(116) = edge145
Dim edge146 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 106 * 39 {(10.3368197599241,33.3464566929134,-27.0694992654784)(10.6911504685856,33.3464566929134,-27.0694992654784)(11.045481177247,33.3464566929134,-27.0694992654784) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(117) = edge146
Dim edge147 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 106 * 107 {(11.045481177247,33.3464566929134,-25.3180854430022)(11.045481177247,33.3464566929134,-26.1937923542403)(11.045481177247,33.3464566929134,-27.0694992654784) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(118) = edge147
Dim edge148 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 106 * 109 {(10.3368197599241,33.3464566929134,-25.3180854430022)(10.6911504685856,33.3464566929134,-25.3180854430022)(11.045481177247,33.3464566929134,-25.3180854430022) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(119) = edge148
Dim edge149 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 105 * 39 {(10.3368197599241,33.3464566929134,-27.0694992654784)(10.3368197599241,33.3070866141732,-27.0694992654784)(10.3368197599241,33.2677165354331,-27.0694992654784) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(120) = edge149
Dim edge150 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 104 * 39 {(10.3368197599241,33.2677165354331,-27.0694992654784)(10.6911504685856,33.2677165354331,-27.0694992654784)(11.045481177247,33.2677165354331,-27.0694992654784) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(121) = edge150
Dim edge151 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 109 * 117 {(11.3012978401502,33.3464566929134,-1.5852089977519)(10.8190588000372,33.3464566929134,-1.5852132999998)(10.3368197599241,33.3464566929134,-1.5852176022477) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(122) = edge151
Dim edge152 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 111 * 117 {(11.3212423437177,33.3464566929134,-1.5651068471892)(11.3112730685386,33.3464566929134,-1.5751623164255)(11.3013037933595,33.3464566929134,-1.5852177856618) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(123) = edge152
Dim edge153 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 88 * 91 {(11.045481177247,33.3464566929134,-3.5779281413357)(11.0572785808394,33.3464566929134,-3.6058653114857)(11.0854136843647,33.3464566929134,-3.6172980670986) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(124) = edge153
Dim edge154 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 117 * 95 {(10.3368197599241,33.3464566929134,-1.565111958975)(10.3368197599241,33.3464566929134,-1.5675146504072)(10.3368197599241,33.3464566929134,-1.5699173418394) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(125) = edge154
Dim edge155 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 118 * 95 {(10.3368197599241,33.3464560645783,-1.5699173418394)(10.3368197599241,33.3070863000057,-1.5699189592054)(10.3368197599241,33.2677165354331,-1.5699205765714) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(126) = edge155
Dim edge156 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 108 * 89 {(11.045481177247,33.3464566929134,-25.278715364262)(11.045481177247,33.3070866141732,-25.278715364262)(11.045481177247,33.2677165354331,-25.278715364262) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(127) = edge156
Dim edge157 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 76 * 89 {(11.1481395198643,33.3464566929134,-25.278715364262)(11.1481395198643,33.3070866141732,-25.278715364262)(11.1481395198643,33.2677165354331,-25.278715364262) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(128) = edge157
Dim edge158 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 88 * 89 {(11.1481395198643,33.3464566929134,-25.278715364262)(11.0968103485556,33.3464566929134,-25.278715364262)(11.045481177247,33.3464566929134,-25.278715364262) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(129) = edge158
Dim edge159 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 107 * 39 {(11.045481177247,33.3464566929134,-27.0694992654784)(11.045481177247,33.3070866141732,-27.0694992654784)(11.045481177247,33.2677165354331,-27.0694992654784) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(130) = edge159
Dim edge160 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 104 * 107 {(11.045481177247,33.2677165354331,-25.3180854430022)(11.045481177247,33.2677165354331,-26.1937923542403)(11.045481177247,33.2677165354331,-27.0694992654784) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(131) = edge160
Dim edge161 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 107 * 108 {(11.045481177247,33.3464566929134,-25.3180854430022)(11.045481177247,33.3070866141732,-25.3180854430022)(11.045481177247,33.2677165354331,-25.3180854430022) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(132) = edge161
Dim edge162 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 79 * 84 {(12.0142812521478,33.2677165354331,-24.9999987316912)(11.9912187939735,33.2677165354331,-24.9443210323851)(11.9355410946674,33.2677165354331,-24.9212585742109) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(133) = edge162
Dim edge163 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 78 * 84 {(12.0142812521478,33.2677165354331,-25.2393452855219)(12.0142812521478,33.2677165354331,-25.1196720086065)(12.0142812521478,33.2677165354331,-24.9999987316912) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(134) = edge163
Dim edge164 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 77 * 84 {(11.9749111734076,33.2677165354331,-25.278715364262)(12.0027500230606,33.2677165354331,-25.2671841351749)(12.0142812521478,33.2677165354331,-25.2393452855219) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(135) = edge164
Dim edge165 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 76 * 84 {(11.1481395198643,33.2677165354331,-25.278715364262)(11.5615253466359,33.2677165354331,-25.278715364262)(11.9749111734076,33.2677165354331,-25.278715364262) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(136) = edge165
Dim edge166 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 42 * 84 {(11.5031749529352,33.2677165354331,-3.696038224579)(11.4801124947609,33.2677165354331,-3.6403605252729)(11.4244347954548,33.2677165354331,-3.6172980670987) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(137) = edge166
Dim edge167 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 44 * 84 {(11.7984505434863,33.2677165354331,-4.2519672356282)(11.5896591710887,33.2677165354331,-4.1654830174746)(11.5031749529352,33.2677165354331,-3.956691645077) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(138) = edge167
Dim edge168 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 45 * 84 {(11.9355410946674,33.2677165354331,-4.2519672356282)(11.8669958190769,33.2677165354331,-4.2519672356282)(11.7984505434863,33.2677165354331,-4.2519672356282) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(139) = edge168
Dim edge169 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 46 * 84 {(12.0142812521478,33.2677165354331,-4.3307073931085)(11.9912187939735,33.2677165354331,-4.2750296938025)(11.9355410946674,33.2677165354331,-4.2519672356282) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(140) = edge169
Dim edge170 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 47 * 84 {(12.0142812521478,33.2677165354331,-7.716534164762)(12.0142812521478,33.2677165354331,-6.0236207789353)(12.0142812521478,33.2677165354331,-4.3307073931085) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(141) = edge170
Dim edge171 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 48 * 84 {(11.9355410946674,33.2677165354331,-7.7952743222423)(11.9912187939735,33.2677165354331,-7.7722118640681)(12.0142812521478,33.2677165354331,-7.716534164762) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(142) = edge171
Dim edge172 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 50 * 84 {(11.7984505434863,33.2677165354331,-8.3858255033447)(11.5031749529352,33.2677165354331,-8.0905499127935)(11.7984505434863,33.2677165354331,-7.7952743222423) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(143) = edge172
Dim edge173 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 51 * 84 {(11.9355410946674,33.2677165354331,-8.3858255033447)(11.8669958190769,33.2677165354331,-8.3858255033447)(11.7984505434863,33.2677165354331,-8.3858255033447) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(144) = edge173
Dim edge174 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 52 * 84 {(12.0142812521478,33.2677165354331,-8.464565660825)(11.9912187939735,33.2677165354331,-8.408887961519)(11.9355410946674,33.2677165354331,-8.3858255033447) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(145) = edge174
Dim edge175 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 53 * 84 {(12.0142812521478,33.2677165354331,-11.8503924324786)(12.0142812521478,33.2677165354331,-10.1574790466518)(12.0142812521478,33.2677165354331,-8.464565660825) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(146) = edge175
Dim edge176 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 54 * 84 {(11.9355410946674,33.2677165354331,-11.9291325899589)(11.9912187939735,33.2677165354331,-11.9060701317846)(12.0142812521478,33.2677165354331,-11.8503924324786) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(147) = edge176
Dim edge177 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 56 * 84 {(11.7984505434863,33.2677165354331,-12.5196837710612)(11.5031749529352,33.2677165354331,-12.2244081805101)(11.7984505434863,33.2677165354331,-11.9291325899589) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(148) = edge177
Dim edge178 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 57 * 84 {(11.9355410946674,33.2677165354331,-12.5196837710612)(11.8669958190769,33.2677165354331,-12.5196837710613)(11.7984505434863,33.2677165354331,-12.5196837710613) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(149) = edge178
Dim edge179 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 58 * 84 {(12.0142812521478,33.2677165354331,-12.5984239285416)(11.9912187939735,33.2677165354331,-12.5427462292355)(11.9355410946674,33.2677165354331,-12.5196837710612) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(150) = edge179
Dim edge180 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 59 * 84 {(12.0142812521478,33.2677165354331,-15.9842507001951)(12.0142812521478,33.2677165354331,-14.2913373143683)(12.0142812521478,33.2677165354331,-12.5984239285416) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(151) = edge180
Dim edge181 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 60 * 84 {(11.9355410946674,33.2677165354331,-16.0629908576754)(11.9912187939735,33.2677165354331,-16.0399283995011)(12.0142812521478,33.2677165354331,-15.9842507001951) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(152) = edge181
Dim edge182 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 62 * 84 {(11.7984505434863,33.2677165354331,-16.6535420387778)(11.5031749529352,33.2677165354331,-16.3582664482266)(11.7984505434863,33.2677165354331,-16.0629908576754) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(153) = edge182
Dim edge183 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 63 * 84 {(11.9355410946674,33.2677165354331,-16.6535420387778)(11.8669958190769,33.2677165354331,-16.6535420387778)(11.7984505434863,33.2677165354331,-16.6535420387778) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(154) = edge183
Dim edge184 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 64 * 84 {(12.0142812521478,33.2677165354331,-16.7322821962581)(11.9912187939735,33.2677165354331,-16.6766044969521)(11.9355410946674,33.2677165354331,-16.6535420387778) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(155) = edge184
Dim edge185 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 65 * 84 {(12.0142812521478,33.2677165354331,-20.1181089679116)(12.0142812521478,33.2677165354331,-18.4251955820849)(12.0142812521478,33.2677165354331,-16.7322821962581) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(156) = edge185
Dim edge186 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 66 * 84 {(11.9355410946674,33.2677165354331,-20.196849125392)(11.9912187939735,33.2677165354331,-20.1737866672177)(12.0142812521478,33.2677165354331,-20.1181089679116) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(157) = edge186
Dim edge187 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 68 * 84 {(11.7984505434863,33.2677165354331,-20.7874003064943)(11.5031749529352,33.2677165354331,-20.4921247159431)(11.7984505434863,33.2677165354331,-20.196849125392) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(158) = edge187
Dim edge188 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 69 * 84 {(11.9355410946674,33.2677165354331,-20.7874003064943)(11.8669958190769,33.2677165354331,-20.7874003064943)(11.7984505434863,33.2677165354331,-20.7874003064943) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(159) = edge188
Dim edge189 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 70 * 84 {(12.0142812521478,33.2677165354331,-20.8661404639746)(11.9912187939735,33.2677165354331,-20.8104627646686)(11.9355410946674,33.2677165354331,-20.7874003064943) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(160) = edge189
Dim edge190 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 71 * 84 {(12.0142812521478,33.2677165354331,-24.2519672356282)(12.0142812521478,33.2677165354331,-22.5590538498014)(12.0142812521478,33.2677165354331,-20.8661404639746) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(161) = edge190
Dim edge191 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 72 * 84 {(11.9355410946674,33.2677165354331,-24.3307073931085)(11.9912187939735,33.2677165354331,-24.3076449349342)(12.0142812521478,33.2677165354331,-24.2519672356282) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(162) = edge191
Dim edge192 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 74 * 84 {(11.7984505434863,33.2677165354331,-24.9212585742109)(11.5031749529352,33.2677165354331,-24.6259829836597)(11.7984505434863,33.2677165354331,-24.3307073931085) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(163) = edge192
Dim edge193 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 75 * 84 {(11.9355410946674,33.2677165354331,-24.9212585742109)(11.8669958190769,33.2677165354331,-24.9212585742109)(11.7984505434863,33.2677165354331,-24.9212585742109) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(164) = edge193
Dim edge194 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 81 * 84 {(11.8301859700887,33.2677165354331,-13.7177550309038)(11.6890442378052,33.2677165354331,-13.8588967631872)(11.5479025055218,33.2677165354331,-13.7177550309038) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(165) = edge194
Dim edge195 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 80 * 84 {(11.5479025055218,33.2677165354331,-13.7177550309038)(11.6890442378052,33.2677165354331,-13.5766132986203)(11.8301859700887,33.2677165354331,-13.7177550309038) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(166) = edge195
Dim edge196 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 84 * 86 {(11.8301859700887,33.2677165354331,-4.7126369206675)(11.6890442378052,33.2677165354331,-4.853778652951)(11.5479025055218,33.2677165354331,-4.7126369206675) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(167) = edge196
Dim edge197 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 84 * 85 {(11.5479025055218,33.2677165354331,-4.7126369206675)(11.6890442378052,33.2677165354331,-4.5714951883841)(11.8301859700887,33.2677165354331,-4.7126369206675) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(168) = edge197
Dim edge198 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 83 * 84 {(11.8301859700887,33.2677165354331,-22.72287314114)(11.6890442378052,33.2677165354331,-22.8640148734235)(11.5479025055218,33.2677165354331,-22.72287314114) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(169) = edge198
Dim edge199 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 82 * 84 {(11.5479025055218,33.2677165354331,-22.72287314114)(11.6890442378052,33.2677165354331,-22.5817314088565)(11.8301859700887,33.2677165354331,-22.72287314114) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(170) = edge199
Dim edge200 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 40 * 88 {(11.0854136843647,33.3464566929134,-3.6172980670986)(11.1167766021145,33.3464566929134,-3.6172980670986)(11.1481395198643,33.3464566929134,-3.6172980670986) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(171) = edge200
Dim edge201 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 40 * 91 {(11.0854136843647,33.2677165354331,-3.6172980670986)(11.0854136843647,33.3070866141732,-3.6172980670986)(11.0854136843647,33.3464566929134,-3.6172980670986) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(172) = edge201
Dim edge202 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 90 * 91 {(11.045481177247,33.2677165354331,-3.5779281413357)(11.0572785808394,33.2677165354331,-3.6058653114857)(11.0854136843647,33.2677165354331,-3.6172980670986) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(173) = edge202
Dim edge203 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 102 * 111 {(11.3212413655362,33.2677165354331,-1.5651058773926)(11.3112681245749,33.2677165354331,-1.5751653466992)(11.3012948836136,33.2677165354331,-1.5852248160057) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(174) = edge203
Dim edge204 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 111 * 112 {(11.3212474996999,33.3464566931698,-1.5651016466285)(11.3212474996999,33.3070866144538,-1.5651006684108)(11.3212474996999,33.2677165357378,-1.5650996901931) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(175) = edge204
Dim edge205 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 101 * 113 {(11.3212474996999,33.2677165354327,-1.5492494822526)(11.3157077965415,33.2677165354327,-1.5028781852646)(11.2994004803069,33.2677165354327,-1.4591168217956) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(176) = edge205
Dim edge206 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 101 * 99 {(10.3013866449676,33.267716535433,-1.4357744347208)(10.3108086258029,33.2677165354332,-1.4731241708847)(10.3368197158028,33.2677165354333,-1.501535431177) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(177) = edge206
Dim edge207 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 101 * 97 {(10.32398205524,33.2677165354323,-0.7024621697863)(10.3072541099051,33.2677165354323,-0.7278429907198)(10.3013866449676,33.2677165354323,-0.7576688701132) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(178) = edge207
Dim edge208 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 116 * 97 {(10.3013866449676,33.3464566929128,-0.757668870113)(10.3072541099051,33.3464566929128,-0.7278429907196)(10.32398205524,33.3464566929128,-0.7024621697861) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(179) = edge208
Dim edge209 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 116 * 98 {(10.3013866449676,33.3464566929141,-1.435774434721)(10.3013866449676,33.3464566929141,-1.096721652417)(10.3013866449676,33.346456692914,-0.757668870113) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(180) = edge209
Dim edge210 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 116 * 99 {(10.3368197158029,33.3464566929139,-1.5015354311765)(10.3108086258032,33.3464566929138,-1.4731241708846)(10.3013866449676,33.3464566929136,-1.435774434721) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(181) = edge210
Dim edge211 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 100 * 116 {(10.3368197158338,33.3464566929136,-1.565111958975)(10.3368197158459,33.3464566929136,-1.5333236950763)(10.3368197158581,33.3464566929136,-1.5015354311776) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(182) = edge211
Dim edge212 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 116 * 117 {(11.3212474996999,33.3464566929136,-1.565111958975)(10.8290336077668,33.3464566929136,-1.565111958975)(10.3368197158338,33.3464566929136,-1.565111958975) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(183) = edge212
Dim edge213 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 112 * 116 {(11.3212474996999,33.3464566929132,-1.5492494822524)(11.3212474996999,33.3464566929132,-1.5571807206137)(11.3212474996999,33.3464566929132,-1.565111958975) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(184) = edge213
Dim edge214 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 113 * 116 {(11.299400480307,33.3464566929132,-1.4591168217957)(11.3157077965415,33.3464566929132,-1.5028781852645)(11.3212474996999,33.3464566929132,-1.5492494822524) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(185) = edge214
Dim edge215 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 79 * 87 {(11.9355410946674,33.3464566929134,-24.9212585742109)(11.9912187939735,33.3464566929134,-24.9443210323851)(12.0142812521478,33.3464566929134,-24.9999987316912) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(186) = edge215
Dim edge216 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 74 * 87 {(11.7984505434863,33.3464566929134,-24.3307073931085)(11.5031749529352,33.3464566929134,-24.6259829836597)(11.7984505434863,33.3464566929134,-24.9212585742109) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(187) = edge216
Dim edge217 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 73 * 87 {(11.9355410946674,33.3464566929134,-24.3307073931085)(11.8669958190769,33.3464566929134,-24.3307073931085)(11.7984505434863,33.3464566929134,-24.3307073931085) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(188) = edge217
Dim edge218 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 72 * 87 {(12.0142812521478,33.3464566929134,-24.2519672356282)(11.9912187939735,33.3464566929134,-24.3076449349342)(11.9355410946674,33.3464566929134,-24.3307073931085) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(189) = edge218
Dim edge219 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 70 * 87 {(11.9355410946674,33.3464566929134,-20.7874003064943)(11.9912187939735,33.3464566929134,-20.8104627646686)(12.0142812521478,33.3464566929134,-20.8661404639746) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(190) = edge219
Dim edge220 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 68 * 87 {(11.7984505434863,33.3464566929134,-20.196849125392)(11.5031749529352,33.3464566929134,-20.4921247159431)(11.7984505434863,33.3464566929134,-20.7874003064943) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(191) = edge220
Dim edge221 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 67 * 87 {(11.9355410946674,33.3464566929134,-20.196849125392)(11.8669958190769,33.3464566929134,-20.196849125392)(11.7984505434863,33.3464566929134,-20.196849125392) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(192) = edge221
Dim edge222 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 66 * 87 {(12.0142812521478,33.3464566929134,-20.1181089679116)(11.9912187939735,33.3464566929134,-20.1737866672177)(11.9355410946674,33.3464566929134,-20.196849125392) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(193) = edge222
Dim edge223 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 64 * 87 {(11.9355410946674,33.3464566929134,-16.6535420387778)(11.9912187939735,33.3464566929134,-16.6766044969521)(12.0142812521478,33.3464566929134,-16.7322821962581) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(194) = edge223
Dim edge224 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 62 * 87 {(11.7984505434863,33.3464566929134,-16.0629908576754)(11.5031749529352,33.3464566929134,-16.3582664482266)(11.7984505434863,33.3464566929134,-16.6535420387778) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(195) = edge224
Dim edge225 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 61 * 87 {(11.9355410946674,33.3464566929134,-16.0629908576754)(11.8669958190769,33.3464566929134,-16.0629908576754)(11.7984505434863,33.3464566929134,-16.0629908576754) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(196) = edge225
Dim edge226 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 60 * 87 {(12.0142812521478,33.3464566929134,-15.9842507001951)(11.9912187939735,33.3464566929134,-16.0399283995011)(11.9355410946674,33.3464566929134,-16.0629908576754) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(197) = edge226
Dim edge227 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 58 * 87 {(11.9355410946674,33.3464566929134,-12.5196837710612)(11.9912187939735,33.3464566929134,-12.5427462292355)(12.0142812521478,33.3464566929134,-12.5984239285416) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(198) = edge227
Dim edge228 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 56 * 87 {(11.7984505434863,33.3464566929134,-11.9291325899589)(11.5031749529352,33.3464566929134,-12.2244081805101)(11.7984505434863,33.3464566929134,-12.5196837710612) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(199) = edge228
Dim edge229 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 55 * 87 {(11.9355410946674,33.3464566929134,-11.9291325899589)(11.8669958190769,33.3464566929134,-11.9291325899589)(11.7984505434863,33.3464566929134,-11.9291325899589) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(200) = edge229
Dim edge230 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 54 * 87 {(12.0142812521478,33.3464566929134,-11.8503924324786)(11.9912187939735,33.3464566929134,-11.9060701317846)(11.9355410946674,33.3464566929134,-11.9291325899589) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(201) = edge230
Dim edge231 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 52 * 87 {(11.9355410946674,33.3464566929134,-8.3858255033447)(11.9912187939735,33.3464566929134,-8.408887961519)(12.0142812521478,33.3464566929134,-8.464565660825) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(202) = edge231
Dim edge232 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 50 * 87 {(11.7984505434863,33.3464566929134,-7.7952743222423)(11.5031749529352,33.3464566929134,-8.0905499127935)(11.7984505434863,33.3464566929134,-8.3858255033447) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(203) = edge232
Dim edge233 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 49 * 87 {(11.9355410946674,33.3464566929134,-7.7952743222424)(11.8669958190769,33.3464566929134,-7.7952743222424)(11.7984505434863,33.3464566929134,-7.7952743222424) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(204) = edge233
Dim edge234 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 48 * 87 {(12.0142812521478,33.3464566929134,-7.716534164762)(11.9912187939735,33.3464566929134,-7.7722118640681)(11.9355410946674,33.3464566929134,-7.7952743222423) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(205) = edge234
Dim edge235 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 46 * 87 {(11.9355410946674,33.3464566929134,-4.2519672356282)(11.9912187939735,33.3464566929134,-4.2750296938025)(12.0142812521478,33.3464566929134,-4.3307073931085) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(206) = edge235
Dim edge236 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 43 * 87 {(11.5031749529352,33.3464566929134,-3.696038224579)(11.5031749529352,33.3464566929134,-3.826364934828)(11.5031749529352,33.3464566929134,-3.956691645077) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(207) = edge236
Dim edge237 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 42 * 87 {(11.4244347954548,33.3464566929134,-3.6172980670987)(11.4801124947609,33.3464566929134,-3.6403605252729)(11.5031749529352,33.3464566929134,-3.696038224579) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(208) = edge237
Dim edge238 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 41 * 87 {(11.1481395198643,33.3464566929134,-3.6172980670986)(11.2862871576596,33.3464566929134,-3.6172980670986)(11.4244347954548,33.3464566929134,-3.6172980670986) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(209) = edge238
Dim edge239 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 87 * 88 {(11.1481395198643,33.3464566929134,-25.278715364262)(11.1481395198643,33.3464566929134,-14.4480067156803)(11.1481395198643,33.3464566929134,-3.6172980670987) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(210) = edge239
Dim edge240 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 77 * 87 {(12.0142812521478,33.3464566929134,-25.2393452855219)(12.0027500230606,33.3464566929134,-25.2671841351749)(11.9749111734076,33.3464566929134,-25.278715364262) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(211) = edge240
Dim edge241 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 100 * 99 {(10.3368197158574,33.267716535434,-1.5015354311697)(10.3368197158573,33.3070866141743,-1.5015354311696)(10.3368197158572,33.3464566929146,-1.5015354311695) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(212) = edge241
Dim edge242 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 100 * 101 {(10.3368197158338,33.2677165354331,-1.5651119589752)(10.336819715846,33.2677165354331,-1.5333236950765)(10.3368197158583,33.2677165354331,-1.5015354311778) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(213) = edge242
Dim edge243 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 100 * 95 {(10.3368197158338,33.3464566929136,-1.565111958975)(10.3368197158338,33.3070866141733,-1.565111958975)(10.3368197158338,33.2677165354331,-1.565111958975) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(214) = edge243
Dim edge244 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 76 * 87 {(11.1481395198643,33.3464566929134,-25.278715364262)(11.5615253466359,33.3464566929134,-25.278715364262)(11.9749111734076,33.3464566929134,-25.278715364262) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(215) = edge244
Dim edge245 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 82 * 87 {(11.5479025055218,33.3464566929134,-22.72287314114)(11.6890442378052,33.3464566929134,-22.5817314088565)(11.8301859700887,33.3464566929134,-22.72287314114) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(216) = edge245
Dim edge246 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 82 * 83 {(11.8301859700887,33.3464566929134,-22.72287314114)(11.8301859700887,33.3070866141732,-22.72287314114)(11.8301859700887,33.2677165354331,-22.72287314114) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(217) = edge246
Dim edge247 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 83 * 87 {(11.8301859700887,33.3464566929134,-22.72287314114)(11.6890442378052,33.3464566929134,-22.8640148734235)(11.5479025055218,33.3464566929134,-22.72287314114) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(218) = edge247
Dim edge248 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 82 * 83 1 {(11.5479025055218,33.3464566929134,-22.72287314114)(11.5479025055218,33.3070866141732,-22.72287314114)(11.5479025055218,33.2677165354331,-22.72287314114) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(219) = edge248
Dim edge249 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 85 * 87 {(11.5479025055218,33.3464566929134,-4.7126369206675)(11.6890442378052,33.3464566929134,-4.5714951883841)(11.8301859700887,33.3464566929134,-4.7126369206675) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(220) = edge249
Dim edge250 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 85 * 86 {(11.8301859700887,33.3464566929134,-4.7126369206675)(11.8301859700887,33.3070866141732,-4.7126369206675)(11.8301859700887,33.2677165354331,-4.7126369206675) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(221) = edge250
Dim edge251 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 86 * 87 {(11.8301859700887,33.3464566929134,-4.7126369206675)(11.6890442378052,33.3464566929134,-4.853778652951)(11.5479025055218,33.3464566929134,-4.7126369206675) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(222) = edge251
Dim edge252 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 85 * 86 1 {(11.5479025055218,33.3464566929134,-4.7126369206675)(11.5479025055218,33.3070866141732,-4.7126369206675)(11.5479025055218,33.2677165354331,-4.7126369206675) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(223) = edge252
Dim edge253 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 80 * 87 {(11.5479025055218,33.3464566929134,-13.7177550309038)(11.6890442378052,33.3464566929134,-13.5766132986203)(11.8301859700887,33.3464566929134,-13.7177550309038) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(224) = edge253
Dim edge254 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 80 * 81 {(11.8301859700887,33.3464566929134,-13.7177550309038)(11.8301859700887,33.3070866141732,-13.7177550309038)(11.8301859700887,33.2677165354331,-13.7177550309038) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(225) = edge254
Dim edge255 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 81 * 87 {(11.8301859700887,33.3464566929134,-13.7177550309038)(11.6890442378052,33.3464566929134,-13.8588967631872)(11.5479025055218,33.3464566929134,-13.7177550309038) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(226) = edge255
Dim edge256 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 80 * 81 1 {(11.5479025055218,33.3464566929134,-13.7177550309038)(11.5479025055218,33.3070866141732,-13.7177550309038)(11.5479025055218,33.2677165354331,-13.7177550309038) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(227) = edge256
Dim edge257 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 75 * 79 {(11.9355410946674,33.2677165354331,-24.9212585742109)(11.9355410946674,33.3070866141732,-24.9212585742109)(11.9355410946674,33.3464566929134,-24.9212585742109) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(228) = edge257
Dim edge258 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 74 * 75 {(11.7984505434863,33.3464566929134,-24.9212585742109)(11.7984505434863,33.3070866141732,-24.9212585742109)(11.7984505434863,33.2677165354331,-24.9212585742109) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(229) = edge258
Dim edge259 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 75 * 87 {(11.9355410946674,33.3464566929134,-24.9212585742109)(11.8669958190769,33.3464566929134,-24.9212585742109)(11.7984505434863,33.3464566929134,-24.9212585742109) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(230) = edge259
Dim edge260 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 73 * 74 {(11.7984505434863,33.3464566929134,-24.3307073931085)(11.7984505434863,33.3070866141732,-24.3307073931085)(11.7984505434863,33.2677165354331,-24.3307073931085) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(231) = edge260
Dim edge261 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 73 * 84 {(11.9355410946674,33.2677165354331,-24.3307073931085)(11.8669958190769,33.2677165354331,-24.3307073931085)(11.7984505434863,33.2677165354331,-24.3307073931085) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(232) = edge261
Dim edge262 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 72 * 73 {(11.9355410946674,33.2677165354331,-24.3307073931085)(11.9355410946674,33.3070866141732,-24.3307073931085)(11.9355410946674,33.3464566929134,-24.3307073931085) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(233) = edge262
Dim edge263 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 71 * 72 {(12.0142812521478,33.2677165354331,-24.2519672356282)(12.0142812521478,33.3070866141732,-24.2519672356282)(12.0142812521478,33.3464566929134,-24.2519672356282) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(234) = edge263
Dim edge264 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 71 * 87 {(12.0142812521478,33.3464566929134,-24.2519672356282)(12.0142812521478,33.3464566929134,-22.5590538498014)(12.0142812521478,33.3464566929134,-20.8661404639746) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(235) = edge264
Dim edge265 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 70 * 71 {(12.0142812521478,33.2677165354331,-20.8661404639746)(12.0142812521478,33.3070866141732,-20.8661404639746)(12.0142812521478,33.3464566929134,-20.8661404639746) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(236) = edge265
Dim edge266 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 69 * 70 {(11.9355410946674,33.2677165354331,-20.7874003064943)(11.9355410946674,33.3070866141732,-20.7874003064943)(11.9355410946674,33.3464566929134,-20.7874003064943) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(237) = edge266
Dim edge267 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 68 * 69 {(11.7984505434863,33.3464566929134,-20.7874003064943)(11.7984505434863,33.3070866141732,-20.7874003064943)(11.7984505434863,33.2677165354331,-20.7874003064943) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(238) = edge267
Dim edge268 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 69 * 87 {(11.9355410946674,33.3464566929134,-20.7874003064943)(11.8669958190769,33.3464566929134,-20.7874003064943)(11.7984505434863,33.3464566929134,-20.7874003064943) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(239) = edge268
Dim edge269 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 67 * 68 {(11.7984505434863,33.3464566929134,-20.196849125392)(11.7984505434863,33.3070866141732,-20.196849125392)(11.7984505434863,33.2677165354331,-20.196849125392) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(240) = edge269
Dim edge270 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 67 * 84 {(11.9355410946674,33.2677165354331,-20.196849125392)(11.8669958190769,33.2677165354331,-20.196849125392)(11.7984505434863,33.2677165354331,-20.196849125392) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(241) = edge270
Dim edge271 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 66 * 67 {(11.9355410946674,33.2677165354331,-20.196849125392)(11.9355410946674,33.3070866141732,-20.196849125392)(11.9355410946674,33.3464566929134,-20.196849125392) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(242) = edge271
Dim edge272 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 65 * 66 {(12.0142812521478,33.2677165354331,-20.1181089679116)(12.0142812521478,33.3070866141732,-20.1181089679116)(12.0142812521478,33.3464566929134,-20.1181089679116) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(243) = edge272
Dim edge273 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 65 * 87 {(12.0142812521478,33.3464566929134,-20.1181089679116)(12.0142812521478,33.3464566929134,-18.4251955820849)(12.0142812521478,33.3464566929134,-16.7322821962581) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(244) = edge273
Dim edge274 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 64 * 65 {(12.0142812521478,33.2677165354331,-16.7322821962581)(12.0142812521478,33.3070866141732,-16.7322821962581)(12.0142812521478,33.3464566929134,-16.7322821962581) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(245) = edge274
Dim edge275 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 63 * 64 {(11.9355410946674,33.2677165354331,-16.6535420387778)(11.9355410946674,33.3070866141732,-16.6535420387778)(11.9355410946674,33.3464566929134,-16.6535420387778) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(246) = edge275
Dim edge276 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 62 * 63 {(11.7984505434863,33.3464566929134,-16.6535420387778)(11.7984505434863,33.3070866141732,-16.6535420387778)(11.7984505434863,33.2677165354331,-16.6535420387778) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(247) = edge276
Dim edge277 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 63 * 87 {(11.9355410946674,33.3464566929134,-16.6535420387778)(11.8669958190769,33.3464566929134,-16.6535420387778)(11.7984505434863,33.3464566929134,-16.6535420387778) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(248) = edge277
Dim edge278 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 61 * 62 {(11.7984505434863,33.3464566929134,-16.0629908576754)(11.7984505434863,33.3070866141732,-16.0629908576754)(11.7984505434863,33.2677165354331,-16.0629908576754) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(249) = edge278
Dim edge279 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 61 * 84 {(11.9355410946674,33.2677165354331,-16.0629908576754)(11.8669958190769,33.2677165354331,-16.0629908576754)(11.7984505434863,33.2677165354331,-16.0629908576754) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(250) = edge279
Dim edge280 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 60 * 61 {(11.9355410946674,33.2677165354331,-16.0629908576754)(11.9355410946674,33.3070866141732,-16.0629908576754)(11.9355410946674,33.3464566929134,-16.0629908576754) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(251) = edge280
Dim edge281 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 59 * 60 {(12.0142812521478,33.2677165354331,-15.9842507001951)(12.0142812521478,33.3070866141732,-15.9842507001951)(12.0142812521478,33.3464566929134,-15.9842507001951) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(252) = edge281
Dim edge282 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 59 * 87 {(12.0142812521478,33.3464566929134,-15.9842507001951)(12.0142812521478,33.3464566929134,-14.2913373143683)(12.0142812521478,33.3464566929134,-12.5984239285416) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(253) = edge282
Dim edge283 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 58 * 59 {(12.0142812521478,33.2677165354331,-12.5984239285416)(12.0142812521478,33.3070866141732,-12.5984239285416)(12.0142812521478,33.3464566929134,-12.5984239285416) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(254) = edge283
Dim edge284 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 57 * 58 {(11.9355410946674,33.2677165354331,-12.5196837710612)(11.9355410946674,33.3070866141732,-12.5196837710612)(11.9355410946674,33.3464566929134,-12.5196837710612) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(255) = edge284
Dim edge285 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 56 * 57 {(11.7984505434863,33.3464566929134,-12.5196837710612)(11.7984505434863,33.3070866141732,-12.5196837710612)(11.7984505434863,33.2677165354331,-12.5196837710612) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(256) = edge285
Dim edge286 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 57 * 87 {(11.9355410946674,33.3464566929134,-12.5196837710612)(11.8669958190769,33.3464566929134,-12.5196837710613)(11.7984505434863,33.3464566929134,-12.5196837710613) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(257) = edge286
Dim edge287 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 55 * 56 {(11.7984505434863,33.3464566929134,-11.9291325899589)(11.7984505434863,33.3070866141732,-11.9291325899589)(11.7984505434863,33.2677165354331,-11.9291325899589) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(258) = edge287
Dim edge288 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 55 * 84 {(11.9355410946674,33.2677165354331,-11.9291325899589)(11.8669958190769,33.2677165354331,-11.9291325899589)(11.7984505434863,33.2677165354331,-11.9291325899589) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(259) = edge288
Dim edge289 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 54 * 55 {(11.9355410946674,33.2677165354331,-11.9291325899589)(11.9355410946674,33.3070866141732,-11.9291325899589)(11.9355410946674,33.3464566929134,-11.9291325899589) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(260) = edge289
Dim edge290 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 53 * 54 {(12.0142812521478,33.2677165354331,-11.8503924324786)(12.0142812521478,33.3070866141732,-11.8503924324786)(12.0142812521478,33.3464566929134,-11.8503924324786) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(261) = edge290
Dim edge291 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 53 * 87 {(12.0142812521478,33.3464566929134,-11.8503924324786)(12.0142812521478,33.3464566929134,-10.1574790466518)(12.0142812521478,33.3464566929134,-8.464565660825) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(262) = edge291
Dim edge292 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 52 * 53 {(12.0142812521478,33.2677165354331,-8.464565660825)(12.0142812521478,33.3070866141732,-8.464565660825)(12.0142812521478,33.3464566929134,-8.464565660825) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(263) = edge292
Dim edge293 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 51 * 52 {(11.9355410946674,33.2677165354331,-8.3858255033447)(11.9355410946674,33.3070866141732,-8.3858255033447)(11.9355410946674,33.3464566929134,-8.3858255033447) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(264) = edge293
Dim edge294 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 50 * 51 {(11.7984505434863,33.3464566929134,-8.3858255033447)(11.7984505434863,33.3070866141732,-8.3858255033447)(11.7984505434863,33.2677165354331,-8.3858255033447) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(265) = edge294
Dim edge295 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 51 * 87 {(11.9355410946674,33.3464566929134,-8.3858255033447)(11.8669958190769,33.3464566929134,-8.3858255033447)(11.7984505434863,33.3464566929134,-8.3858255033447) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(266) = edge295
Dim edge296 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 49 * 50 {(11.7984505434863,33.3464566929134,-7.7952743222424)(11.7984505434863,33.3070866141732,-7.7952743222424)(11.7984505434863,33.2677165354331,-7.7952743222424) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(267) = edge296
Dim edge297 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 49 * 84 {(11.9355410946674,33.2677165354331,-7.7952743222424)(11.8669958190769,33.2677165354331,-7.7952743222424)(11.7984505434863,33.2677165354331,-7.7952743222424) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(268) = edge297
Dim edge298 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 48 * 49 {(11.9355410946674,33.2677165354331,-7.7952743222424)(11.9355410946674,33.3070866141732,-7.7952743222424)(11.9355410946674,33.3464566929134,-7.7952743222424) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(269) = edge298
Dim edge299 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 47 * 48 {(12.0142812521478,33.2677165354331,-7.716534164762)(12.0142812521478,33.3070866141732,-7.716534164762)(12.0142812521478,33.3464566929134,-7.716534164762) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(270) = edge299
Dim edge300 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 47 * 87 {(12.0142812521478,33.3464566929134,-7.716534164762)(12.0142812521478,33.3464566929134,-6.0236207789353)(12.0142812521478,33.3464566929134,-4.3307073931085) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(271) = edge300
Dim edge301 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 46 * 47 {(12.0142812521478,33.2677165354331,-4.3307073931085)(12.0142812521478,33.3070866141732,-4.3307073931085)(12.0142812521478,33.3464566929134,-4.3307073931085) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(272) = edge301
Dim edge302 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 45 * 46 {(11.9355410946674,33.2677165354331,-4.2519672356282)(11.9355410946674,33.3070866141732,-4.2519672356282)(11.9355410946674,33.3464566929134,-4.2519672356282) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(273) = edge302
Dim edge303 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 44 * 45 {(11.7984505434863,33.3464566929134,-4.2519672356282)(11.7984505434863,33.3070866141732,-4.2519672356282)(11.7984505434863,33.2677165354331,-4.2519672356282) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(274) = edge303
Dim edge304 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 45 * 87 {(11.9355410946674,33.3464566929134,-4.2519672356282)(11.8669958190769,33.3464566929134,-4.2519672356282)(11.7984505434863,33.3464566929134,-4.2519672356282) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(275) = edge304
Dim edge305 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 44 * 87 {(11.7984505434863,33.3464566929134,-4.2519672356282)(11.5896591710887,33.3464566929134,-4.1654830174746)(11.5031749529352,33.3464566929134,-3.956691645077) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(276) = edge305
Dim edge306 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 43 * 44 {(11.5031749529352,33.3464566929134,-3.956691645077)(11.5031749529352,33.3070866141732,-3.956691645077)(11.5031749529352,33.2677165354331,-3.956691645077) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(277) = edge306
Dim edge307 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 43 * 84 {(11.5031749529352,33.2677165354331,-3.696038224579)(11.5031749529352,33.2677165354331,-3.826364934828)(11.5031749529352,33.2677165354331,-3.956691645077) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(278) = edge307
Dim edge308 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 42 * 43 {(11.5031749529352,33.2677165354331,-3.696038224579)(11.5031749529352,33.3070866141732,-3.696038224579)(11.5031749529352,33.3464566929134,-3.696038224579) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(279) = edge308
Dim edge309 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 41 * 42 {(11.4244347954548,33.2677165354331,-3.6172980670986)(11.4244347954548,33.3070866141732,-3.6172980670986)(11.4244347954548,33.3464566929134,-3.6172980670986) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(280) = edge309
Dim edge310 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 41 * 84 {(11.1481395198643,33.2677165354331,-3.6172980670986)(11.2862871576596,33.2677165354331,-3.6172980670986)(11.4244347954548,33.2677165354331,-3.6172980670986) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(281) = edge310
Dim edge311 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 40 * 41 {(11.1481395198643,33.3464566929134,-3.6172980670986)(11.1481395198643,33.3070866141732,-3.6172980670986)(11.1481395198643,33.2677165354331,-3.6172980670986) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(282) = edge311
Dim edge312 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 76 * 77 {(11.9749111734076,33.2677165354331,-25.278715364262)(11.9749111734076,33.3070866141732,-25.278715364262)(11.9749111734076,33.3464566929134,-25.278715364262) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(283) = edge312
Dim edge313 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 78 * 87 {(12.0142812521478,33.3464566929134,-25.2393452855219)(12.0142812521478,33.3464566929134,-25.1196720086065)(12.0142812521478,33.3464566929134,-24.9999987316912) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(284) = edge313
Dim edge314 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 77 * 78 {(12.0142812521478,33.2677165354331,-25.2393452855219)(12.0142812521478,33.3070866141732,-25.2393452855219)(12.0142812521478,33.3464566929134,-25.2393452855219) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(285) = edge314
Dim edge315 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 78 * 79 {(12.0142812521478,33.2677165354331,-24.9999987316912)(12.0142812521478,33.3070866141732,-24.9999987316912)(12.0142812521478,33.3464566929134,-24.9999987316912) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(286) = edge315
Dim edge316 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 101 * 112 {(11.3212474996999,33.2677165354327,-1.5492494822526)(11.3212474996999,33.2677165354327,-1.5571807206139)(11.3212474996999,33.2677165354327,-1.5651119589752) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(287) = edge316
Dim edge317 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 96 * 97 {(10.3239820552393,33.2677165354323,-0.7024621697856)(10.3239820552393,33.3070866141726,-0.7024621697856)(10.3239820552393,33.3464566929128,-0.7024621697856) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(288) = edge317
Dim edge318 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 97 * 98 {(10.3013866449676,33.2677165354323,-0.7576688701132)(10.3013866449676,33.3070866141726,-0.7576688701132)(10.3013866449676,33.3464566929128,-0.7576688701132) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(289) = edge318
Dim edge319 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 101 * 98 {(10.3013866449676,33.2677165354336,-1.4357744347208)(10.3013866449676,33.2677165354336,-1.096721652417)(10.3013866449676,33.2677165354336,-0.7576688701132) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(290) = edge319
Dim edge320 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 98 * 99 {(10.3013866449676,33.2677165354336,-1.4357744347208)(10.3013866449676,33.3070866141738,-1.4357744347208)(10.3013866449676,33.3464566929141,-1.4357744347208) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(291) = edge320
Dim edge321 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 112 * 113 {(11.3212474996999,33.2677165354327,-1.5492494822526)(11.3212474996999,33.3070866141729,-1.5492494822526)(11.3212474996999,33.3464566929132,-1.5492494822526) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(292) = edge321
Dim edge322 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 113 * 114 {(11.2994004803062,33.2677165354313,-1.4591168217959)(11.2994004803062,33.3070866141715,-1.4591168217959)(11.2994004803062,33.3464566929118,-1.4591168217959) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(293) = edge322
Dim edge323 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 103 * 120 {(10.3368197599241,33.2677165354331,-25.3180854430022)(10.3368197599241,33.2677165354331,-13.451651522625)(10.3368197599241,33.2677165354331,-1.5852176022479) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(294) = edge323
Dim edge324 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 119 * 120 {(10.3367323361059,33.2677165354331,-1.5852175958626)(10.3366903092379,33.2677165354331,-1.577636223564)(10.336649391343,33.2677165354332,-1.5700548478658) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(295) = edge324
Dim edge325 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 120 * 124 {(10.2352904542071,33.2677165354331,-25.3180863176102)(10.2860551070656,33.2677165354331,-25.3180863176102)(10.3368197599241,33.2677165354331,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(296) = edge325
Dim edge326 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 120 * 121 {(10.3144390873484,33.2677165354331,-1.5700548472185)(10.274300252336,33.2677165354331,-1.5700548472185)(10.2341614173236,33.2677165354331,-1.5700548472185) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(297) = edge326
Dim edge327 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 121 * 123 {(10.3149586722133,33.3464566929134,-1.5700548472185)(10.2745600447681,33.3464566929134,-1.5700548472185)(10.2341614173228,33.3464566929134,-1.5700548472185) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(298) = edge327
Dim edge328 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 122 * 123 {(10.3149586722133,33.3464566929134,-1.5700548472185)(10.3260633340287,33.3464566929134,-1.5700548472185)(10.3371679958441,33.3464566929134,-1.5700548472185) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(299) = edge328
Dim edge329 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 119 * 123 {(10.3369938778832,33.3464566929134,-1.5852176152226)(10.3370826316641,33.3464566929134,-1.5776362275702)(10.3371725154941,33.3464566929134,-1.5700548478921) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(300) = edge329
Dim edge330 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 119 * 122 {(10.3371679958441,33.3457763994084,-1.5700548472185)(10.3369086935953,33.3067464674208,-1.5700548472185)(10.3366493913465,33.2677165354331,-1.5700548472185) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(301) = edge330
Dim edge331 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 121 * 122 {(10.3149586722133,33.345923950974,-1.5700548472185)(10.3146988797808,33.3068202373444,-1.5700548472185)(10.3144390873484,33.2677165237147,-1.5700548472185) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(302) = edge331
Dim edge332 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 120 * 122 {(10.3144390873484,33.2677165354331,-1.5700548472185)(10.3255442393465,33.2677165354331,-1.5700548472185)(10.3366493913447,33.2677165354331,-1.5700548472185) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(303) = edge332
Dim edge333 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 123 * 124 {(10.2351168782281,33.3464566929134,-25.3180863176102)(10.2859671930559,33.3464566929134,-25.3180863176102)(10.3368175078838,33.3464566929134,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(304) = edge333
Dim edge334 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 26 * 36 {(10.1886788141706,33.2677165354331,-0.7351194155272)(10.1853627274027,33.2677165354331,-0.7094548298732)(10.1820466406339,33.2677165354331,-0.6837902442191) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(305) = edge334
Dim edge335 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 26 * 34 {(-10.1900685827087,33.2677165354331,-0.7351194155272)(-10.1867524959409,33.2677165354331,-0.7094548298731)(-10.1834364091732,33.2677165354331,-0.6837902442191) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(306) = edge335
Dim edge336 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 35 * 36 {(10.1886788141706,33.3464566929134,-0.7351194155272)(10.1853627274027,33.3464566929134,-0.7094548298732)(10.1820466406339,33.3464566929134,-0.6837902442191) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(307) = edge336
Dim edge337 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 34 * 35 {(-10.1900685827087,33.3464566929134,-0.7351194155272)(-10.1867524959409,33.3464566929134,-0.7094548298731)(-10.1834364091732,33.3464566929134,-0.6837902442191) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(308) = edge337
Dim edge338 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 26 * 28 {(-10.1834364091732,33.2677165354331,-0.683790244219)(-0.0006948842697,33.2677165354331,-0.683790244219)(10.1820466406339,33.2677165354331,-0.683790244219) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(309) = edge338
Dim edge339 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 33 * 34 {(-10.1834364091732,33.3464566929143,-0.6837902442196)(-10.1834364091732,33.3070866141737,-0.6837902442196)(-10.1834364091732,33.2677165354331,-0.6837902442195) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(310) = edge339
Dim edge340 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 31 * 35 {(-10.1834364091732,33.3464566929143,-0.6837902442196)(-0.0006948842697,33.3464566929143,-0.6837902442196)(10.1820466406339,33.3464566929143,-0.6837902442196) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(311) = edge340
Dim edge341 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 30 * 36 {(10.1820466406339,33.3464566929143,-0.6837902442196)(10.1820466406339,33.3070866141737,-0.6837902442196)(10.1820466406339,33.2677165354331,-0.6837902442195) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(312) = edge341
Dim edge342 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 10 * 9 {(-2.0930039370079,33.3464566929134,-7.7948818897638)(-2.0930039370079,33.3070866141732,-7.7948818897638)(-2.0930039370079,33.2677165354331,-7.7948818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(313) = edge342
Dim edge343 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 10 * 9 1 {(-1.8440039370079,33.3464566929134,-7.7948818897638)(-1.8440039370079,33.3070866141732,-7.7948818897638)(-1.8440039370079,33.2677165354331,-7.7948818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(314) = edge343
Dim edge344 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 11 * 12 {(-1.6008779527559,33.3464566929134,-5.590157480315)(-1.6008779527559,33.3070866141732,-5.590157480315)(-1.6008779527559,33.2677165354331,-5.590157480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(315) = edge344
Dim edge345 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 11 * 12 1 {(-1.3518779527559,33.3464566929134,-5.590157480315)(-1.3518779527559,33.3070866141732,-5.590157480315)(-1.3518779527559,33.2677165354331,-5.590157480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(316) = edge345
Dim edge346 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 13 * 14 {(1.8440039370079,33.3464566929134,-7.7948818897638)(1.8440039370079,33.3070866141732,-7.7948818897638)(1.8440039370079,33.2677165354331,-7.7948818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(317) = edge346
Dim edge347 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 13 * 14 1 {(2.0930039370079,33.3464566929134,-7.7948818897638)(2.0930039370079,33.3070866141732,-7.7948818897638)(2.0930039370079,33.2677165354331,-7.7948818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(318) = edge347
Dim edge348 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 15 * 16 {(1.3518779527559,33.3464566929134,-5.590157480315)(1.3518779527559,33.3070866141732,-5.590157480315)(1.3518779527559,33.2677165354331,-5.590157480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(319) = edge348
Dim edge349 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 15 * 16 1 {(1.6008779527559,33.3464566929134,-5.590157480315)(1.6008779527559,33.3070866141732,-5.590157480315)(1.6008779527559,33.2677165354331,-5.590157480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(320) = edge349
Dim edge350 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 17 * 18 {(-1,33.3464566929134,-4.8023382861142)(-1,33.3070866141732,-4.8023382861142)(-1,33.2677165354331,-4.8023382861142) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(321) = edge350
Dim edge351 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 17 * 18 1 {(1,33.3464566929134,-4.8023382861142)(1,33.3070866141732,-4.8023382861142)(1,33.2677165354331,-4.8023382861142) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(322) = edge351
Dim edge352 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 19 * 20 {(-8.2677165354331,33.3464566929134,-2.1062992125984)(-8.2677165354331,33.3070866141732,-2.1062992125984)(-8.2677165354331,33.2677165354331,-2.1062992125984) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(323) = edge352
Dim edge353 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 19 * 20 1 {(-8.2677165354331,33.3464566929134,-1.9488188976378)(-8.2677165354331,33.3070866141732,-1.9488188976378)(-8.2677165354331,33.2677165354331,-1.9488188976378) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(324) = edge353
Dim edge354 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 21 * 22 {(0,33.3464566929134,-2.1062992125984)(0,33.3070866141732,-2.1062992125984)(0,33.2677165354331,-2.1062992125984) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(325) = edge354
Dim edge355 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 21 * 22 1 {(0,33.3464566929134,-1.9488188976378)(0,33.3070866141732,-1.9488188976378)(0,33.2677165354331,-1.9488188976378) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(326) = edge355
Dim edge356 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 23 * 24 {(8.2677165354331,33.3464566929134,-2.1062992125984)(8.2677165354331,33.3070866141732,-2.1062992125984)(8.2677165354331,33.2677165354331,-2.1062992125984) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(327) = edge356
Dim edge357 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 23 * 24 1 {(8.2677165354331,33.3464566929134,-1.9488188976378)(8.2677165354331,33.3070866141732,-1.9488188976378)(8.2677165354331,33.2677165354331,-1.9488188976378) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(328) = edge357
Dim edge358 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 25 * 34 {(-10.1900685827087,33.3464566929134,-0.7351194155272)(-10.1900685827087,33.3070866141732,-0.7351194155272)(-10.1900685827087,33.2677165354331,-0.7351194155272) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(329) = edge358
Dim edge359 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 36 * 37 {(10.1886788141693,33.3464566929134,-0.7351194155272)(10.1886788141693,33.3070866141732,-0.7351194155272)(10.1886788141693,33.2677165354331,-0.7351194155272) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(330) = edge359
Dim edge360 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 37 * 38 {(10.2341614173228,33.3464566929134,-1.0821704875492)(10.2341614173228,33.3070866141732,-1.0821704875492)(10.2341614173228,33.2677165354331,-1.0821704875492) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(331) = edge360
Dim edge361 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 121 * 38 {(10.2341614173228,33.3464566929134,-1.5700548472185)(10.2341614173228,33.3070866141732,-1.5700548472185)(10.2341614173228,33.2677165354331,-1.5700548472185) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(332) = edge361
Dim edge362 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 124 * 125 {(10.2355511811024,33.3464547779385,-25.3180863176102)(10.2355511811024,33.3070835502736,-25.3180863176102)(10.2355511811024,33.2677123226086,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(333) = edge362
Dim edge363 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 126 * 181 {(-10.2355511811024,33.3464566929134,-25.3180863176102)(-10.2355511811024,33.3070866141732,-25.3180863176102)(-10.2355511811024,33.2677165354331,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(334) = edge363
Dim edge364 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 10 * 185 {(-2.0930039370079,33.3464566929134,-7.7948818897638)(-1.9685039370079,33.3464566929134,-7.6703818897638)(-1.8440039370079,33.3464566929134,-7.7948818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(335) = edge364
Dim edge365 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 185 * 9 {(-1.8440039370079,33.3464566929134,-7.7948818897638)(-1.9685039370079,33.3464566929134,-7.9193818897638)(-2.0930039370079,33.3464566929134,-7.7948818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(336) = edge365
Dim edge366 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 12 * 185 {(-1.6008779527559,33.3464566929134,-5.590157480315)(-1.4763779527559,33.3464566929134,-5.465657480315)(-1.3518779527559,33.3464566929134,-5.590157480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(337) = edge366
Dim edge367 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 11 * 185 {(-1.3518779527559,33.3464566929134,-5.590157480315)(-1.4763779527559,33.3464566929134,-5.714657480315)(-1.6008779527559,33.3464566929134,-5.590157480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(338) = edge367
Dim edge368 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 14 * 185 {(1.8440039370079,33.3464566929134,-7.7948818897638)(1.9685039370079,33.3464566929134,-7.6703818897638)(2.0930039370079,33.3464566929134,-7.7948818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(339) = edge368
Dim edge369 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 13 * 185 {(2.0930039370079,33.3464566929134,-7.7948818897638)(1.9685039370079,33.3464566929134,-7.9193818897638)(1.8440039370079,33.3464566929134,-7.7948818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(340) = edge369
Dim edge370 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 16 * 185 {(1.3518779527559,33.3464566929134,-5.590157480315)(1.4763779527559,33.3464566929134,-5.465657480315)(1.6008779527559,33.3464566929134,-5.590157480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(341) = edge370
Dim edge371 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 15 * 185 {(1.6008779527559,33.3464566929134,-5.590157480315)(1.4763779527559,33.3464566929134,-5.714657480315)(1.3518779527559,33.3464566929134,-5.590157480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(342) = edge371
Dim edge372 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 18 * 185 {(-1,33.3464566929134,-4.8023382861142)(-0,33.3464566929134,-3.8023382861142)(1,33.3464566929134,-4.8023382861142) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(343) = edge372
Dim edge373 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 17 * 185 {(1,33.3464566929134,-4.8023382861142)(0,33.3464566929134,-5.8023382861142)(-1,33.3464566929134,-4.8023382861142) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(344) = edge373
Dim edge374 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 185 * 20 {(-8.2677165354331,33.3464566929134,-2.1062992125984)(-8.3464566929134,33.3464566929134,-2.0275590551181)(-8.2677165354331,33.3464566929134,-1.9488188976378) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(345) = edge374
Dim edge375 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 185 * 19 {(-8.2677165354331,33.3464566929134,-1.9488188976378)(-8.1889763779528,33.3464566929134,-2.0275590551181)(-8.2677165354331,33.3464566929134,-2.1062992125984) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(346) = edge375
Dim edge376 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 185 * 22 {(0,33.3464566929134,-2.1062992125984)(-0.0787401574803,33.3464566929134,-2.0275590551181)(-0,33.3464566929134,-1.9488188976378) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(347) = edge376
Dim edge377 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 185 * 21 {(0,33.3464566929134,-1.9488188976378)(0.0787401574803,33.3464566929134,-2.0275590551181)(0,33.3464566929134,-2.1062992125984) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(348) = edge377
Dim edge378 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 185 * 24 {(8.2677165354331,33.3464566929134,-2.1062992125984)(8.1889763779528,33.3464566929134,-2.0275590551181)(8.2677165354331,33.3464566929134,-1.9488188976378) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(349) = edge378
Dim edge379 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 185 * 23 {(8.2677165354331,33.3464566929134,-1.9488188976378)(8.3464566929134,33.3464566929134,-2.0275590551181)(8.2677165354331,33.3464566929134,-2.1062992125984) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(350) = edge379
Dim edge380 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 126 * 185 {(-10.2355511811024,33.3464566929134,-25.3180863176102)(-9.9242079957495,33.3464566929134,-26.0697352582416)(-9.1725590551181,33.3464566929134,-26.3810784435945) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(351) = edge380
Dim edge381 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 125 * 185 {(9.1725590551181,33.3464566929134,-26.3810784435945)(9.9242079939961,33.3464566929134,-26.069735259995)(10.2355511811024,33.3464566929134,-25.3180863225696) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(352) = edge381
Dim edge382 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 123 * 185 {(10.2348002864902,33.3464566929134,-25.318086326412)(10.2346561026158,33.3464566929134,-13.4440705846874)(10.2345119187413,33.3464566929134,-1.5700548429628) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(353) = edge382
Dim edge383 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 185 * 38 {(10.2341614173228,33.3464566929134,-1.0821704875492)(10.2341614173228,33.3464566929134,-1.3261126673839)(10.2341614173228,33.3464566929134,-1.5700548472185) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(354) = edge383
Dim edge384 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 185 * 37 {(10.1886788141693,33.3464566929134,-0.7351194155272)(10.2114201157458,33.3464566929134,-0.9086449515382)(10.2341614173223,33.3464566929134,-1.0821704875493) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(355) = edge384
Dim edge385 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 185 * 35 {(-10.1900685827087,33.3464566929134,-0.7351194155272)(-0.0006948842697,33.3464566929134,-0.7351194155272)(10.1886788141693,33.3464566929134,-0.7351194155272) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(356) = edge385
Dim edge386 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 185 * 25 {(-10.1900685827087,33.3464566929134,-0.7351194155272)(-10.2128098819061,33.3464566929134,-0.908644933385)(-10.2355511811035,33.3464566929134,-1.0821704512428) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(357) = edge386
Dim edge387 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 184 * 185 {(-10.2355511811024,33.3464566929134,-1.5700548215461)(-10.2355511811024,33.3464566929134,-13.4440705695781)(-10.2355511811024,33.3464566929134,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(358) = edge387
Dim edge388 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 185 * 186 {(-10.2355511811024,33.3464566929134,-1.5700548215461)(-10.2355511811024,33.3464566929134,-1.3261126363945)(-10.2355511811024,33.3464566929134,-1.0821704512429) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(359) = edge388
Dim edge389 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 186 * 25 {(-10.2355511811024,33.3464566929134,-1.0821704512429)(-10.2355511811024,33.3070866141732,-1.0821704512429)(-10.2355511811024,33.2677165354331,-1.0821704512429) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(360) = edge389
Dim edge390 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 16 * 187 {(1.3518779527559,33.2677165354331,-5.590157480315)(1.4763779527559,33.2677165354331,-5.465657480315)(1.6008779527559,33.2677165354331,-5.590157480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(361) = edge390
Dim edge391 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 15 * 187 {(1.6008779527559,33.2677165354331,-5.590157480315)(1.4763779527559,33.2677165354331,-5.714657480315)(1.3518779527559,33.2677165354331,-5.590157480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(362) = edge391
Dim edge392 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 14 * 187 {(1.8440039370079,33.2677165354331,-7.7948818897638)(1.9685039370079,33.2677165354331,-7.6703818897638)(2.0930039370079,33.2677165354331,-7.7948818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(363) = edge392
Dim edge393 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 13 * 187 {(2.0930039370079,33.2677165354331,-7.7948818897638)(1.9685039370079,33.2677165354331,-7.9193818897638)(1.8440039370079,33.2677165354331,-7.7948818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(364) = edge393
Dim edge394 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 12 * 187 {(-1.6008779527559,33.2677165354331,-5.590157480315)(-1.4763779527559,33.2677165354331,-5.465657480315)(-1.3518779527559,33.2677165354331,-5.590157480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(365) = edge394
Dim edge395 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 11 * 187 {(-1.3518779527559,33.2677165354331,-5.590157480315)(-1.4763779527559,33.2677165354331,-5.714657480315)(-1.6008779527559,33.2677165354331,-5.590157480315) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(366) = edge395
Dim edge396 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 10 * 187 {(-2.0930039370079,33.2677165354331,-7.7948818897638)(-1.9685039370079,33.2677165354331,-7.6703818897638)(-1.8440039370079,33.2677165354331,-7.7948818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(367) = edge396
Dim edge397 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 187 * 9 {(-1.8440039370079,33.2677165354331,-7.7948818897638)(-1.9685039370079,33.2677165354331,-7.9193818897638)(-2.0930039370079,33.2677165354331,-7.7948818897638) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(368) = edge397
Dim edge398 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 18 * 187 {(-1,33.2677165354331,-4.8023382861142)(-0,33.2677165354331,-3.8023382861142)(1,33.2677165354331,-4.8023382861142) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(369) = edge398
Dim edge399 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 17 * 187 {(1,33.2677165354331,-4.8023382861142)(0,33.2677165354331,-5.8023382861142)(-1,33.2677165354331,-4.8023382861142) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(370) = edge399
Dim edge400 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 187 * 24 {(8.2677165354331,33.2677165354331,-2.1062992125984)(8.1889763779528,33.2677165354331,-2.0275590551181)(8.2677165354331,33.2677165354331,-1.9488188976378) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(371) = edge400
Dim edge401 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 187 * 23 {(8.2677165354331,33.2677165354331,-1.9488188976378)(8.3464566929134,33.2677165354331,-2.0275590551181)(8.2677165354331,33.2677165354331,-2.1062992125984) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(372) = edge401
Dim edge402 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 187 * 22 {(0,33.2677165354331,-2.1062992125984)(-0.0787401574803,33.2677165354331,-2.0275590551181)(-0,33.2677165354331,-1.9488188976378) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(373) = edge402
Dim edge403 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 187 * 21 {(0,33.2677165354331,-1.9488188976378)(0.0787401574803,33.2677165354331,-2.0275590551181)(0,33.2677165354331,-2.1062992125984) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(374) = edge403
Dim edge404 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 187 * 20 {(-8.2677165354331,33.2677165354331,-2.1062992125984)(-8.3464566929134,33.2677165354331,-2.0275590551181)(-8.2677165354331,33.2677165354331,-1.9488188976378) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(375) = edge404
Dim edge405 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 187 * 19 {(-8.2677165354331,33.2677165354331,-1.9488188976378)(-8.1889763779528,33.2677165354331,-2.0275590551181)(-8.2677165354331,33.2677165354331,-2.1062992125984) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(376) = edge405
Dim edge406 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 187 * 25 {(-10.1900685827087,33.2677165354331,-0.7351194155272)(-10.2128098819061,33.2677165354331,-0.908644933385)(-10.2355511811035,33.2677165354331,-1.0821704512428) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(377) = edge406
Dim edge407 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 187 * 26 {(-10.1900685827087,33.2677165354331,-0.7351194155272)(-0.0006948842697,33.2677165354331,-0.7351194155272)(10.1886788141693,33.2677165354331,-0.7351194155272) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(378) = edge407
Dim edge408 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 187 * 37 {(10.1886788141693,33.2677165354331,-0.7351194155272)(10.2114201157458,33.2677165354331,-0.9086449515382)(10.2341614173223,33.2677165354331,-1.0821704875493) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(379) = edge408
Dim edge409 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 187 * 38 {(10.2341614173228,33.2677165354331,-1.0821704875492)(10.2341614173228,33.2677165354331,-1.3261126673839)(10.2341614173228,33.2677165354331,-1.5700548472185) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(380) = edge409
Dim edge410 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 120 * 187 {(10.2350298034178,33.2677165354331,-25.3180863313123)(10.2345956103711,33.2677165354331,-13.4440705892654)(10.2341614173244,33.2677165354331,-1.5700548472185) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(381) = edge410
Dim edge411 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 125 * 187 {(9.1725578239181,33.2677165354331,-26.3810784435938)(9.9242075583182,33.2677165354331,-26.0697356956726)(10.2355511811024,33.2677165354331,-25.3180863236523) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(382) = edge411
Dim edge412 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 126 * 187 {(-10.2355511811024,33.2677165354331,-25.3180863176102)(-9.9242079957495,33.2677165354331,-26.0697352582416)(-9.1725590551181,33.2677165354331,-26.3810784435945) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(383) = edge412
Dim edge413 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 186 * 187 {(-10.2355511811024,33.2677165354331,-1.5700548215461)(-10.2355511811024,33.2677165354331,-1.3261126363945)(-10.2355511811024,33.2677165354331,-1.0821704512429) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(384) = edge413
Dim edge414 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 187 * 188 {(-9.1725590551181,33.2677165354331,-26.3810784435945)(-0.0000006156,33.2677165354331,-26.3810784435945)(9.1725578239181,33.2677165354331,-26.3810784435945) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(385) = edge414
Dim edge415 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 125 * 208 {(9.1725590551181,33.346456691513,-26.3810784435945)(9.1725584395319,33.3070866185202,-26.3810784435943)(9.1725578239464,33.2677165455274,-26.3810784435938) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(386) = edge415
Dim edge416 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 185 * 209 {(-9.1725590551181,33.3464566929134,-26.3810784435945)(0,33.3464566929134,-26.3810784435945)(9.1725590551181,33.3464566929134,-26.3810784435945) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(387) = edge416
Dim edge417 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 126 * 210 {(-9.1725590551181,33.3464566929134,-26.3810784435945)(-9.1725590551181,33.3070866141732,-26.3810784435945)(-9.1725590551181,33.2677165354331,-26.3810784435945) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(388) = edge417
Dim edge418 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 159 * 186 {(-10.2355511811024,33.2677165354331,-1.5700548215461)(-10.2355511811024,33.3070866141732,-1.5700548215461)(-10.2355511811024,33.3464566929134,-1.5700548215461) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(389) = edge418
Dim edge419 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 180 * 181 {(-10.3382095237197,33.3464566929134,-25.3180863176102)(-10.3382095237197,33.3070866141732,-25.3180863176102)(-10.3382095237197,33.2677165354331,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(390) = edge419
Dim edge420 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 159 * 160 {(-10.3382095237196,33.3464566929134,-1.5700548215461)(-10.3382095237196,33.3070866141732,-1.5700548215461)(-10.3382095237196,33.2677165354331,-1.5700548215461) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(391) = edge420
Dim edge421 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 160 * 182 {(-10.3382095237196,33.2677165354331,-1.5700548215461)(-10.3382095237196,33.2677165354331,-1.5776366363648)(-10.3382095237196,33.2677165354331,-1.5852184511835) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(392) = edge421
Dim edge422 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 181 * 182 {(-10.2355511811024,33.2677165354331,-25.3180863176102)(-10.286880352411,33.2677165354331,-25.3180863176102)(-10.3382095237197,33.2677165354331,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(393) = edge422
Dim edge423 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 182 * 187 {(-10.2355511811024,33.2677165354331,-1.5700548215461)(-10.2355511811024,33.2677165354331,-13.4440705695781)(-10.2355511811024,33.2677165354331,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(394) = edge423
Dim edge424 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 159 * 182 {(-10.2355511811024,33.2677165354331,-1.5700548215461)(-10.286880352411,33.2677165354331,-1.5700548215461)(-10.3382095237196,33.2677165354331,-1.5700548215461) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(395) = edge424
Dim edge425 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 159 * 184 {(-10.2355511811024,33.3464566929134,-1.5700548215461)(-10.286880352411,33.3464566929134,-1.5700548215461)(-10.3382095237196,33.3464566929134,-1.5700548215461) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(396) = edge425
Dim edge426 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 160 * 184 {(-10.3382095237196,33.3464566929134,-1.5700548215461)(-10.3382095237196,33.3464566929134,-1.5776366363648)(-10.3382095237196,33.3464566929134,-1.5852184511835) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(397) = edge426
Dim edge427 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 181 * 184 {(-10.2355511811024,33.3464566929134,-25.3180863176102)(-10.286880352411,33.3464566929134,-25.3180863176102)(-10.3382095237197,33.3464566929134,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(398) = edge427
Dim edge428 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 178 * 184 {(-10.3382095237197,33.3464566929134,-1.5852184511835)(-10.3382095237197,33.3464566929134,-13.4516523843968)(-10.3382095237197,33.3464566929134,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(399) = edge428
Dim edge429 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 142 * 178 {(-11.1256110985228,33.3464566929134,-3.5385587842264)(-11.1256110985228,33.3464566929134,-2.7462359495807)(-11.1256110985228,33.3464566929134,-1.953913114935) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(400) = edge429
Dim edge430 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 146 * 178 {(-11.0468709410425,33.3464566929134,-25.2787162388701)(-11.0468709410425,33.3464566929134,-14.4283226274045)(-11.0468709410425,33.3464566929134,-3.577929015939) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(401) = edge430
Dim edge431 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 148 * 178 {(-11.0468709410425,33.3464566929134,-25.3180863176102)(-11.0468709410425,33.3464566929134,-25.2984012782402)(-11.0468709410425,33.3464566929134,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(402) = edge431
Dim edge432 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 148 * 149 {(-11.0468709410425,33.3464566929134,-25.3180863176102)(-11.0468709410425,33.3070866141732,-25.3180863176102)(-11.0468709410425,33.2677165354331,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(403) = edge432
Dim edge433 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 147 * 148 {(-11.0468709410425,33.3464566929134,-25.2787162388701)(-11.0468709410425,33.3070866141732,-25.2787162388701)(-11.0468709410425,33.2677165354331,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(404) = edge433
Dim edge434 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 151 * 152 {(-11.0468709410425,33.2677165354331,-25.3180863176102)(-10.6925402323811,33.2677165354331,-25.3180863176102)(-10.3382095237197,33.2677165354331,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(405) = edge434
Dim edge435 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 148 * 152 {(-11.0468709410425,33.2677165354331,-25.3180863176102)(-11.0468709410425,33.2677165354331,-25.2984012782402)(-11.0468709410425,33.2677165354331,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(406) = edge435
Dim edge436 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 141 * 152 {(-11.0468709410425,33.2677165354331,-3.5779290159406)(-11.0468709410425,33.2677165354331,-14.4283226274053)(-11.0468709410425,33.2677165354331,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(407) = edge436
Dim edge437 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 144 * 152 {(-11.0862410197827,33.2677165354331,-3.5385587842264)(-11.0584021160452,33.2677165354331,-3.5500900673981)(-11.0468709410428,33.2677165354331,-3.5779290159406) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(408) = edge437
Dim edge438 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 143 * 152 {(-11.1256110985228,33.2677165354331,-3.5385587842264)(-11.1059260591527,33.2677165354331,-3.5385587842264)(-11.0862410197827,33.2677165354331,-3.5385587842264) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(409) = edge438
Dim edge439 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 152 * 153 {(-11.3026653465254,33.2677165354331,-1.5852030042686)(-11.1721687163185,33.2677165354331,-1.749404342236)(-11.1256110985228,33.2677165354331,-1.953913114935) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(410) = edge439
Dim edge440 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 152 * 158 {(-10.3382095237197,33.2677165354331,-1.5852184511835)(-10.8204442358306,33.2677165354331,-1.5852141488235)(-11.3026789479416,33.2677165354331,-1.5852098464635) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(411) = edge440
Dim edge441 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 144 * 145 {(-11.0468709410425,33.3464566929134,-3.577929015939)(-11.0468709410425,33.3070866141732,-3.5779290159392)(-11.0468709410425,33.2677165354331,-3.5779290159394) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(412) = edge441
Dim edge442 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 144 * 178 {(-11.0862410197827,33.3464566929134,-3.5385587842264)(-11.0584021160458,33.3464566929134,-3.5500900673975)(-11.0468709410428,33.3464566929134,-3.577929015939) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(413) = edge442
Dim edge443 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 143 * 144 {(-11.0862410197827,33.2677165354331,-3.5385587842264)(-11.0862410197827,33.3070866141732,-3.5385587842264)(-11.0862410197827,33.3464566929134,-3.5385587842264) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(414) = edge443
Dim edge444 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 143 * 178 {(-11.1256110985228,33.3464566929134,-3.5385587842264)(-11.1059260591527,33.3464566929134,-3.5385587842264)(-11.0862410197827,33.3464566929134,-3.5385587842264) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(415) = edge444
Dim edge445 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 142 * 143 {(-11.1256110985228,33.2677165354331,-3.5385587842264)(-11.1256110985228,33.3070866141732,-3.5385587842264)(-11.1256110985228,33.3464566929134,-3.5385587842264) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(416) = edge445
Dim edge446 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 142 * 152 {(-11.1256110985228,33.2677165354331,-3.5385587842264)(-11.1256110985228,33.2677165354331,-2.7462359495807)(-11.1256110985228,33.2677165354331,-1.953913114935) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(417) = edge446
Dim edge447 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 153 * 178 {(-11.3026741767271,33.3464566929134,-1.5851959302556)(-11.1721711652056,33.3464566929134,-1.7493992425809)(-11.1256110985228,33.3464566929134,-1.953913114935) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(418) = edge447
Dim edge448 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 142 * 153 {(-11.1256110985228,33.3464566929134,-1.953913114935)(-11.1256110985228,33.3070866141732,-1.953913114935)(-11.1256110985228,33.2677165354331,-1.953913114935) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(419) = edge448
Dim edge449 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 177 * 178 {(-10.3382095237197,33.3464566929134,-1.5852184511835)(-10.82044858025,33.3464566929134,-1.5852141488537)(-11.3026876367803,33.3464566929134,-1.585209846524) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(420) = edge449
Dim edge450 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 161 * 177 {(-10.3382095237197,33.3464566929134,-1.5699181907339)(-10.3382095237197,33.3464566929134,-1.5775683209587)(-10.3382095237197,33.3464566929134,-1.5852184511835) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(421) = edge450
Dim edge451 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 162 * 177 {(-10.3382095237197,33.3464566929134,-1.565112807911)(-10.3382095237197,33.3464566929134,-1.5675154993224)(-10.3382095237197,33.3464566929134,-1.5699181907339) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(422) = edge451
Dim edge452 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 158 * 161 {(-10.3382095237197,33.2677165354331,-1.5699214255406)(-10.3382095237197,33.2677165354331,-1.577569938362)(-10.3382095237197,33.2677165354331,-1.5852184511835) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(423) = edge452
Dim edge453 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 161 * 162 {(-10.3382095237197,33.3464560645663,-1.5699181907339)(-10.3382095237197,33.3070862999997,-1.5699198081308)(-10.3382095237197,33.2677165354331,-1.5699214255276) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(424) = edge453
Dim edge454 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 149 * 179 {(-11.0468709410425,33.3464566929134,-25.3180863176102)(-11.0468709410425,33.3464566929134,-26.1948842298605)(-11.0468709410425,33.3464566929134,-27.0716821421107) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(425) = edge454
Dim edge455 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 150 * 179 {(-11.0468709410425,33.3464566929134,-27.0716821421107)(-10.6925402323811,33.3464566929134,-27.0716821421107)(-10.3382095237197,33.3464566929134,-27.0716821421107) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(426) = edge455
Dim edge456 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 179 * 180 {(-10.3382095237197,33.3464566929134,-25.3180863176102)(-10.3382095237197,33.3464566929134,-26.1948842298605)(-10.3382095237197,33.3464566929134,-27.0716821421107) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(427) = edge456
Dim edge457 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 178 * 179 {(-11.0468709410425,33.3464566929134,-25.3180863176102)(-10.6925402323811,33.3464566929134,-25.3180863176102)(-10.3382095237197,33.3464566929134,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(428) = edge457
Dim edge458 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 150 * 180 {(-10.3382095237197,33.3464566929134,-27.0716821421107)(-10.3382095237197,33.3070866141732,-27.0716821421107)(-10.3382095237197,33.2677165354331,-27.0716821421107) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(429) = edge458
Dim edge459 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 151 * 180 {(-10.3382095237197,33.2677165354331,-25.3180863176102)(-10.3382095237197,33.2677165354331,-26.1948842298605)(-10.3382095237197,33.2677165354331,-27.0716821421107) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(430) = edge459
Dim edge460 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 149 * 150 {(-11.0468709410425,33.3464566929134,-27.0716821421107)(-11.0468709410425,33.3070866141732,-27.0716821421107)(-11.0468709410425,33.2677165354331,-27.0716821421107) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(431) = edge460
Dim edge461 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 150 * 151 {(-11.0468709410425,33.2677165354331,-27.0716821421107)(-10.6925402323811,33.2677165354331,-27.0716821421107)(-10.3382095237197,33.2677165354331,-27.0716821421107) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(432) = edge461
Dim edge462 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 157 * 158 {(-10.3382094796284,33.2677165354331,-1.5651128079108)(-10.8304233894513,33.2677165354331,-1.5651128079108)(-11.3226372992742,33.2677165354331,-1.5651128079108) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(433) = edge462
Dim edge463 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 154 * 158 {(-11.3226266588987,33.2677165354331,-1.5651022653894)(-11.3126565896754,33.2677165354331,-1.5751648751138)(-11.3026865204521,33.2677165354331,-1.5852274848382) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(434) = edge463
Dim edge464 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 140 * 141 {(-11.1495292836598,33.2677165354331,-3.6172989417067)(-11.1495292836598,33.2677165354331,-14.4480075902884)(-11.1495292836598,33.2677165354331,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(435) = edge464
Dim edge465 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 128 * 141 {(-11.0868034481602,33.2677165354331,-3.6172989417067)(-11.11816636591,33.2677165354331,-3.6172989417067)(-11.1495292836598,33.2677165354331,-3.6172989417067) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(436) = edge465
Dim edge466 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 141 * 145 {(-11.0468709410425,33.2677165354331,-3.577929015939)(-11.0586666925598,33.2677165354331,-3.6058655411794)(-11.0868034481602,33.2677165354331,-3.6172989417067) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(437) = edge466
Dim edge467 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 141 * 147 {(-11.1495292836598,33.2677165354331,-25.2787162388701)(-11.0982001123511,33.2677165354331,-25.2787162388701)(-11.0468709410425,33.2677165354331,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(438) = edge467
Dim edge468 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 158 * 162 {(-10.3382095237197,33.2677165354331,-1.5651128079109)(-10.3382095237197,33.2677165354331,-1.5675171167257)(-10.3382095237197,33.2677165354331,-1.5699214255406) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(439) = edge468
Dim edge469 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 162 * 163 {(-10.3382094796284,33.3464566929135,-1.565112807911)(-10.3382094796284,33.3070866141733,-1.565112807911)(-10.3382094796284,33.2677165354331,-1.565112807911) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(440) = edge469
Dim edge470 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 146 * 147 {(-11.1495292836598,33.3464566929134,-25.2787162388701)(-11.0982001123511,33.3464566929134,-25.2787162388701)(-11.0468709410425,33.3464566929134,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(441) = edge470
Dim edge471 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 149 * 151 {(-11.0468709410425,33.2677165354331,-25.3180863176102)(-11.0468709410425,33.2677165354331,-26.1948842298605)(-11.0468709410425,33.2677165354331,-27.0716821421107) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(442) = edge471
Dim edge472 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 132 * 138 {(-11.6219702285417,33.3464566929134,-25.2787162388701)(-11.6498090781947,33.3464566929134,-25.2671850097829)(-11.6613403072819,33.3464566929134,-25.2393461601299) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(443) = edge472
Dim edge473 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 127 * 138 {(-11.1495292836598,33.3464566929134,-25.2787162388701)(-11.3857497561008,33.3464566929134,-25.2787162388701)(-11.6219702285417,33.3464566929134,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(444) = edge473
Dim edge474 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 138 * 146 {(-11.1495292836598,33.3464566929134,-3.6172989417067)(-11.1495292836598,33.3464566929134,-14.4480075902884)(-11.1495292836598,33.3464566929134,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(445) = edge474
Dim edge475 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 130 * 138 {(-11.6613403072819,33.3464566929134,-3.8141493354075)(-11.6036841618461,33.3464566929134,-3.6749550871424)(-11.4644899135811,33.3464566929134,-3.6172989417067) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(446) = edge475
Dim edge476 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 128 * 145 {(-11.0868034481602,33.3464566929134,-3.6172989417067)(-11.0868034481602,33.3070866141732,-3.6172989417067)(-11.0868034481602,33.2677165354331,-3.6172989417067) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(447) = edge476
Dim edge477 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 128 * 129 {(-11.1495292836598,33.3464566929134,-3.6172989417067)(-11.1495292836598,33.3070866141732,-3.6172989417067)(-11.1495292836598,33.2677165354331,-3.6172989417067) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(448) = edge477
Dim edge478 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 128 * 146 {(-11.0868034481602,33.3464566929134,-3.6172989417067)(-11.11816636591,33.3464566929134,-3.6172989417067)(-11.1495292836598,33.3464566929134,-3.6172989417067) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(449) = edge478
Dim edge479 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 145 * 146 {(-11.0468709410425,33.3464566929134,-3.577929015939)(-11.0586666925598,33.3464566929134,-3.6058655411794)(-11.0868034481602,33.3464566929134,-3.6172989417067) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(450) = edge479
Dim edge480 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 154 * 177 {(-11.3226276400903,33.3464566929134,-1.5651032375575)(-11.3126615353454,33.3464566929134,-1.5751618460059)(-11.3026954306005,33.3464566929134,-1.5852204544543) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(451) = edge480
Dim edge481 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 153 * 154 {(-11.3027104704932,33.3464566894199,-1.5852052749638)(-11.3027057582571,33.3070866102431,-1.5852090497045)(-11.3027010460211,33.2677165310663,-1.5852128244453) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(452) = edge481
Dim edge482 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 175 * 176 {(-11.3007902798804,33.3464566929118,-1.4591176707317)(-11.2110307927356,33.3464566929117,-1.2848388571803)(-11.1212713055908,33.3464566929117,-1.110560043629) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(453) = edge482
Dim edge483 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 155 * 176 {(-11.3226372992741,33.3464566929131,-1.5492503311884)(-11.3170975961157,33.3464566929131,-1.5028790342003)(-11.3007902798811,33.3464566929131,-1.4591176707314) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(454) = edge483
Dim edge484 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 156 * 176 {(-11.3226372992741,33.3464566929135,-1.565112807911)(-11.3226372992741,33.3464566929135,-1.5571815695497)(-11.3226372992741,33.3464566929135,-1.5492503311884) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(455) = edge484
Dim edge485 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 176 * 177 {(-10.3382094796284,33.3464566929135,-1.565112807911)(-10.8304233894513,33.3464566929135,-1.565112807911)(-11.3226372992741,33.3464566929135,-1.565112807911) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(456) = edge485
Dim edge486 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 163 * 176 {(-10.3382094795969,33.3464566929114,-1.5015362801132)(-10.3382094796133,33.3464566929114,-1.5333245440121)(-10.3382094796297,33.3464566929114,-1.565112807911) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(457) = edge486
Dim edge487 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 164 * 176 {(-10.3027764087623,33.3464566929135,-1.4357752836566)(-10.3121983895977,33.3464566929137,-1.4731250198203)(-10.3382094795974,33.3464566929138,-1.5015362801124) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(458) = edge487
Dim edge488 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 165 * 176 {(-10.3027764087623,33.3464566929114,-0.7576697451571)(-10.3027764087623,33.3464566929114,-1.0967225144068)(-10.3027764087623,33.3464566929114,-1.4357752836566) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(459) = edge488
Dim edge489 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 166 * 176 {(-10.3253718190347,33.3464566929114,-0.7024630448302)(-10.3086438736998,33.3464566929114,-0.7278438657637)(-10.3027764087623,33.3464566929114,-0.7576697451571) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(460) = edge489
Dim edge490 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 171 * 176 {(-10.7764247566245,33.3464566929132,-0.5441805444622)(-10.7679405233548,33.3464566929132,-0.5144540640341)(-10.7718623244828,33.3464566929132,-0.4828054091652) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(461) = edge490
Dim edge491 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 172 * 176 {(-11.0277713209513,33.3464566929137,-1.0322000554239)(-10.902098038789,33.3464566929137,-0.7881902999425)(-10.7764247566267,33.3464566929137,-0.544180544461) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(462) = edge491
Dim edge492 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 173 * 176 {(-11.0750883532072,33.3464566929132,-1.071555124706)(-11.047045290633,33.3464566929132,-1.0563694564388)(-11.0277713209513,33.3464566929132,-1.0322000554239) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(463) = edge492
Dim edge493 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 174 * 176 {(-11.121271305593,33.3464566929132,-1.1105600436278)(-11.1021237414013,33.3464566929132,-1.0865249829591)(-11.0750883532072,33.3464566929132,-1.071555124706) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(464) = edge493
Dim edge494 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 157 * 174 {(-11.0750883532072,33.2677165354327,-1.0715551247058)(-11.1021237414013,33.2677165354327,-1.0865249829593)(-11.121271305593,33.2677165354327,-1.110560043628) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(465) = edge494
Dim edge495 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 157 * 173 {(-11.0277713209513,33.2677165354327,-1.0322000554238)(-11.047045290633,33.2677165354327,-1.0563694564387)(-11.0750883532072,33.2677165354327,-1.0715551247058) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(466) = edge495
Dim edge496 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 157 * 171 {(-10.7718623244828,33.2677165354327,-0.482805409165)(-10.7679405233548,33.2677165354327,-0.514454064034)(-10.7764247566245,33.2677165354327,-0.544180544462) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(467) = edge496
Dim edge497 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 157 * 166 {(-10.3027764087623,33.2677165354348,-0.7576697451577)(-10.3086438736998,33.2677165354348,-0.7278438657643)(-10.3253718190347,33.2677165354348,-0.7024630448308) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(468) = edge497
Dim edge498 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 157 * 164 {(-10.3382094795767,33.2677165354333,-1.501536280099)(-10.3121983895917,33.2677165354331,-1.4731250198094)(-10.3027764087623,33.267716535433,-1.4357752836564) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(469) = edge498
Dim edge499 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 155 * 157 {(-11.3007902798812,33.2677165354326,-1.4591176707315)(-11.3170975961157,33.2677165354326,-1.5028790342003)(-11.3226372992741,33.2677165354326,-1.5492503311882) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(470) = edge499
Dim edge500 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 132 * 140 {(-11.6613403072819,33.2677165354331,-25.2393461601299)(-11.6498090781947,33.2677165354331,-25.2671850097829)(-11.6219702285417,33.2677165354331,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(471) = edge500
Dim edge501 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 131 * 140 {(-11.6613403072819,33.2677165354331,-3.8141493354075)(-11.6613403072819,33.2677165354331,-14.5267477477687)(-11.6613403072819,33.2677165354331,-25.2393461601299) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(472) = edge501
Dim edge502 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 130 * 140 {(-11.4644899135811,33.2677165354331,-3.6172989417067)(-11.6036841618461,33.2677165354331,-3.6749550871424)(-11.6613403072819,33.2677165354331,-3.8141493354075) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(473) = edge502
Dim edge503 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 129 * 140 {(-11.1495292836598,33.2677165354331,-3.6172989417067)(-11.3070095986204,33.2677165354331,-3.6172989417067)(-11.4644899135811,33.2677165354331,-3.6172989417067) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(474) = edge503
Dim edge504 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 135 * 140 {(-11.2302379450771,33.2677165354331,-13.7177559055118)(-11.3713796773606,33.2677165354331,-13.8588976377953)(-11.5125214096441,33.2677165354331,-13.7177559055118) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(475) = edge504
Dim edge505 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 134 * 140 {(-11.5125214096441,33.2677165354331,-13.7177559055118)(-11.3713796773606,33.2677165354331,-13.5766141732283)(-11.2302379450771,33.2677165354331,-13.7177559055118) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(476) = edge505
Dim edge506 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 137 * 140 {(-11.2302379450771,33.2677165354331,-22.722874015748)(-11.3713796773606,33.2677165354331,-22.8640157480315)(-11.5125214096441,33.2677165354331,-22.722874015748) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(477) = edge506
Dim edge507 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 136 * 140 {(-11.5125214096441,33.2677165354331,-22.722874015748)(-11.3713796773606,33.2677165354331,-22.5817322834646)(-11.2302379450771,33.2677165354331,-22.722874015748) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(478) = edge507
Dim edge508 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 139 * 140 {(-11.2302379450771,33.2677165354331,-4.7126377952756)(-11.3713796773606,33.2677165354331,-4.8537795275591)(-11.5125214096441,33.2677165354331,-4.7126377952756) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(479) = edge508
Dim edge509 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 133 * 140 {(-11.5125214096441,33.2677165354331,-4.7126377952756)(-11.3713796773606,33.2677165354331,-4.5714960629921)(-11.2302379450771,33.2677165354331,-4.7126377952756) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(480) = edge509
Dim edge510 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 157 * 163 {(-10.3382094795969,33.2677165354348,-1.5015362800682)(-10.3382094796134,33.2677165354348,-1.5333245439895)(-10.3382094796299,33.2677165354348,-1.5651128079108) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(481) = edge510
Dim edge511 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 127 * 132 {(-11.6219702285417,33.2677165354331,-25.2787162388701)(-11.6219702285417,33.3070866141732,-25.2787162388701)(-11.6219702285417,33.3464566929134,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(482) = edge511
Dim edge512 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 127 * 140 {(-11.1495292836598,33.2677165354331,-25.2787162388701)(-11.3857497561008,33.2677165354331,-25.2787162388701)(-11.6219702285417,33.2677165354331,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(483) = edge512
Dim edge513 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 127 * 147 {(-11.1495292836598,33.3464566929134,-25.2787162388701)(-11.1495292836598,33.3070866141732,-25.2787162388701)(-11.1495292836598,33.2677165354331,-25.2787162388701) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(484) = edge513
Dim edge514 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 136 * 138 {(-11.5125214096441,33.3464566929134,-22.722874015748)(-11.3713796773606,33.3464566929134,-22.5817322834646)(-11.2302379450771,33.3464566929134,-22.722874015748) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(485) = edge514
Dim edge515 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 136 * 137 {(-11.2302379450771,33.3464566929134,-22.722874015748)(-11.2302379450771,33.3070866141732,-22.722874015748)(-11.2302379450771,33.2677165354331,-22.722874015748) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(486) = edge515
Dim edge516 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 137 * 138 {(-11.2302379450771,33.3464566929134,-22.722874015748)(-11.3713796773606,33.3464566929134,-22.8640157480315)(-11.5125214096441,33.3464566929134,-22.722874015748) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(487) = edge516
Dim edge517 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 136 * 137 1 {(-11.5125214096441,33.3464566929134,-22.722874015748)(-11.5125214096441,33.3070866141732,-22.722874015748)(-11.5125214096441,33.2677165354331,-22.722874015748) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(488) = edge517
Dim edge518 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 133 * 138 {(-11.5125214096441,33.3464566929134,-4.7126377952756)(-11.3713796773606,33.3464566929134,-4.5714960629921)(-11.2302379450771,33.3464566929134,-4.7126377952756) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(489) = edge518
Dim edge519 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 133 * 139 {(-11.2302379450771,33.3464566929134,-4.7126377952756)(-11.2302379450771,33.3070866141732,-4.7126377952756)(-11.2302379450771,33.2677165354331,-4.7126377952756) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(490) = edge519
Dim edge520 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 138 * 139 {(-11.2302379450771,33.3464566929134,-4.7126377952756)(-11.3713796773606,33.3464566929134,-4.8537795275591)(-11.5125214096441,33.3464566929134,-4.7126377952756) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(491) = edge520
Dim edge521 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 133 * 139 1 {(-11.5125214096441,33.3464566929134,-4.7126377952756)(-11.5125214096441,33.3070866141732,-4.7126377952756)(-11.5125214096441,33.2677165354331,-4.7126377952756) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(492) = edge521
Dim edge522 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 134 * 138 {(-11.5125214096441,33.3464566929134,-13.7177559055118)(-11.3713796773606,33.3464566929134,-13.5766141732283)(-11.2302379450771,33.3464566929134,-13.7177559055118) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(493) = edge522
Dim edge523 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 134 * 135 {(-11.2302379450771,33.3464566929134,-13.7177559055118)(-11.2302379450771,33.3070866141732,-13.7177559055118)(-11.2302379450771,33.2677165354331,-13.7177559055118) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(494) = edge523
Dim edge524 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 135 * 138 {(-11.2302379450771,33.3464566929134,-13.7177559055118)(-11.3713796773606,33.3464566929134,-13.8588976377953)(-11.5125214096441,33.3464566929134,-13.7177559055118) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(495) = edge524
Dim edge525 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 134 * 135 1 {(-11.5125214096441,33.3464566929134,-13.7177559055118)(-11.5125214096441,33.3070866141732,-13.7177559055118)(-11.5125214096441,33.2677165354331,-13.7177559055118) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(496) = edge525
Dim edge526 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 131 * 138 {(-11.6613403072819,33.3464566929134,-3.8141493354075)(-11.6613403072819,33.3464566929134,-14.5267477477687)(-11.6613403072819,33.3464566929134,-25.2393461601299) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(497) = edge526
Dim edge527 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 130 * 131 {(-11.6613403072819,33.2677165354331,-3.8141493354075)(-11.6613403072819,33.3070866141732,-3.8141493354075)(-11.6613403072819,33.3464566929134,-3.8141493354075) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(498) = edge527
Dim edge528 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 129 * 130 {(-11.4644899135811,33.2677165354331,-3.6172989417067)(-11.4644899135811,33.3070866141732,-3.6172989417067)(-11.4644899135811,33.3464566929134,-3.6172989417067) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(499) = edge528
Dim edge529 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 129 * 138 {(-11.1495292836598,33.3464566929134,-3.6172989417067)(-11.3070095986204,33.3464566929134,-3.6172989417067)(-11.4644899135811,33.3464566929134,-3.6172989417067) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(500) = edge529
Dim edge530 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 131 * 132 {(-11.6613403072819,33.2677165354331,-25.2393461601299)(-11.6613403072819,33.3070866141732,-25.2393461601299)(-11.6613403072819,33.3464566929134,-25.2393461601299) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(501) = edge530
Dim edge531 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 155 * 156 {(-11.3226372992741,33.2677165354326,-1.5492503311882)(-11.3226372992741,33.3070866141729,-1.5492503311882)(-11.3226372992741,33.3464566929131,-1.5492503311882) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(502) = edge531
Dim edge532 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 156 * 157 {(-11.3226372992741,33.2677165354331,-1.5651128079109)(-11.3226372992741,33.2677165354331,-1.5571815695496)(-11.3226372992741,33.2677165354331,-1.5492503311882) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(503) = edge532
Dim edge533 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 154 * 156 {(-11.3226372992741,33.346456693395,-1.5650934887188)(-11.3226372992741,33.3070866146792,-1.5650925074853)(-11.3226372992741,33.2677165359634,-1.5650915262519) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(504) = edge533
Dim edge534 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 173 * 174 {(-11.0750864240012,33.2677165354329,-1.0715612041344)(-11.0743783662477,33.3070866141731,-1.0713401792806)(-11.0750864240012,33.3464566929133,-1.0715612041344) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(505) = edge534
Dim edge535 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 172 * 173 {(-11.0277713209513,33.3464566929137,-1.0322000554239)(-11.0277713209513,33.3070866141735,-1.0322000554239)(-11.0277713209513,33.2677165354333,-1.0322000554239) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(506) = edge535
Dim edge536 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 157 * 172 {(-11.0277713209513,33.2677165354332,-1.0322000554238)(-10.902098038789,33.2677165354332,-0.7881902999423)(-10.7764247566267,33.2677165354332,-0.5441805444609) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(507) = edge536
Dim edge537 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 170 * 171 {(-10.7718680511013,33.2677165354314,-0.4828073539403)(-10.7716328330478,33.3070866141716,-0.4835108462887)(-10.7718680511013,33.3464566929119,-0.4828073539405) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(508) = edge537
Dim edge538 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 171 * 172 {(-10.7764247566245,33.3464566929142,-0.5441805444622)(-10.7764247566245,33.307086614174,-0.5441805444622)(-10.7764247566245,33.2677165354338,-0.5441805444622) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(509) = edge538
Dim edge539 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 166 * 167 {(-10.3253718190339,33.2677165354348,-0.7024630448301)(-10.3253718190339,33.3070866141731,-0.7024630448301)(-10.3253718190339,33.3464566929114,-0.7024630448301) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(510) = edge539
Dim edge540 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 165 * 166 {(-10.3027764087623,33.2677165354348,-0.7576697451577)(-10.3027764087623,33.3070866141731,-0.7576697451577)(-10.3027764087623,33.3464566929114,-0.7576697451577) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(511) = edge540
Dim edge541 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 164 * 165 {(-10.3027764087623,33.2677165354336,-1.4357752836564)(-10.3027764087623,33.3070866141738,-1.4357752836564)(-10.3027764087623,33.3464566929141,-1.4357752836564) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(512) = edge541
Dim edge542 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 157 * 165 {(-10.3027764087623,33.2677165354348,-0.7576697451577)(-10.3027764087623,33.2677165354348,-1.0967225144071)(-10.3027764087623,33.2677165354348,-1.4357752836564) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(513) = edge542
Dim edge543 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 163 * 164 {(-10.3382094795969,33.2677165354348,-1.5015362800682)(-10.338209479597,33.3070866141747,-1.5015362800682)(-10.3382094795971,33.3464566929146,-1.5015362800682) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(514) = edge543
Dim edge544 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 155 * 175 {(-11.3007902798804,33.2677165354312,-1.4591176707319)(-11.3007902798804,33.3070866141715,-1.4591176707319)(-11.3007902798804,33.3464566929118,-1.4591176707319) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(515) = edge544
Dim edge545 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 174 * 175 {(-11.121271305593,33.2677165354322,-1.110560043628)(-11.121271305593,33.3070866141725,-1.110560043628)(-11.121271305593,33.3464566929128,-1.110560043628) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(516) = edge545
Dim edge546 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 157 * 175 {(-11.3007902798804,33.2677165354312,-1.4591176707319)(-11.2110307927356,33.2677165354312,-1.2848388571806)(-11.1212713055908,33.2677165354312,-1.1105600436292) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(517) = edge546
Dim edge547 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 152 * 182 {(-10.3382095237197,33.2677165354331,-1.5852184511835)(-10.3382095237197,33.2677165354331,-13.4516523843968)(-10.3382095237197,33.2677165354331,-25.3180863176102) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(518) = edge547
Dim edge548 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 160 * 161 {(-10.3382095237197,33.3464566929134,-1.5852184511835)(-10.3382095237197,33.3070866141732,-1.5852184511835)(-10.3382095237197,33.2677165354331,-1.5852184511835) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges8(519) = edge548
Dim edgeDumbRule8 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule8 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges8, selectionIntentRuleOptions23)

selectionIntentRuleOptions23.Dispose()
Dim selectionIntentRuleOptions24 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions24 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions24.SetSelectedFromInactive(False)

Dim faces9(0) As NXOpen.Face
Dim brep9 As NXOpen.Features.Brep = CType(workPart.Features.FindObject("UNPARAMETERIZED_FEATURE(4)"), NXOpen.Features.Brep)

Dim face205 As NXOpen.Face = CType(brep9.FindObject("FACE 1 {(-10.0137007874016,32.4015748031496,-22.722874015748) UNPARAMETERIZED_FEATURE(4)}"), NXOpen.Face)

faces9(0) = face205
Dim faceDumbRule9 As NXOpen.FaceDumbRule = Nothing
faceDumbRule9 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces9, selectionIntentRuleOptions24)

selectionIntentRuleOptions24.Dispose()
Dim selectionIntentRuleOptions25 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions25 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions25.SetSelectedFromInactive(False)

Dim bodies8(0) As NXOpen.Body
Dim body9 As NXOpen.Body = CType(workPart.Bodies.FindObject("UNPARAMETERIZED_FEATURE(4)"), NXOpen.Body)

bodies8(0) = body9
Dim bodyDumbRule8 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule8 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies8, True, selectionIntentRuleOptions25)

selectionIntentRuleOptions25.Dispose()
Dim selectionIntentRuleOptions26 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions26 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions26.SetSelectedFromInactive(False)

Dim edges9(3) As NXOpen.Edge
Dim edge549 As NXOpen.Edge = CType(brep9.FindObject("EDGE * -4 * 1 {(-10.0137007874016,32.4015748031496,-22.5458418243077)(-9.8366685959613,32.4015748031496,-22.722874015748)(-10.0137007874016,32.4015748031496,-22.8999062071883) UNPARAMETERIZED_FEATURE(4)}"), NXOpen.Edge)

edges9(0) = edge549
Dim edge550 As NXOpen.Edge = CType(brep9.FindObject("EDGE * -3 * 1 {(-10.0137007874016,32.4015748031496,-22.8999062071883)(-10.1907329788419,32.4015748031496,-22.722874015748)(-10.0137007874016,32.4015748031496,-22.5458418243077) UNPARAMETERIZED_FEATURE(4)}"), NXOpen.Edge)

edges9(1) = edge550
Dim edge551 As NXOpen.Edge = CType(brep9.FindObject("EDGE * -1 * 1 {(-10.112125984252,32.4015748031496,-22.722874015748)(-10.0137007874016,32.4015748031496,-22.8212992125984)(-9.9152755905512,32.4015748031496,-22.722874015748) UNPARAMETERIZED_FEATURE(4)}"), NXOpen.Edge)

edges9(2) = edge551
Dim edge552 As NXOpen.Edge = CType(brep9.FindObject("EDGE * -2 * 1 {(-9.9152755905512,32.4015748031496,-22.722874015748)(-10.0137007874016,32.4015748031496,-22.6244488188976)(-10.112125984252,32.4015748031496,-22.722874015748) UNPARAMETERIZED_FEATURE(4)}"), NXOpen.Edge)

edges9(3) = edge552
Dim edgeDumbRule9 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule9 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges9, selectionIntentRuleOptions26)

selectionIntentRuleOptions26.Dispose()
Dim selectionIntentRuleOptions27 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions27 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions27.SetSelectedFromInactive(False)

Dim faces10(0) As NXOpen.Face
Dim brep10 As NXOpen.Features.Brep = CType(workPart.Features.FindObject("UNPARAMETERIZED_FEATURE(9)"), NXOpen.Features.Brep)

Dim face206 As NXOpen.Face = CType(brep10.FindObject("FACE 1 {(9.6932566993819,32.3228346456693,-13.7177559055118) UNPARAMETERIZED_FEATURE(9)}"), NXOpen.Face)

faces10(0) = face206
Dim faceDumbRule10 As NXOpen.FaceDumbRule = Nothing
faceDumbRule10 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces10, selectionIntentRuleOptions27)

selectionIntentRuleOptions27.Dispose()
Dim selectionIntentRuleOptions28 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions28 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions28.SetSelectedFromInactive(False)

Dim bodies9(0) As NXOpen.Body
Dim body10 As NXOpen.Body = CType(workPart.Bodies.FindObject("UNPARAMETERIZED_FEATURE(9)"), NXOpen.Body)

bodies9(0) = body10
Dim bodyDumbRule9 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule9 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies9, True, selectionIntentRuleOptions28)

selectionIntentRuleOptions28.Dispose()
Dim selectionIntentRuleOptions29 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions29 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions29.SetSelectedFromInactive(False)

Dim edges10(3) As NXOpen.Edge
Dim edge553 As NXOpen.Edge = CType(brep10.FindObject("EDGE * -3 * 1 {(9.6932566993819,32.3228346456693,-13.8934136823909)(9.5175989225028,32.3228346456693,-13.7177559055118)(9.6932566993819,32.3228346456693,-13.5420981286328) UNPARAMETERIZED_FEATURE(9)}"), NXOpen.Edge)

edges10(0) = edge553
Dim edge554 As NXOpen.Edge = CType(brep10.FindObject("EDGE * -4 * 1 {(9.6932566993819,32.3228346456693,-13.5420981286328)(9.8689144762609,32.3228346456693,-13.7177559055118)(9.6932566993819,32.3228346456693,-13.8934136823909) UNPARAMETERIZED_FEATURE(9)}"), NXOpen.Edge)

edges10(1) = edge554
Dim edge555 As NXOpen.Edge = CType(brep10.FindObject("EDGE * -1 * 1 {(9.5948315025315,32.3228346456693,-13.7177559055118)(9.6932566993819,32.3228346456693,-13.8161811023622)(9.7916818962323,32.3228346456693,-13.7177559055118) UNPARAMETERIZED_FEATURE(9)}"), NXOpen.Edge)

edges10(2) = edge555
Dim edge556 As NXOpen.Edge = CType(brep10.FindObject("EDGE * -2 * 1 {(9.7916818962323,32.3228346456693,-13.7177559055118)(9.6932566993819,32.3228346456693,-13.6193307086614)(9.5948315025315,32.3228346456693,-13.7177559055118) UNPARAMETERIZED_FEATURE(9)}"), NXOpen.Edge)

edges10(3) = edge556
Dim edgeDumbRule10 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule10 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges10, selectionIntentRuleOptions29)

selectionIntentRuleOptions29.Dispose()
Dim rules1(28) As NXOpen.SelectionIntentRule
rules1(0) = faceDumbRule1
rules1(1) = bodyDumbRule1
rules1(2) = edgeDumbRule1
rules1(3) = faceDumbRule2
rules1(4) = bodyDumbRule2
rules1(5) = edgeDumbRule2
rules1(6) = faceDumbRule3
rules1(7) = bodyDumbRule3
rules1(8) = edgeDumbRule3
rules1(9) = faceDumbRule4
rules1(10) = bodyDumbRule4
rules1(11) = edgeDumbRule4
rules1(12) = faceDumbRule5
rules1(13) = bodyDumbRule5
rules1(14) = edgeDumbRule5
rules1(15) = faceDumbRule6
rules1(16) = bodyDumbRule6
rules1(17) = edgeDumbRule6
rules1(18) = faceDumbRule7
rules1(19) = bodyDumbRule7
rules1(20) = edgeDumbRule7
rules1(21) = faceDumbRule8
rules1(22) = edgeDumbRule8
rules1(23) = faceDumbRule9
rules1(24) = bodyDumbRule8
rules1(25) = edgeDumbRule9
rules1(26) = faceDumbRule10
rules1(27) = bodyDumbRule9
rules1(28) = edgeDumbRule10
scCollector3.ReplaceRules(rules1, False)

workPart.MeasureManager.SetPartTransientModification()

Dim scCollector4 As NXOpen.ScCollector = Nothing
scCollector4 = workPart.ScCollectors.CreateCollector()

scCollector4.SetMultiComponent()

Dim selectionIntentRuleOptions30 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions30 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions30.SetSelectedFromInactive(False)

Dim faces11(0) As NXOpen.Face
faces11(0) = face3
Dim faceDumbRule11 As NXOpen.FaceDumbRule = Nothing
faceDumbRule11 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces11, selectionIntentRuleOptions30)

selectionIntentRuleOptions30.Dispose()
Dim selectionIntentRuleOptions31 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions31 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions31.SetSelectedFromInactive(False)

Dim bodies10(0) As NXOpen.Body
bodies10(0) = body2
Dim bodyDumbRule10 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule10 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies10, True, selectionIntentRuleOptions31)

selectionIntentRuleOptions31.Dispose()
Dim selectionIntentRuleOptions32 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions32 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions32.SetSelectedFromInactive(False)

Dim edges11(3) As NXOpen.Edge
edges11(0) = edge1
edges11(1) = edge2
edges11(2) = edge3
edges11(3) = edge4
Dim edgeDumbRule11 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule11 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges11, selectionIntentRuleOptions32)

selectionIntentRuleOptions32.Dispose()
Dim selectionIntentRuleOptions33 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions33 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions33.SetSelectedFromInactive(False)

Dim faces12(0) As NXOpen.Face
faces12(0) = face4
Dim faceDumbRule12 As NXOpen.FaceDumbRule = Nothing
faceDumbRule12 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces12, selectionIntentRuleOptions33)

selectionIntentRuleOptions33.Dispose()
Dim selectionIntentRuleOptions34 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions34 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions34.SetSelectedFromInactive(False)

Dim bodies11(0) As NXOpen.Body
bodies11(0) = body3
Dim bodyDumbRule11 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule11 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies11, True, selectionIntentRuleOptions34)

selectionIntentRuleOptions34.Dispose()
Dim selectionIntentRuleOptions35 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions35 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions35.SetSelectedFromInactive(False)

Dim edges12(3) As NXOpen.Edge
edges12(0) = edge5
edges12(1) = edge6
edges12(2) = edge7
edges12(3) = edge8
Dim edgeDumbRule12 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule12 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges12, selectionIntentRuleOptions35)

selectionIntentRuleOptions35.Dispose()
Dim selectionIntentRuleOptions36 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions36 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions36.SetSelectedFromInactive(False)

Dim faces13(0) As NXOpen.Face
faces13(0) = face5
Dim faceDumbRule13 As NXOpen.FaceDumbRule = Nothing
faceDumbRule13 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces13, selectionIntentRuleOptions36)

selectionIntentRuleOptions36.Dispose()
Dim selectionIntentRuleOptions37 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions37 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions37.SetSelectedFromInactive(False)

Dim bodies12(0) As NXOpen.Body
bodies12(0) = body4
Dim bodyDumbRule12 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule12 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies12, True, selectionIntentRuleOptions37)

selectionIntentRuleOptions37.Dispose()
Dim selectionIntentRuleOptions38 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions38 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions38.SetSelectedFromInactive(False)

Dim edges13(3) As NXOpen.Edge
edges13(0) = edge9
edges13(1) = edge10
edges13(2) = edge11
edges13(3) = edge12
Dim edgeDumbRule13 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule13 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges13, selectionIntentRuleOptions38)

selectionIntentRuleOptions38.Dispose()
Dim selectionIntentRuleOptions39 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions39 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions39.SetSelectedFromInactive(False)

Dim faces14(0) As NXOpen.Face
faces14(0) = face6
Dim faceDumbRule14 As NXOpen.FaceDumbRule = Nothing
faceDumbRule14 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces14, selectionIntentRuleOptions39)

selectionIntentRuleOptions39.Dispose()
Dim selectionIntentRuleOptions40 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions40 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions40.SetSelectedFromInactive(False)

Dim bodies13(0) As NXOpen.Body
bodies13(0) = body5
Dim bodyDumbRule13 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule13 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies13, True, selectionIntentRuleOptions40)

selectionIntentRuleOptions40.Dispose()
Dim selectionIntentRuleOptions41 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions41 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions41.SetSelectedFromInactive(False)

Dim edges14(3) As NXOpen.Edge
edges14(0) = edge13
edges14(1) = edge14
edges14(2) = edge15
edges14(3) = edge16
Dim edgeDumbRule14 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule14 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges14, selectionIntentRuleOptions41)

selectionIntentRuleOptions41.Dispose()
Dim selectionIntentRuleOptions42 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions42 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions42.SetSelectedFromInactive(False)

Dim faces15(0) As NXOpen.Face
faces15(0) = face7
Dim faceDumbRule15 As NXOpen.FaceDumbRule = Nothing
faceDumbRule15 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces15, selectionIntentRuleOptions42)

selectionIntentRuleOptions42.Dispose()
Dim selectionIntentRuleOptions43 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions43 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions43.SetSelectedFromInactive(False)

Dim bodies14(0) As NXOpen.Body
bodies14(0) = body6
Dim bodyDumbRule14 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule14 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies14, True, selectionIntentRuleOptions43)

selectionIntentRuleOptions43.Dispose()
Dim selectionIntentRuleOptions44 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions44 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions44.SetSelectedFromInactive(False)

Dim edges15(3) As NXOpen.Edge
edges15(0) = edge17
edges15(1) = edge18
edges15(2) = edge19
edges15(3) = edge20
Dim edgeDumbRule15 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule15 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges15, selectionIntentRuleOptions44)

selectionIntentRuleOptions44.Dispose()
Dim selectionIntentRuleOptions45 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions45 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions45.SetSelectedFromInactive(False)

Dim faces16(0) As NXOpen.Face
faces16(0) = face8
Dim faceDumbRule16 As NXOpen.FaceDumbRule = Nothing
faceDumbRule16 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces16, selectionIntentRuleOptions45)

selectionIntentRuleOptions45.Dispose()
Dim selectionIntentRuleOptions46 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions46 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions46.SetSelectedFromInactive(False)

Dim bodies15(0) As NXOpen.Body
bodies15(0) = body7
Dim bodyDumbRule15 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule15 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies15, True, selectionIntentRuleOptions46)

selectionIntentRuleOptions46.Dispose()
Dim selectionIntentRuleOptions47 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions47 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions47.SetSelectedFromInactive(False)

Dim edges16(3) As NXOpen.Edge
edges16(0) = edge21
edges16(1) = edge22
edges16(2) = edge23
edges16(3) = edge24
Dim edgeDumbRule16 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule16 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges16, selectionIntentRuleOptions47)

selectionIntentRuleOptions47.Dispose()
Dim selectionIntentRuleOptions48 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions48 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions48.SetSelectedFromInactive(False)

Dim faces17(0) As NXOpen.Face
faces17(0) = face9
Dim faceDumbRule17 As NXOpen.FaceDumbRule = Nothing
faceDumbRule17 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces17, selectionIntentRuleOptions48)

selectionIntentRuleOptions48.Dispose()
Dim selectionIntentRuleOptions49 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions49 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions49.SetSelectedFromInactive(False)

Dim bodies16(0) As NXOpen.Body
bodies16(0) = body8
Dim bodyDumbRule16 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule16 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies16, True, selectionIntentRuleOptions49)

selectionIntentRuleOptions49.Dispose()
Dim selectionIntentRuleOptions50 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions50 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions50.SetSelectedFromInactive(False)

Dim edges17(3) As NXOpen.Edge
edges17(0) = edge25
edges17(1) = edge26
edges17(2) = edge27
edges17(3) = edge28
Dim edgeDumbRule17 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule17 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges17, selectionIntentRuleOptions50)

selectionIntentRuleOptions50.Dispose()
Dim selectionIntentRuleOptions51 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions51 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions51.SetSelectedFromInactive(False)

Dim faces18(194) As NXOpen.Face
faces18(0) = face10
faces18(1) = face11
faces18(2) = face12
faces18(3) = face13
faces18(4) = face14
faces18(5) = face15
faces18(6) = face16
faces18(7) = face17
faces18(8) = face18
faces18(9) = face19
faces18(10) = face20
faces18(11) = face21
faces18(12) = face22
faces18(13) = face23
faces18(14) = face24
faces18(15) = face25
faces18(16) = face26
faces18(17) = face27
faces18(18) = face28
faces18(19) = face29
faces18(20) = face30
faces18(21) = face31
faces18(22) = face32
faces18(23) = face33
faces18(24) = face34
faces18(25) = face35
faces18(26) = face36
faces18(27) = face37
faces18(28) = face38
faces18(29) = face39
faces18(30) = face40
faces18(31) = face41
faces18(32) = face42
faces18(33) = face43
faces18(34) = face44
faces18(35) = face45
faces18(36) = face46
faces18(37) = face47
faces18(38) = face48
faces18(39) = face49
faces18(40) = face50
faces18(41) = face51
faces18(42) = face52
faces18(43) = face53
faces18(44) = face54
faces18(45) = face55
faces18(46) = face56
faces18(47) = face57
faces18(48) = face58
faces18(49) = face59
faces18(50) = face60
faces18(51) = face61
faces18(52) = face62
faces18(53) = face63
faces18(54) = face64
faces18(55) = face65
faces18(56) = face66
faces18(57) = face67
faces18(58) = face68
faces18(59) = face69
faces18(60) = face70
faces18(61) = face71
faces18(62) = face72
faces18(63) = face73
faces18(64) = face74
faces18(65) = face75
faces18(66) = face76
faces18(67) = face77
faces18(68) = face78
faces18(69) = face79
faces18(70) = face80
faces18(71) = face81
faces18(72) = face82
faces18(73) = face83
faces18(74) = face84
faces18(75) = face85
faces18(76) = face86
faces18(77) = face87
faces18(78) = face88
faces18(79) = face89
faces18(80) = face90
faces18(81) = face91
faces18(82) = face92
faces18(83) = face93
faces18(84) = face94
faces18(85) = face95
faces18(86) = face96
faces18(87) = face97
faces18(88) = face98
faces18(89) = face99
faces18(90) = face100
faces18(91) = face101
faces18(92) = face102
faces18(93) = face103
faces18(94) = face104
faces18(95) = face105
faces18(96) = face106
faces18(97) = face107
faces18(98) = face108
faces18(99) = face109
faces18(100) = face110
faces18(101) = face111
faces18(102) = face112
faces18(103) = face113
faces18(104) = face114
faces18(105) = face115
faces18(106) = face116
faces18(107) = face117
faces18(108) = face118
faces18(109) = face119
faces18(110) = face120
faces18(111) = face121
faces18(112) = face122
faces18(113) = face123
faces18(114) = face124
faces18(115) = face125
faces18(116) = face126
faces18(117) = face127
faces18(118) = face128
faces18(119) = face129
faces18(120) = face130
faces18(121) = face131
faces18(122) = face132
faces18(123) = face133
faces18(124) = face134
faces18(125) = face135
faces18(126) = face136
faces18(127) = face137
faces18(128) = face138
faces18(129) = face139
faces18(130) = face140
faces18(131) = face141
faces18(132) = face142
faces18(133) = face143
faces18(134) = face144
faces18(135) = face145
faces18(136) = face146
faces18(137) = face147
faces18(138) = face148
faces18(139) = face149
faces18(140) = face150
faces18(141) = face151
faces18(142) = face152
faces18(143) = face153
faces18(144) = face154
faces18(145) = face155
faces18(146) = face156
faces18(147) = face157
faces18(148) = face158
faces18(149) = face159
faces18(150) = face160
faces18(151) = face161
faces18(152) = face162
faces18(153) = face163
faces18(154) = face164
faces18(155) = face165
faces18(156) = face166
faces18(157) = face167
faces18(158) = face168
faces18(159) = face169
faces18(160) = face170
faces18(161) = face171
faces18(162) = face172
faces18(163) = face173
faces18(164) = face174
faces18(165) = face175
faces18(166) = face176
faces18(167) = face177
faces18(168) = face178
faces18(169) = face179
faces18(170) = face180
faces18(171) = face181
faces18(172) = face182
faces18(173) = face183
faces18(174) = face184
faces18(175) = face185
faces18(176) = face186
faces18(177) = face187
faces18(178) = face188
faces18(179) = face189
faces18(180) = face190
faces18(181) = face191
faces18(182) = face192
faces18(183) = face193
faces18(184) = face194
faces18(185) = face195
faces18(186) = face196
faces18(187) = face197
faces18(188) = face198
faces18(189) = face199
faces18(190) = face200
faces18(191) = face201
faces18(192) = face202
faces18(193) = face203
faces18(194) = face204
Dim faceDumbRule18 As NXOpen.FaceDumbRule = Nothing
faceDumbRule18 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces18, selectionIntentRuleOptions51)

selectionIntentRuleOptions51.Dispose()
Dim selectionIntentRuleOptions52 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions52 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions52.SetSelectedFromInactive(False)

Dim edges18(519) As NXOpen.Edge
edges18(0) = edge29
edges18(1) = edge30
edges18(2) = edge31
edges18(3) = edge32
edges18(4) = edge33
edges18(5) = edge34
edges18(6) = edge35
edges18(7) = edge36
edges18(8) = edge37
edges18(9) = edge38
edges18(10) = edge39
edges18(11) = edge40
edges18(12) = edge41
edges18(13) = edge42
edges18(14) = edge43
edges18(15) = edge44
edges18(16) = edge45
edges18(17) = edge46
edges18(18) = edge47
edges18(19) = edge48
edges18(20) = edge49
edges18(21) = edge50
edges18(22) = edge51
edges18(23) = edge52
edges18(24) = edge53
edges18(25) = edge54
edges18(26) = edge55
edges18(27) = edge56
edges18(28) = edge57
edges18(29) = edge58
edges18(30) = edge59
edges18(31) = edge60
edges18(32) = edge61
edges18(33) = edge62
edges18(34) = edge63
edges18(35) = edge64
edges18(36) = edge65
edges18(37) = edge66
edges18(38) = edge67
edges18(39) = edge68
edges18(40) = edge69
edges18(41) = edge70
edges18(42) = edge71
edges18(43) = edge72
edges18(44) = edge73
edges18(45) = edge74
edges18(46) = edge75
edges18(47) = edge76
edges18(48) = edge77
edges18(49) = edge78
edges18(50) = edge79
edges18(51) = edge80
edges18(52) = edge81
edges18(53) = edge82
edges18(54) = edge83
edges18(55) = edge84
edges18(56) = edge85
edges18(57) = edge86
edges18(58) = edge87
edges18(59) = edge88
edges18(60) = edge89
edges18(61) = edge90
edges18(62) = edge91
edges18(63) = edge92
edges18(64) = edge93
edges18(65) = edge94
edges18(66) = edge95
edges18(67) = edge96
edges18(68) = edge97
edges18(69) = edge98
edges18(70) = edge99
edges18(71) = edge100
edges18(72) = edge101
edges18(73) = edge102
edges18(74) = edge103
edges18(75) = edge104
edges18(76) = edge105
edges18(77) = edge106
edges18(78) = edge107
edges18(79) = edge108
edges18(80) = edge109
edges18(81) = edge110
edges18(82) = edge111
edges18(83) = edge112
edges18(84) = edge113
edges18(85) = edge114
edges18(86) = edge115
edges18(87) = edge116
edges18(88) = edge117
edges18(89) = edge118
edges18(90) = edge119
edges18(91) = edge120
edges18(92) = edge121
edges18(93) = edge122
edges18(94) = edge123
edges18(95) = edge124
edges18(96) = edge125
edges18(97) = edge126
edges18(98) = edge127
edges18(99) = edge128
edges18(100) = edge129
edges18(101) = edge130
edges18(102) = edge131
edges18(103) = edge132
edges18(104) = edge133
edges18(105) = edge134
edges18(106) = edge135
edges18(107) = edge136
edges18(108) = edge137
edges18(109) = edge138
edges18(110) = edge139
edges18(111) = edge140
edges18(112) = edge141
edges18(113) = edge142
edges18(114) = edge143
edges18(115) = edge144
edges18(116) = edge145
edges18(117) = edge146
edges18(118) = edge147
edges18(119) = edge148
edges18(120) = edge149
edges18(121) = edge150
edges18(122) = edge151
edges18(123) = edge152
edges18(124) = edge153
edges18(125) = edge154
edges18(126) = edge155
edges18(127) = edge156
edges18(128) = edge157
edges18(129) = edge158
edges18(130) = edge159
edges18(131) = edge160
edges18(132) = edge161
edges18(133) = edge162
edges18(134) = edge163
edges18(135) = edge164
edges18(136) = edge165
edges18(137) = edge166
edges18(138) = edge167
edges18(139) = edge168
edges18(140) = edge169
edges18(141) = edge170
edges18(142) = edge171
edges18(143) = edge172
edges18(144) = edge173
edges18(145) = edge174
edges18(146) = edge175
edges18(147) = edge176
edges18(148) = edge177
edges18(149) = edge178
edges18(150) = edge179
edges18(151) = edge180
edges18(152) = edge181
edges18(153) = edge182
edges18(154) = edge183
edges18(155) = edge184
edges18(156) = edge185
edges18(157) = edge186
edges18(158) = edge187
edges18(159) = edge188
edges18(160) = edge189
edges18(161) = edge190
edges18(162) = edge191
edges18(163) = edge192
edges18(164) = edge193
edges18(165) = edge194
edges18(166) = edge195
edges18(167) = edge196
edges18(168) = edge197
edges18(169) = edge198
edges18(170) = edge199
edges18(171) = edge200
edges18(172) = edge201
edges18(173) = edge202
edges18(174) = edge203
edges18(175) = edge204
edges18(176) = edge205
edges18(177) = edge206
edges18(178) = edge207
edges18(179) = edge208
edges18(180) = edge209
edges18(181) = edge210
edges18(182) = edge211
edges18(183) = edge212
edges18(184) = edge213
edges18(185) = edge214
edges18(186) = edge215
edges18(187) = edge216
edges18(188) = edge217
edges18(189) = edge218
edges18(190) = edge219
edges18(191) = edge220
edges18(192) = edge221
edges18(193) = edge222
edges18(194) = edge223
edges18(195) = edge224
edges18(196) = edge225
edges18(197) = edge226
edges18(198) = edge227
edges18(199) = edge228
edges18(200) = edge229
edges18(201) = edge230
edges18(202) = edge231
edges18(203) = edge232
edges18(204) = edge233
edges18(205) = edge234
edges18(206) = edge235
edges18(207) = edge236
edges18(208) = edge237
edges18(209) = edge238
edges18(210) = edge239
edges18(211) = edge240
edges18(212) = edge241
edges18(213) = edge242
edges18(214) = edge243
edges18(215) = edge244
edges18(216) = edge245
edges18(217) = edge246
edges18(218) = edge247
edges18(219) = edge248
edges18(220) = edge249
edges18(221) = edge250
edges18(222) = edge251
edges18(223) = edge252
edges18(224) = edge253
edges18(225) = edge254
edges18(226) = edge255
edges18(227) = edge256
edges18(228) = edge257
edges18(229) = edge258
edges18(230) = edge259
edges18(231) = edge260
edges18(232) = edge261
edges18(233) = edge262
edges18(234) = edge263
edges18(235) = edge264
edges18(236) = edge265
edges18(237) = edge266
edges18(238) = edge267
edges18(239) = edge268
edges18(240) = edge269
edges18(241) = edge270
edges18(242) = edge271
edges18(243) = edge272
edges18(244) = edge273
edges18(245) = edge274
edges18(246) = edge275
edges18(247) = edge276
edges18(248) = edge277
edges18(249) = edge278
edges18(250) = edge279
edges18(251) = edge280
edges18(252) = edge281
edges18(253) = edge282
edges18(254) = edge283
edges18(255) = edge284
edges18(256) = edge285
edges18(257) = edge286
edges18(258) = edge287
edges18(259) = edge288
edges18(260) = edge289
edges18(261) = edge290
edges18(262) = edge291
edges18(263) = edge292
edges18(264) = edge293
edges18(265) = edge294
edges18(266) = edge295
edges18(267) = edge296
edges18(268) = edge297
edges18(269) = edge298
edges18(270) = edge299
edges18(271) = edge300
edges18(272) = edge301
edges18(273) = edge302
edges18(274) = edge303
edges18(275) = edge304
edges18(276) = edge305
edges18(277) = edge306
edges18(278) = edge307
edges18(279) = edge308
edges18(280) = edge309
edges18(281) = edge310
edges18(282) = edge311
edges18(283) = edge312
edges18(284) = edge313
edges18(285) = edge314
edges18(286) = edge315
edges18(287) = edge316
edges18(288) = edge317
edges18(289) = edge318
edges18(290) = edge319
edges18(291) = edge320
edges18(292) = edge321
edges18(293) = edge322
edges18(294) = edge323
edges18(295) = edge324
edges18(296) = edge325
edges18(297) = edge326
edges18(298) = edge327
edges18(299) = edge328
edges18(300) = edge329
edges18(301) = edge330
edges18(302) = edge331
edges18(303) = edge332
edges18(304) = edge333
edges18(305) = edge334
edges18(306) = edge335
edges18(307) = edge336
edges18(308) = edge337
edges18(309) = edge338
edges18(310) = edge339
edges18(311) = edge340
edges18(312) = edge341
edges18(313) = edge342
edges18(314) = edge343
edges18(315) = edge344
edges18(316) = edge345
edges18(317) = edge346
edges18(318) = edge347
edges18(319) = edge348
edges18(320) = edge349
edges18(321) = edge350
edges18(322) = edge351
edges18(323) = edge352
edges18(324) = edge353
edges18(325) = edge354
edges18(326) = edge355
edges18(327) = edge356
edges18(328) = edge357
edges18(329) = edge358
edges18(330) = edge359
edges18(331) = edge360
edges18(332) = edge361
edges18(333) = edge362
edges18(334) = edge363
edges18(335) = edge364
edges18(336) = edge365
edges18(337) = edge366
edges18(338) = edge367
edges18(339) = edge368
edges18(340) = edge369
edges18(341) = edge370
edges18(342) = edge371
edges18(343) = edge372
edges18(344) = edge373
edges18(345) = edge374
edges18(346) = edge375
edges18(347) = edge376
edges18(348) = edge377
edges18(349) = edge378
edges18(350) = edge379
edges18(351) = edge380
edges18(352) = edge381
edges18(353) = edge382
edges18(354) = edge383
edges18(355) = edge384
edges18(356) = edge385
edges18(357) = edge386
edges18(358) = edge387
edges18(359) = edge388
edges18(360) = edge389
edges18(361) = edge390
edges18(362) = edge391
edges18(363) = edge392
edges18(364) = edge393
edges18(365) = edge394
edges18(366) = edge395
edges18(367) = edge396
edges18(368) = edge397
edges18(369) = edge398
edges18(370) = edge399
edges18(371) = edge400
edges18(372) = edge401
edges18(373) = edge402
edges18(374) = edge403
edges18(375) = edge404
edges18(376) = edge405
edges18(377) = edge406
edges18(378) = edge407
edges18(379) = edge408
edges18(380) = edge409
edges18(381) = edge410
edges18(382) = edge411
edges18(383) = edge412
edges18(384) = edge413
edges18(385) = edge414
edges18(386) = edge415
edges18(387) = edge416
edges18(388) = edge417
edges18(389) = edge418
edges18(390) = edge419
edges18(391) = edge420
edges18(392) = edge421
edges18(393) = edge422
edges18(394) = edge423
edges18(395) = edge424
edges18(396) = edge425
edges18(397) = edge426
edges18(398) = edge427
edges18(399) = edge428
edges18(400) = edge429
edges18(401) = edge430
edges18(402) = edge431
edges18(403) = edge432
edges18(404) = edge433
edges18(405) = edge434
edges18(406) = edge435
edges18(407) = edge436
edges18(408) = edge437
edges18(409) = edge438
edges18(410) = edge439
edges18(411) = edge440
edges18(412) = edge441
edges18(413) = edge442
edges18(414) = edge443
edges18(415) = edge444
edges18(416) = edge445
edges18(417) = edge446
edges18(418) = edge447
edges18(419) = edge448
edges18(420) = edge449
edges18(421) = edge450
edges18(422) = edge451
edges18(423) = edge452
edges18(424) = edge453
edges18(425) = edge454
edges18(426) = edge455
edges18(427) = edge456
edges18(428) = edge457
edges18(429) = edge458
edges18(430) = edge459
edges18(431) = edge460
edges18(432) = edge461
edges18(433) = edge462
edges18(434) = edge463
edges18(435) = edge464
edges18(436) = edge465
edges18(437) = edge466
edges18(438) = edge467
edges18(439) = edge468
edges18(440) = edge469
edges18(441) = edge470
edges18(442) = edge471
edges18(443) = edge472
edges18(444) = edge473
edges18(445) = edge474
edges18(446) = edge475
edges18(447) = edge476
edges18(448) = edge477
edges18(449) = edge478
edges18(450) = edge479
edges18(451) = edge480
edges18(452) = edge481
edges18(453) = edge482
edges18(454) = edge483
edges18(455) = edge484
edges18(456) = edge485
edges18(457) = edge486
edges18(458) = edge487
edges18(459) = edge488
edges18(460) = edge489
edges18(461) = edge490
edges18(462) = edge491
edges18(463) = edge492
edges18(464) = edge493
edges18(465) = edge494
edges18(466) = edge495
edges18(467) = edge496
edges18(468) = edge497
edges18(469) = edge498
edges18(470) = edge499
edges18(471) = edge500
edges18(472) = edge501
edges18(473) = edge502
edges18(474) = edge503
edges18(475) = edge504
edges18(476) = edge505
edges18(477) = edge506
edges18(478) = edge507
edges18(479) = edge508
edges18(480) = edge509
edges18(481) = edge510
edges18(482) = edge511
edges18(483) = edge512
edges18(484) = edge513
edges18(485) = edge514
edges18(486) = edge515
edges18(487) = edge516
edges18(488) = edge517
edges18(489) = edge518
edges18(490) = edge519
edges18(491) = edge520
edges18(492) = edge521
edges18(493) = edge522
edges18(494) = edge523
edges18(495) = edge524
edges18(496) = edge525
edges18(497) = edge526
edges18(498) = edge527
edges18(499) = edge528
edges18(500) = edge529
edges18(501) = edge530
edges18(502) = edge531
edges18(503) = edge532
edges18(504) = edge533
edges18(505) = edge534
edges18(506) = edge535
edges18(507) = edge536
edges18(508) = edge537
edges18(509) = edge538
edges18(510) = edge539
edges18(511) = edge540
edges18(512) = edge541
edges18(513) = edge542
edges18(514) = edge543
edges18(515) = edge544
edges18(516) = edge545
edges18(517) = edge546
edges18(518) = edge547
edges18(519) = edge548
Dim edgeDumbRule18 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule18 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges18, selectionIntentRuleOptions52)

selectionIntentRuleOptions52.Dispose()
Dim selectionIntentRuleOptions53 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions53 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions53.SetSelectedFromInactive(False)

Dim faces19(0) As NXOpen.Face
faces19(0) = face205
Dim faceDumbRule19 As NXOpen.FaceDumbRule = Nothing
faceDumbRule19 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces19, selectionIntentRuleOptions53)

selectionIntentRuleOptions53.Dispose()
Dim selectionIntentRuleOptions54 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions54 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions54.SetSelectedFromInactive(False)

Dim bodies17(0) As NXOpen.Body
bodies17(0) = body9
Dim bodyDumbRule17 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule17 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies17, True, selectionIntentRuleOptions54)

selectionIntentRuleOptions54.Dispose()
Dim selectionIntentRuleOptions55 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions55 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions55.SetSelectedFromInactive(False)

Dim edges19(3) As NXOpen.Edge
edges19(0) = edge549
edges19(1) = edge550
edges19(2) = edge551
edges19(3) = edge552
Dim edgeDumbRule19 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule19 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges19, selectionIntentRuleOptions55)

selectionIntentRuleOptions55.Dispose()
Dim selectionIntentRuleOptions56 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions56 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions56.SetSelectedFromInactive(False)

Dim faces20(0) As NXOpen.Face
faces20(0) = face206
Dim faceDumbRule20 As NXOpen.FaceDumbRule = Nothing
faceDumbRule20 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces20, selectionIntentRuleOptions56)

selectionIntentRuleOptions56.Dispose()
Dim selectionIntentRuleOptions57 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions57 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions57.SetSelectedFromInactive(False)

Dim bodies18(0) As NXOpen.Body
bodies18(0) = body10
Dim bodyDumbRule18 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule18 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies18, True, selectionIntentRuleOptions57)

selectionIntentRuleOptions57.Dispose()
Dim selectionIntentRuleOptions58 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions58 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions58.SetSelectedFromInactive(False)

Dim edges20(3) As NXOpen.Edge
edges20(0) = edge553
edges20(1) = edge554
edges20(2) = edge555
edges20(3) = edge556
Dim edgeDumbRule20 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule20 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges20, selectionIntentRuleOptions58)

selectionIntentRuleOptions58.Dispose()
Dim selectionIntentRuleOptions59 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions59 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions59.SetSelectedFromInactive(False)

Dim faces21(17) As NXOpen.Face
Dim face207 As NXOpen.Face = CType(extractFace1.FindObject("FACE 28 {(-0.0006948842697,33.267716535432,-0.4073024024635) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(0) = face207
Dim face208 As NXOpen.Face = CType(extractFace1.FindObject("FACE 116 {(10.8113170723338,33.3464566929132,-0.9617689487254) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(1) = face208
Dim face209 As NXOpen.Face = CType(extractFace1.FindObject("FACE 157 {(-10.8127068540182,33.2677165354327,-0.9617697942678) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(2) = face209
Dim face210 As NXOpen.Face = CType(extractFace1.FindObject("FACE 176 {(-10.8127068540182,33.3464566929132,-0.9617697942679) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(3) = face210
Dim face211 As NXOpen.Face = CType(extractFace1.FindObject("FACE 30 {(10.1503008328221,33.3070866141737,-0.441556601691) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(4) = face211
Dim face212 As NXOpen.Face = CType(extractFace1.FindObject("FACE 31 {(-0.0006948842697,33.3464566929132,-0.4073024024631) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(5) = face212
Dim face213 As NXOpen.Face = CType(extractFace1.FindObject("FACE 27 {(-0.0006948842677,33.307086614174,-0.1308145607083) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(6) = face213
Dim face214 As NXOpen.Face = CType(extractFace1.FindObject("FACE 32 {(-10.0938066324072,33.3070866141733,-0.1503699958479) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(7) = face214
Dim face215 As NXOpen.Face = CType(extractFace1.FindObject("FACE 170 {(-10.7754465344736,33.3070866141715,-0.452745848577) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(8) = face215
Dim face216 As NXOpen.Face = CType(extractFace1.FindObject("FACE 115 {(10.7000182234906,33.3070866141721,-0.3665151300691) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(9) = face216
Dim face217 As NXOpen.Face = CType(extractFace1.FindObject("FACE 114 {(11.0287999336421,33.3070866141724,-0.9337133940422) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(10) = face217
Dim face218 As NXOpen.Face = CType(extractFace1.FindObject("FACE 167 {(-10.4794074525888,33.307086614172,-0.5458101085817) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(11) = face218
Dim face219 As NXOpen.Face = CType(extractFace1.FindObject("FACE 101 {(10.8113170723338,33.2677165354328,-0.9617689487256) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(12) = face219
Dim face220 As NXOpen.Face = CType(extractFace1.FindObject("FACE 33 {(-10.1516906013615,33.3070866141737,-0.4415566016908) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(13) = face220
Dim face221 As NXOpen.Face = CType(extractFace1.FindObject("FACE 29 {(10.0924168638719,33.3070866141733,-0.1503699958477) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(14) = face221
Dim face222 As NXOpen.Face = CType(extractFace1.FindObject("FACE 96 {(10.4780176726434,33.3070866141725,-0.5458092499657) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(15) = face222
Dim face223 As NXOpen.Face = CType(extractFace1.FindObject("FACE 169 {(-10.7632577873651,33.3070866141713,-0.4154338438585) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(16) = face223
Dim face224 As NXOpen.Face = CType(extractFace1.FindObject("FACE 168 {(-10.7014080195906,33.307086614172,-0.3665159722591) SB_FLAT_SOLID(13:1B)}"), NXOpen.Face)

faces21(17) = face224
Dim faceDumbRule21 As NXOpen.FaceDumbRule = Nothing
faceDumbRule21 = workPart.ScRuleFactory.CreateRuleFaceDumb(faces21, selectionIntentRuleOptions59)

selectionIntentRuleOptions59.Dispose()
Dim selectionIntentRuleOptions60 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions60 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions60.SetSelectedFromInactive(False)

Dim bodies19(0) As NXOpen.Body
Dim body11 As NXOpen.Body = CType(workPart.Bodies.FindObject("SB_FLAT_SOLID(13:1B)"), NXOpen.Body)

bodies19(0) = body11
Dim bodyDumbRule19 As NXOpen.BodyDumbRule = Nothing
bodyDumbRule19 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies19, True, selectionIntentRuleOptions60)

selectionIntentRuleOptions60.Dispose()
Dim selectionIntentRuleOptions61 As NXOpen.SelectionIntentRuleOptions = Nothing
selectionIntentRuleOptions61 = workPart.ScRuleFactory.CreateRuleOptions()

selectionIntentRuleOptions61.SetSelectedFromInactive(False)

Dim edges21(32) As NXOpen.Edge
Dim edge557 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 101 * 115 {(10.7581993869746,33.2677165354319,-0.4083099662903)(10.7000182234909,33.2677165354319,-0.3665151300684)(10.6320532900451,33.2677165354319,-0.3891563301434) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(0) = edge557
Dim edge558 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 115 * 116 {(10.6320532900449,33.3464566929124,-0.3891563301433)(10.7000182234908,33.3464566929124,-0.3665151300681)(10.7581993869746,33.3464566929124,-0.40830996629) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(1) = edge558
Dim edge559 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 116 * 96 {(10.3239820552393,33.3464566929128,-0.7024621697854)(10.478017672642,33.3464566929128,-0.5458092499642)(10.6320532900446,33.3464566929128,-0.3891563301431) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(2) = edge559
Dim edge560 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 114 * 116 {(10.7581993869755,33.3464566929126,-0.4083099662896)(11.0287999336412,33.3464566929126,-0.9337133940427)(11.2994004803069,33.3464566929127,-1.4591168217958) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(3) = edge560
Dim edge561 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 115 * 96 {(10.6320532900464,33.2677165354319,-0.3891563301446)(10.6320532900464,33.3070866141721,-0.3891563301446)(10.6320532900464,33.3464566929124,-0.3891563301446) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(4) = edge561
Dim edge562 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 101 * 96 {(10.3239820552393,33.2677165354323,-0.7024621697856)(10.478017672642,33.2677165354323,-0.5458092499644)(10.6320532900448,33.2677165354322,-0.3891563301431) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(5) = edge562
Dim edge563 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 101 * 114 {(10.7581993869755,33.2677165354321,-0.4083099662898)(11.0287999336411,33.2677165354321,-0.9337133940428)(11.2994004803067,33.2677165354321,-1.4591168217957) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(6) = edge563
Dim edge564 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 114 * 115 {(10.7581993869755,33.2677165354321,-0.4083099662898)(10.7581993869755,33.3070866141723,-0.4083099662898)(10.7581993869755,33.3464566929126,-0.4083099662898) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(7) = edge564
Dim edge565 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 28 * 32 {(-10.0418722407047,33.2677165354342,-0.1308145607087)(-10.093806632407,33.2677165354342,-0.1503699958483)(-10.1199447935466,33.2677165354342,-0.1993229591624) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(8) = edge565
Dim edge566 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 27 * 28 {(10.0404824721693,33.2677165354334,-0.1308145607079)(-0.0006948842677,33.2677165354334,-0.1308145607079)(-10.0418722407047,33.2677165354334,-0.1308145607079) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(9) = edge566
Dim edge567 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 28 * 29 {(10.1185550250112,33.2677165354342,-0.1993229591624)(10.0924168638716,33.2677165354342,-0.1503699958483)(10.0404824721693,33.2677165354342,-0.1308145607087) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(10) = edge567
Dim edge568 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 28 * 30 {(10.1820466406339,33.2677165354331,-0.683790244219)(10.1503008328217,33.2677165354331,-0.4415566016908)(10.1185550250095,33.2677165354331,-0.1993229591626) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(11) = edge568
Dim edge569 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 32 * 33 {(-10.1199447935472,33.2677165354318,-0.1993229591623)(-10.1199447935472,33.3070866141723,-0.1993229591623)(-10.1199447935472,33.3464566929129,-0.1993229591623) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(12) = edge569
Dim edge570 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 28 * 33 {(-10.1834364091732,33.2677165354331,-0.683790244219)(-10.151690601361,33.2677165354331,-0.4415566016905)(-10.1199447935488,33.2677165354331,-0.1993229591621) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(13) = edge570
Dim edge571 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 31 * 32 {(-10.1199447935469,33.3464566929124,-0.1993229591631)(-10.093806632408,33.3464566929125,-0.1503699958472)(-10.0418722407047,33.3464566929125,-0.1308145607066) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(14) = edge571
Dim edge572 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 31 * 33 {(-10.1834364091732,33.3464566929143,-0.6837902442196)(-10.151690601361,33.3464566929144,-0.4415566016912)(-10.1199447935489,33.3464566929144,-0.1993229591628) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(15) = edge572
Dim edge573 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 29 * 31 {(10.0404824721693,33.3464566929125,-0.1308145607066)(10.0924168638726,33.3464566929124,-0.1503699958472)(10.1185550250115,33.3464566929124,-0.1993229591631) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(16) = edge573
Dim edge574 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 30 * 31 {(10.1820466406339,33.3464566929143,-0.6837902442196)(10.1503008328217,33.3464566929143,-0.4415566016914)(10.1185550250096,33.3464566929143,-0.1993229591633) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(17) = edge574
Dim edge575 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 29 * 30 {(10.1185550250118,33.2677165354318,-0.1993229591623)(10.1185550250118,33.3070866141723,-0.1993229591623)(10.1185550250118,33.3464566929129,-0.1993229591623) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(18) = edge575
Dim edge576 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 27 * 31 {(10.0404824721693,33.3464566929145,-0.1308145607087)(-0.0006948842677,33.3464566929145,-0.1308145607087)(-10.0418722407047,33.3464566929145,-0.1308145607087) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(19) = edge576
Dim edge577 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 27 * 29 {(10.0404824721693,33.2677165354334,-0.1308145607079)(10.0404824721693,33.307086614174,-0.1308145607079)(10.0404824721693,33.3464566929145,-0.1308145607079) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(20) = edge577
Dim edge578 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 27 * 32 {(-10.0418722407047,33.2677165354334,-0.1308145607079)(-10.0418722407047,33.307086614174,-0.1308145607079)(-10.0418722407047,33.3464566929145,-0.1308145607079) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(21) = edge578
Dim edge579 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 167 * 176 {(-10.6334430861442,33.3464566929122,-0.389157172334)(-10.4794074525892,33.3464566929122,-0.5458101085819)(-10.3253718190342,33.3464566929122,-0.7024630448298) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(22) = edge579
Dim edge580 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 168 * 176 {(-10.7595891830762,33.3464566929122,-0.4083108084793)(-10.7014080195911,33.3464566929122,-0.3665159722575)(-10.6334430861449,33.3464566929122,-0.3891571723347) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(23) = edge580
Dim edge581 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 169 * 176 {(-10.7669263916521,33.3464566929116,-0.4225568792386)(-10.7632577873646,33.3464566929116,-0.4154338438588)(-10.7595891830771,33.3464566929116,-0.4083108084789) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(24) = edge581
Dim edge582 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 170 * 176 {(-10.7718623244828,33.3464566929132,-0.4828054091652)(-10.7753746604055,33.3464566929132,-0.4521024391568)(-10.7669263916521,33.3464566929132,-0.4225568792386) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(25) = edge582
Dim edge583 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 157 * 170 {(-10.7669263916521,33.2677165354327,-0.4225568792385)(-10.7753746604055,33.2677165354327,-0.4521024391569)(-10.7718623244828,33.2677165354327,-0.482805409165) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(26) = edge583
Dim edge584 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 157 * 168 {(-10.6334430861449,33.2677165354318,-0.3891571723345)(-10.7014080195913,33.2677165354318,-0.3665159722574)(-10.7595891830764,33.2677165354318,-0.4083108084795) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(27) = edge584
Dim edge585 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 169 * 170 {(-10.7669263916521,33.2677165354311,-0.4225568792385)(-10.7669263916521,33.3070866141713,-0.4225568792385)(-10.7669263916521,33.3464566929116,-0.4225568792385) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(28) = edge585
Dim edge586 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 168 * 169 {(-10.7595891830773,33.2677165354319,-0.408310808479)(-10.7595891830773,33.3070866141722,-0.408310808479)(-10.7595891830773,33.3464566929125,-0.408310808479) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(29) = edge586
Dim edge587 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 157 * 169 {(-10.7669263916521,33.2677165354311,-0.4225568792385)(-10.7632577873647,33.2677165354311,-0.4154338438588)(-10.7595891830773,33.2677165354311,-0.408310808479) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(30) = edge587
Dim edge588 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 167 * 168 {(-10.6334430861442,33.2677165354318,-0.3891571723338)(-10.6334430861442,33.307086614172,-0.3891571723338)(-10.6334430861442,33.3464566929122,-0.3891571723338) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(31) = edge588
Dim edge589 As NXOpen.Edge = CType(extractFace1.FindObject("EDGE * 157 * 167 {(-10.6334430861442,33.2677165354318,-0.3891571723338)(-10.479407452589,33.2677165354318,-0.5458101085819)(-10.3253718190338,33.2677165354318,-0.70246304483) SB_FLAT_SOLID(13:1B)}"), NXOpen.Edge)

edges21(32) = edge589
Dim edgeDumbRule21 As NXOpen.EdgeDumbRule = Nothing
edgeDumbRule21 = workPart.ScRuleFactory.CreateRuleEdgeDumb(edges21, selectionIntentRuleOptions61)

selectionIntentRuleOptions61.Dispose()
Dim rules2(31) As NXOpen.SelectionIntentRule
rules2(0) = faceDumbRule11
rules2(1) = bodyDumbRule10
rules2(2) = edgeDumbRule11
rules2(3) = faceDumbRule12
rules2(4) = bodyDumbRule11
rules2(5) = edgeDumbRule12
rules2(6) = faceDumbRule13
rules2(7) = bodyDumbRule12
rules2(8) = edgeDumbRule13
rules2(9) = faceDumbRule14
rules2(10) = bodyDumbRule13
rules2(11) = edgeDumbRule14
rules2(12) = faceDumbRule15
rules2(13) = bodyDumbRule14
rules2(14) = edgeDumbRule15
rules2(15) = faceDumbRule16
rules2(16) = bodyDumbRule15
rules2(17) = edgeDumbRule16
rules2(18) = faceDumbRule17
rules2(19) = bodyDumbRule16
rules2(20) = edgeDumbRule17
rules2(21) = faceDumbRule18
rules2(22) = edgeDumbRule18
rules2(23) = faceDumbRule19
rules2(24) = bodyDumbRule17
rules2(25) = edgeDumbRule19
rules2(26) = faceDumbRule20
rules2(27) = bodyDumbRule18
rules2(28) = edgeDumbRule20
rules2(29) = faceDumbRule21
rules2(30) = bodyDumbRule19
rules2(31) = edgeDumbRule21
scCollector3.ReplaceRules(rules2, False)

Dim markId10 As NXOpen.Session.UndoMarkId = Nothing
markId10 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Measure")

theSession.DeleteUndoMark(markId10, Nothing)

Dim markId11 As NXOpen.Session.UndoMarkId = Nothing
markId11 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Measure")

Dim markId12 As NXOpen.Session.UndoMarkId = Nothing
markId12 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Measurement Apply")

workPart.MeasureManager.ClearPartTransientModification()

Dim anchorPoint1 As NXOpen.Point3d = New NXOpen.Point3d(-10.480947808924565, 33.267716535431767, -0.54424357921943389)
Dim annotationText1(3) As String
annotationText1(0) = "Length: 23.6756 in"
annotationText1(1) = "Width: 1.0236 in"
annotationText1(2) = "Height: 28.2272 in"
annotationText1(3) = "Volume: 684.0839 in³"
Dim annotation1 As NXOpen.Annotations.Annotation = Nothing
annotation1 = workPart.MeasureManager.CreateNoteAnnotation(anchorPoint1, annotationText1)

workPart.MeasureManager.SetPartTransientModification()

Dim markId13 As NXOpen.Session.UndoMarkId = Nothing
markId13 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Measurement Update")

Dim nErrs1 As Integer = Nothing
nErrs1 = theSession.UpdateManager.DoUpdate(markId13)

theSession.DeleteUndoMark(markId13, "Measurement Update")

theSession.DeleteUndoMark(markId12, "Measurement Apply")

Dim datadeleted1 As Boolean = Nothing
datadeleted1 = theSession.DeleteTransientDynamicSectionCutData()

theSession.DeleteUndoMark(markId11, Nothing)

theSession.SetUndoMarkName(markId9, "Measure")

scCollector3.Destroy()

scCollector4.Destroy()

workPart.MeasureManager.ClearPartTransientModification()

theSession.CleanUpFacetedFacesAndEdges()

Dim markId14 As NXOpen.Session.UndoMarkId = Nothing
markId14 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Edit Object Origin")

Dim generalLabel1 As NXOpen.Annotations.GeneralLabel = CType(annotation1, NXOpen.Annotations.GeneralLabel)

generalLabel1.LeaderOrientation = NXOpen.Annotations.LeaderOrientation.FromLeft

Dim origin1 As NXOpen.Point3d = New NXOpen.Point3d(-14.098418122602126, 33.267716535431767, -8.0509603898480542)
generalLabel1.AnnotationOrigin = origin1

Dim nErrs2 As Integer = Nothing
nErrs2 = theSession.UpdateManager.DoUpdate(markId14)

' ----------------------------------------------
'   Menu: Tools->Journal->Stop Recording
' ----------------------------------------------

End Sub
End Module