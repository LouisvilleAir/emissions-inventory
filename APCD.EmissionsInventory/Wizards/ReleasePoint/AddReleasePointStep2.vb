Public Class AddReleasePointStep2

    Public Sub New(ByVal ds As EmissionsDataSet)
        InitializeComponent()
        Me.m_ds = ds
    End Sub

    Private m_formIsLoaded As Boolean = False
    Private m_ds As EmissionsDataSet
    Private m_releasePoint As EmissionsDataSet.ReleasePointRow

    Private m_ButtonClicked As Boolean = False

#Region "----- load -----"

    Private Sub AddReleasePointStep2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.m_releasePoint = CType(Me.m_ds.ReleasePoint.Rows(0), EmissionsInventory.EmissionsDataSet.ReleasePointRow)

        Call Me.InitializeComboBoxes()

        Me.m_formIsLoaded = True

    End Sub

    Private Sub InitializeComboBoxes()

        Me.ReleasePointTypeTableAdapter.Fill(Me.EmissionsDataSet.ReleasePointType)

        If (Me.m_releasePoint.ReleasePointTypeID > 0) Then
            Me.ReleasePointTypeIDComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.ReleasePointTypeIDComboBox, Me.m_releasePoint.ReleasePointTypeID)
            Dim releaseTypeID As ReleasePointHelper.ReleaseType = CType(Me.GetTheReleaseTypeIDForTheSelectedPointType, ReleasePointHelper.ReleaseType)
            Me.ReleaseTypeSubTypeTableAdapter.FillByReleaseTypeID(Me.EmissionsDataSet.ReleaseTypeSubType, releaseTypeID)
            Me.ReleaseTypeSubTypeComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.ReleaseTypeSubTypeComboBox, Me.m_releasePoint.ReleaseTypeSubTypeID)
        Else
            Me.ReleasePointTypeIDComboBox.SelectedIndex = -1
            Me.ReleaseTypeSubTypeComboBox.SelectedIndex = -1
        End If

    End Sub

#End Region '----- load -----

#Region "----- buttons -----"

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Call Me.StepHandler(1)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Call Me.StepHandler(3)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.m_ButtonClicked = True

        Me.Close()

        Me.m_ButtonClicked = False

    End Sub

    Private Sub StepHandler(ByVal _step As Int32)

        Me.m_ButtonClicked = True

        Call Me.AssignValuesToRow()
        Select Case _step
            Case 1
                GlobalVariables.AddReleasePointStep = GlobalVariables.WizardStep._Back
            Case 3
                GlobalVariables.AddReleasePointStep = GlobalVariables.WizardStep._Next
        End Select

        Me.Close()

        Me.m_ButtonClicked = False

    End Sub

