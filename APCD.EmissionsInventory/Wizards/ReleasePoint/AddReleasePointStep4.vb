Imports System.Data.OleDb

Public Class AddReleasePointStep4

    Public Sub New(ByVal ds As EmissionsDataSet)
        InitializeComponent()
        Me.m_ds = ds
    End Sub

    Private m_ds As EmissionsDataSet

    Private Sub AddReleasePointStep4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '
    End Sub

#Region "----- buttons -----"

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        ''Call Me.AddReleasePoint_Step3()
        GlobalVariables.AddReleasePointStep = GlobalVariables.WizardStep._Back
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Cursor = Cursors.WaitCursor

        Dim releasePointID As Int32

        Try
            Try
                'release point
                Me.TableAdapterManager.ReleasePointTableAdapter.Connection.Open()
                Me.TableAdapterManager.ReleasePointTableAdapter.Update(Me.m_ds.ReleasePoint)
                Dim cmd As New OleDbCommand("SELECT @@IDENTITY", Me.TableAdapterManager.ReleasePointTableAdapter.Connection)
                releasePointID = CInt(cmd.ExecuteScalar)
            Catch ex As Exception
                GlobalMethods.HandleError(ex)
                If (ex.Message = GlobalVariables.ErrorMessage.Database.DuplicateRecord) Then
                    Throw New ApplicationException("A release point with the ID your trying to add already exists. Change the ID and try again.")
                Else
                    Throw New ApplicationException("An error occured saving the release point.")
                End If

            Finally
                Me.TableAdapterManager.ReleasePointTableAdapter.Connection.Close()
            End Try

            Try
                'detail
                For Each row As EmissionsDataSet.ReleasePointDetailRow In Me.m_ds.ReleasePointDetail.Rows
                    row.ReleasePointID = releasePointID
                Next
                Me.TableAdapterManager.ReleasePointDetailTableAdapter.Update(Me.m_ds.ReleasePointDetail)
            Catch ex2 As Exception
                GlobalMethods.HandleError(ex2)
                Throw New ApplicationException("An error occured saving the release point detail.")
            End Try

            Try
                'year
                Me.m_ds.ReleasePointYear.Rows(0)(EmissionsDataSet.ReleasePointYear.ReleasePointIDColumn.ColumnName) = releasePointID
                Me.TableAdapterManager.ReleasePointYearTableAdapter.Update(Me.m_ds.ReleasePointYear)
            Catch ex3 As Exception
                GlobalMethods.HandleError(ex3)
                Throw New ApplicationException("An error occured saving the release point year.")
            End Try
            GlobalVariables.AddReleasePointStep = GlobalVariables.WizardStep._Save
        Catch exMain As Exception
            MessageBox.Show(exMain.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Cursor = Cursors.Default

        Me.Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#End Region '----- buttons -----

End Class