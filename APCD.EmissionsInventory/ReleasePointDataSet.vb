Partial Class ReleasePointDataSet
    Partial Class autoE91T_StacksDataTable

        Private Sub autoE91T_StacksDataTable_autoE91T_StacksRowChanging(ByVal sender As System.Object, ByVal e As autoE91T_StacksRowChangeEvent) Handles Me.autoE91T_StacksRowChanging

        End Sub

    End Class

    Partial Class autoE91T_FugitivesDataTable

        Private Sub autoE91T_FugitivesDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.CompanyCommentColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class ReleasePointDataTable

        Private Sub ReleasePointDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.APCDCommentColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
