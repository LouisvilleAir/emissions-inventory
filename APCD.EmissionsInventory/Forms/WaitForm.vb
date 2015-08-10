Public Class WaitForm

    Sub New(ByVal seconds As Int32)
        InitializeComponent()
        Me.m_seconds = seconds
    End Sub

    Private m_seconds As Int32

    Private Sub WaitForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Timer1.Interval = Me.m_seconds * 1000
        Me.Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub

End Class