#End Region '----- buttons -----

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        Dim blnIsValidForm As Boolean

        If (Not Me.IsValidReleasePointType) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidReleaseTypeSubType) Then
            blnIsValidForm = False
        Else
            blnIsValidForm = True
        End If

        Return blnIsValidForm

    End Function

    Private Function IsValidReleaseTypeSubType() As Boolean

        Dim dataIsValid As Boolean

        If (Me.ReleaseTypeSubTypeComboBox.SelectedIndex < 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.ReleaseTypeSubTypeComboBox, "Please select a sub-type")
            Me.ErrorProvider1.SetIconAlignment(Me.ReleaseTypeSubTypeComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(Me.ReleaseTypeSubTypeComboBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    Private Function IsValidReleasePointType() As Boolean

        Dim dataIsValid As Boolean

        If (ReleasePointTypeIDComboBox.SelectedIndex < 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(ReleasePointTypeIDComboBox, "Please select an Release Point Type")
            Me.ErrorProvider1.SetIconAlignment(Me.ReleasePointTypeIDComboBox, ErrorIconAlignment.MiddleRight)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(ReleasePointTypeIDComboBox, String.Empty)
        End If

        Return dataIsValid

    End Function

#End Region '----- Validation -----

    Private Sub AssignValuesToRow()

        With Me.m_releasePoint
            .ReleasePointTypeID = CInt(Me.ReleasePointTypeIDComboBox.SelectedValue)
            .ReleaseTypeSubTypeID = CInt(Me.ReleaseTypeSubTypeComboBox.SelectedValue)
        End With

    End Sub

    Private Sub ReleasePointTypeIDComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleasePointTypeIDComboBox.SelectedIndexChanged

        If (Me.m_ButtonClicked = False) Then

            If (Me.m_formIsLoaded = True) Then
                Dim releaseTypeID1 As ReleasePointHelper.ReleaseType = CType(Me.GetTheReleaseTypeIDForTheSelectedPointType, ReleasePointHelper.ReleaseType)

                'first time this event is raised subType rows will be 0.
                If (Me.EmissionsDataSet.ReleaseTypeSubType.Rows.Count = 0) Then
                    Call Me.InitializeReleaseTypeSubTypeComboBox(releaseTypeID1)
                Else
                    Dim releaseTypeID2 As ReleasePointHelper.ReleaseType = CType(Me.GetTheReleaseTypeIDForTheSelectedSubType, ReleasePointHelper.ReleaseType)
                    If (releaseTypeID1 <> releaseTypeID2) Then
                        Call Me.InitializeReleaseTypeSubTypeComboBox(releaseTypeID1)
                    End If
                End If

            End If

        End If

    End Sub

    Private Sub InitializeReleaseTypeSubTypeComboBox(ByVal releaseTypeID1 As ReleasePointHelper.ReleaseType)

        Me.m_formIsLoaded = False

        Me.ReleaseTypeSubTypeTableAdapter.FillByReleaseTypeID(Me.EmissionsDataSet.ReleaseTypeSubType, releaseTypeID1)
        Select Case releaseTypeID1
            Case ReleasePointHelper.ReleaseType.Fugitive
                Me.ReleaseTypeSubTypeComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.ReleaseTypeSubTypeComboBox, ReleasePointHelper.ReleaseTypeSubType.Point)
            Case ReleasePointHelper.ReleaseType.Stack
                Me.ReleaseTypeSubTypeComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.ReleaseTypeSubTypeComboBox, ReleasePointHelper.ReleaseTypeSubType.Round)
        End Select

        If (Me.m_ds.ReleasePointDetail.Rows.Count > 0) Then
            Me.m_ds.ReleasePointDetail.Clear()
        End If

        Me.m_formIsLoaded = True

    End Sub
    Private Function GetTheReleaseTypeIDForTheSelectedPointType() As Int32

        If (Me.ReleasePointTypeIDComboBox.SelectedIndex = -1) Then
            Return Me.ReleasePointTypeIDComboBox.SelectedIndex
        Else
            Return CInt(Me.EmissionsDataSet.ReleasePointType.Rows(Me.ReleasePointTypeIDComboBox.SelectedIndex)(Me.EmissionsDataSet.ReleasePointType.ReleaseTypeIDColumn.ColumnName))
        End If

    End Function

    Private Function GetTheReleaseTypeIDForTheSelectedSubType() As Int32
        Return CInt(Me.EmissionsDataSet.ReleaseTypeSubType.Rows(Me.ReleaseTypeSubTypeComboBox.SelectedIndex)(Me.EmissionsDataSet.ReleaseTypeSubType.ReleaseTypeIDColumn.ColumnName))
    End Function

    Private Sub ReleaseTypeSubTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleaseTypeSubTypeComboBox.SelectedIndexChanged

        If (Me.m_ButtonClicked = False) Then

            If (Me.m_formIsLoaded = True) Then
                If (Me.m_ds.ReleasePointDetail.Rows.Count > 0) Then
                    Me.m_ds.ReleasePointDetail.Clear()
                End If
            End If

        End If

    End Sub

End Class