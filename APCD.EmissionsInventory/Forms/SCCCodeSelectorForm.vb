Imports APCD.Emissions

Public Class SCCCodeSelectorForm

    Sub New(ByVal list As ArrayList)
        InitializeComponent()
        Me.m_list = list
    End Sub

    Private m_list As ArrayList
    Private m_formIsLoaded As Boolean = False
    Private m_objProcessClass As Business.ProcessClass

    Private Sub SCCCodeSelectorForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ProcessClassLevel1TypeTableAdapter.Fill(Me.EmissionsDataSet.ProcessClassLevel1Type)
        Me.ProcessClassLevel1TypeComboBox.SelectedIndex = -1
        Me.Label2.Text = String.Empty
        Me.m_formIsLoaded = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.m_list.Clear()
        Me.Close()
    End Sub

    Private Sub btnLookupProcessClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookupProcessClass.Click

        Dim text As String = Me.ProcessClassIDTextBox.Text.Trim
        If (text.Length > 0) Then

            ' Look up the value.
            Try
                Me.m_objProcessClass = Utility.ProcessClassUtility.GetByPrimaryKey(text)
            Catch ex As Exception
                Me.m_objProcessClass = Nothing
            End Try

            If (Me.m_objProcessClass Is Nothing) Then
                Me.Label2.Text = String.Empty
                MessageBox.Show("An error occurred retrieving the SCC code. The code may not exist.", "SCC Lookup", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Call Me.DisplaySCC()
                Me.btnOK.Enabled = True
            End If

        Else
            MessageBox.Show("Please enter a valid SCC in the box.", "SCC Lookup", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub ProcessClassIDTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessClassIDTextBox.TextChanged
        If (Me.m_formIsLoaded) Then
            Me.btnOK.Enabled = False
            Dim text As String = Me.ProcessClassIDTextBox.Text.Trim
            If (text.Length > 0) Then
                Me.ProcessClassLevel1TypeComboBox.SelectedIndex = -1
                Me.ProcessClassLevel2TypeComboBox.DataSource = Nothing
                Me.ProcessClassLevel3TypeComboBox.DataSource = Nothing
                Me.ProcessClassLevel4TypeComboBox.DataSource = Nothing
            End If
        End If
    End Sub

    ''' <summary>
    ''' Populate the ProceesClassLevel2TypeComboBox based on the ProcessClassLevel1Type selection.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ProcessClassLevel1TypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessClassLevel1TypeComboBox.SelectedIndexChanged

        If (Me.m_formIsLoaded) Then
            If (Me.ProcessClassLevel1TypeComboBox.SelectedIndex > -1) Then
                Me.btnOK.Enabled = False
                Me.ProcessClassIDTextBox.Text = String.Empty
                Me.Label2.Text = String.Empty

                Me.ProcessClassLevel2TypeComboBox.DataSource = Nothing
                Me.ProcessClassLevel3TypeComboBox.DataSource = Nothing
                'Me.ProcessClassLevel4TypeComboBox.DataSource = Nothing
                Me.ProcessClassComboBox.DataSource = Nothing

                Dim dtbLevel2LookupTable As DataTable = Utility.ProcessClassLevel2TypeUtility.GetLookupTableByProcessClassLevel1TypeID(CInt(Me.ProcessClassLevel1TypeComboBox.SelectedValue))
                If (dtbLevel2LookupTable IsNot Nothing) Then
                    If (dtbLevel2LookupTable.Rows.Count > 0) Then
                        Me.m_formIsLoaded = False
                        Tools.WindowsForms.LoadComboBox(dtbLevel2LookupTable, Me.ProcessClassLevel2TypeComboBox, False)
                        Me.ProcessClassLevel2TypeComboBox.SelectedIndex = -1
                        Me.m_formIsLoaded = True
                    End If
                End If
            End If
        End If

    End Sub

    ''' <summary>
    ''' Populate the ProcessClassLevel3TypeComboBox based on the selections in 
    ''' ProcessClassLevel1TypeComboBox and ProcessClassLevel2TypeComboBox.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' 2013-10-09 BJF: Changed to use the new lookup by both level 1 and 2.
    ''' </remarks>
    Private Sub ProcessClassLevel2TypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessClassLevel2TypeComboBox.SelectedIndexChanged

        If (Me.m_formIsLoaded) Then
            If (Me.ProcessClassLevel2TypeComboBox.SelectedIndex > -1) Then
                Me.btnOK.Enabled = False
                Me.ProcessClassLevel3TypeComboBox.DataSource = Nothing
                'Me.ProcessClassLevel4TypeComboBox.DataSource = Nothing
                Me.ProcessClassComboBox.DataSource = Nothing

                'Dim dtbLevel3LookupTable As DataTable = Utility.ProcessClassLevel3TypeUtility.GetLookupTableByProcessClassLevel2TypeID(CInt(Me.ProcessClassLevel2TypeComboBox.SelectedValue))
                Dim dtbLevel3LookupTable As DataTable = _
                    Utility.ProcessClassLevel3TypeUtility.GetLookupTableByProcessClassLevel1And2(CInt(Me.ProcessClassLevel1TypeComboBox.SelectedValue), _
                                                                                                 CInt(Me.ProcessClassLevel2TypeComboBox.SelectedValue))
                If (dtbLevel3LookupTable IsNot Nothing) Then
                    If (dtbLevel3LookupTable.Rows.Count > 0) Then
                        Me.m_formIsLoaded = False
                        Tools.WindowsForms.LoadComboBox(dtbLevel3LookupTable, Me.ProcessClassLevel3TypeComboBox, False)
                        Me.ProcessClassLevel3TypeComboBox.SelectedIndex = -1
                        Me.m_formIsLoaded = True
                    End If
                End If
            End If
        End If

    End Sub

    ''' <summary>
    ''' Populate the ProcessClassComboBox based on the selected process class levels 1 through 3.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' 2013-10-08 BJF: Changed to populate the new ProcessClassComboBox instead of the level 4 combo box.
    ''' </remarks>
    Private Sub ProcessClassLevel3TypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessClassLevel3TypeComboBox.SelectedIndexChanged

        If (Me.m_formIsLoaded) Then
            If (Me.ProcessClassLevel3TypeComboBox.SelectedIndex > -1) Then
                Me.btnOK.Enabled = False
                'Me.ProcessClassLevel4TypeComboBox.DataSource = Nothing

                'Dim dtbLevel4LookupTable As DataTable = Utility.ProcessClassLevel4TypeUtility.GetLookupTableByProcessClassLevel3TypeID(CInt(Me.ProcessClassLevel3TypeComboBox.SelectedValue))
                'If (dtbLevel4LookupTable IsNot Nothing) Then
                '    If (dtbLevel4LookupTable.Rows.Count > 0) Then
                '        Me.m_formIsLoaded = False
                '        Tools.WindowsForms.LoadComboBox(dtbLevel4LookupTable, Me.ProcessClassLevel4TypeComboBox, False)
                '        Me.ProcessClassLevel4TypeComboBox.SelectedIndex = -1
                '        Me.m_formIsLoaded = True
                '    End If
                'End If

                Me.ProcessClassComboBox.DataSource = Nothing

                Dim dtbProcessClassLookupTable As DataTable = _
                    Utility.ProcessClassUtility.GetByProcessClassLevel123(CInt(Me.ProcessClassLevel1TypeComboBox.SelectedValue), _
                                                                          CInt(Me.ProcessClassLevel2TypeComboBox.SelectedValue), _
                                                                          CInt(Me.ProcessClassLevel3TypeComboBox.SelectedValue))
                If (dtbProcessClassLookupTable IsNot Nothing) Then
                    If dtbProcessClassLookupTable.Rows.Count > 0 Then
                        Me.m_formIsLoaded = False
                        Tools.WindowsForms.LoadComboBox(dtbProcessClassLookupTable, Me.ProcessClassComboBox, False)
                        Me.ProcessClassComboBox.SelectedIndex = -1
                        Me.m_formIsLoaded = True
                    End If
                End If
            End If

        End If

    End Sub

    Private Sub ProcessClassLevel4TypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessClassLevel4TypeComboBox.SelectedIndexChanged

        If (Me.m_formIsLoaded) Then
            If (Me.ProcessClassLevel4TypeComboBox.SelectedIndex > -1) Then
                Try
                    Me.m_objProcessClass = Utility.ProcessClassUtility.GetByProcessClassLevel1234(CInt(ProcessClassLevel1TypeComboBox.SelectedValue), CInt(ProcessClassLevel2TypeComboBox.SelectedValue), CInt(ProcessClassLevel3TypeComboBox.SelectedValue), CInt(ProcessClassLevel4TypeComboBox.SelectedValue))
                Catch ex As Exception
                    Me.m_objProcessClass = Nothing
                End Try

                If (Me.m_objProcessClass IsNot Nothing) Then
                    Me.btnOK.Enabled = True
                    Call Me.DisplaySCC()
                Else
                    MessageBox.Show("An error occurred retrieving the SCC code. The code may not exist.", "SCC Lookup", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        End If

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Call Me.UpdateArrayList()
        Me.Close()
    End Sub

    Private Sub UpdateArrayList()

        With Me.m_list
            .Add(Me.m_objProcessClass.ProcessClassID)
            .Add(Me.m_objProcessClass.ProcessClassName)
        End With

    End Sub

    Private Sub DisplaySCC()
        Dim display As New System.Text.StringBuilder
        With display
            .Append("SCC code: ")
            .AppendLine(Me.m_objProcessClass.ProcessClassID)
            .Append(Me.m_objProcessClass.ProcessClassName)
        End With
        Me.Label2.Text = display.ToString()
    End Sub

    Private Sub ProcessClassComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessClassComboBox.SelectedIndexChanged
        If (Me.m_formIsLoaded) Then
            If (Me.ProcessClassComboBox.SelectedIndex > -1) Then
                Try
                    Me.m_objProcessClass = Utility.ProcessClassUtility.GetByPrimaryKey(Me.ProcessClassComboBox.SelectedValue.ToString)
                Catch ex As Exception
                    Me.m_objProcessClass = Nothing
                End Try

                If (Me.m_objProcessClass IsNot Nothing) Then
                    Me.btnOK.Enabled = True
                    Call Me.DisplaySCC()
                Else
                    MessageBox.Show("An error occurred retrieving the SCC code. The code may not exist.", "SCC Lookup", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        End If
    End Sub
End Class