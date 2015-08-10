Public Class AddReleasePointStep1

    Public Sub New(ByVal ds As EmissionsDataSet)
        InitializeComponent()
        Me.m_ds = ds
    End Sub

    Public Sub New(ByVal ds As EmissionsDataSet, ByVal emissionYear As Int16, ByVal plantID As Int32)
        InitializeComponent()
        Me.m_ds = ds
        Me.m_emissionYear = emissionYear
        Me.m_plantID = plantID
    End Sub

    Private m_ds As EmissionsDataSet
    Private m_emissionYear As Int16
    Private m_plantID As Int32
    Private m_releasePoint As EmissionsDataSet.ReleasePointRow


#Region "----- load -----"

    Private Sub AddReleasePointStep1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If (Me.m_ds.ReleasePoint.Rows.Count = 0) Then
            Me.m_releasePoint = Me.m_ds.ReleasePoint.NewReleasePointRow
            Call Me.SetDefaultValuesToRow()
            Call Me.CreateReleasePointYearRecord()
        Else
            Me.m_releasePoint = CType(Me.m_ds.ReleasePoint.Rows(0), EmissionsInventory.EmissionsDataSet.ReleasePointRow)
            Call Me.LoadControls()
        End If

    End Sub

    Private Sub CreateReleasePointYearRecord()

        Dim rpYear As EmissionsDataSet.ReleasePointYearRow = Me.m_ds.ReleasePointYear.NewReleasePointYearRow
        With rpYear
            .ReleasePointID = Me.m_releasePoint.ReleasePointID
            .EmissionYear = Me.m_emissionYear
            .OperatingStatusTypeEISID = GlobalVariables.OperatingStatus.Operating
        End With
        Me.m_ds.ReleasePointYear.Rows.Add(rpYear)

    End Sub

    Private Sub SetDefaultValuesToRow()

        With Me.m_releasePoint
            .PlantID = Me.m_plantID
            .ReleasePointEISID = EmissionsInventory.GlobalMethods.GenerateTempEISID
            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
            .ReleasePointTypeID = -1
            .ReleaseTypeSubTypeID = -1
        End With

    End Sub

    Private Sub LoadControls()
        With Me.m_releasePoint
            Me.ReleasePointAPCDIDTextBox.Text = .ReleasePointAPCDID
            Me.ReleasePointDescriptionTextBox.Text = .ReleasePointDescription
            Me.CompanyCommentTextBox.Text = .CompanyComment
            Me.APCDCommentTextBox.Text = .APCDComment
            Me.XCoordinateTextBox.Text = CStr(.XCoordinate)
            Me.YCoordinateTextBox.Text = CStr(.YCoordinate)
        End With
    End Sub


#End Region '----- load -----

#Region "----- buttons -----"

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        If (Me.IsValidForm) Then
            Call Me.AssignValuesToRow()
            Try
                Me.m_ds.ReleasePoint.Rows.Add(Me.m_releasePoint)
            Catch ex As ArgumentException
                'This row already belongs to this table.
            End Try
            ''Call Me.AddReleasePoint_Step2()
            GlobalVariables.AddReleasePointStep = GlobalVariables.WizardStep._Next
            Me.Close()
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#End Region '----- buttons -----

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        Dim blnIsValidForm As Boolean

        If (Not Me.IsValidAPCDID) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidYCoordinate) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidXCoordinate) Then
            blnIsValidForm = False
        Else
            blnIsValidForm = True
        End If

        Return blnIsValidForm

    End Function

    Private Function IsValidXCoordinate() As Boolean
        'min -85.4135
        'max -85.9586

        Dim dataIsValid As Boolean

        If (Me.XCoordinateTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, "Value must be >= -85.9586 and <= -85.4135")
            Me.ErrorProvider1.SetIconAlignment(Me.XCoordinateTextBox, ErrorIconAlignment.MiddleLeft)

        ElseIf (Not IsNumeric(Me.XCoordinateTextBox.Text.Trim.Length)) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, "Value must be >= -85.9586 and <= -85.4135")
            Me.ErrorProvider1.SetIconAlignment(Me.XCoordinateTextBox, ErrorIconAlignment.MiddleLeft)

        Else
            Try
                Dim decValue = CDec(Me.XCoordinateTextBox.Text.Trim)
                If (decValue < -85.9586) OrElse (decValue > -85.4135) Then
                    dataIsValid = False
                    Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, "Value must be >= -85.9586 and <= -85.4135")
                    Me.ErrorProvider1.SetIconAlignment(Me.XCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
                Else
                    dataIsValid = True
                    Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, String.Empty)
                End If
            Catch ex As Exception
                dataIsValid = False
                Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, "Value must be >= -85.9586 and <= -85.4135")
                Me.ErrorProvider1.SetIconAlignment(Me.XCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
            End Try

        End If

        Return dataIsValid

    End Function

    'done
    Private Function IsValidYCoordinate() As Boolean
        'min 37.9963
        'max 38.3837
        Dim dataIsValid As Boolean

        If (Me.YCoordinateTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, "Value must be >= 37.9963 and <= 38.3837")
            Me.ErrorProvider1.SetIconAlignment(Me.YCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
        ElseIf (Not IsNumeric(Me.YCoordinateTextBox.Text.Trim.Length)) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, "Value must be >= 37.9963 and <= 38.3837")
            Me.ErrorProvider1.SetIconAlignment(Me.YCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            Try
                Dim decValue = CDec(Me.YCoordinateTextBox.Text.Trim)
                If (decValue < 37.9963) OrElse (decValue > 38.3837) Then
                    dataIsValid = False
                    Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, "Value must be >= 37.9963 and <= 38.3837")
                    Me.ErrorProvider1.SetIconAlignment(Me.YCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
                Else
                    dataIsValid = True
                    Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, String.Empty)
                End If
            Catch ex As Exception
                dataIsValid = False
                Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, "Value must be >= 37.9963 and <= 38.3837")
                Me.ErrorProvider1.SetIconAlignment(Me.YCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
            End Try

        End If

        Return dataIsValid

    End Function

    Private Function IsValidAPCDID() As Boolean

        Dim dataIsValid As Boolean

        If (ReleasePointAPCDIDTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(ReleasePointAPCDIDTextBox, "Please enter the APCD ID.")
            Me.ErrorProvider1.SetIconAlignment(ReleasePointAPCDIDTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(ReleasePointAPCDIDTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

#End Region '----- Validation -----

    Private Sub AssignValuesToRow()

        With Me.m_releasePoint
            .ReleasePointAPCDID = Me.ReleasePointAPCDIDTextBox.Text

            If (Me.ReleasePointDescriptionTextBox.Text.Trim.Length = 0) Then
                .SetReleasePointDescriptionNull()
            Else
                .ReleasePointDescription = Me.ReleasePointDescriptionTextBox.Text.Trim
            End If

            .BeginDate = New Date(Date.Now.Year - 1, 1, 1)

            If (Me.CompanyCommentTextBox.Text.Trim.Length > 0) Then
                .CompanyComment = Me.CompanyCommentTextBox.Text
            Else
                .SetCompanyCommentNull()
            End If
            If (Me.APCDCommentTextBox.Text.Trim.Length > 0) Then
                .APCDComment = Me.APCDCommentTextBox.Text
            Else
                .SetAPCDCommentNull()
            End If
            .XCoordinate = CDec(Me.XCoordinateTextBox.Text)
            .YCoordinate = CDec(Me.YCoordinateTextBox.Text)
        End With

    End Sub

   
End Class