Public Class O3DPollutants

    Private m_COO3D As Double = -1
    Public Property COO3D() As Double
        Get
            Return m_COO3D
        End Get
        Set(ByVal value As Double)
            m_COO3D = value
        End Set
    End Property

    Private m_COAnnual As Double = -1
    Public Property COAnnual() As Double
        Get
            Return m_COAnnual
        End Get
        Set(ByVal value As Double)
            m_COAnnual = value
        End Set
    End Property

    Private m_NOXO3D As Double = -1
    Public Property NOXO3D() As Double
        Get
            Return m_NOXO3D
        End Get
        Set(ByVal value As Double)
            m_NOXO3D = value
        End Set
    End Property

    Private m_NOXAnnual As Double = -1
    Public Property NOXAnnual() As Double
        Get
            Return m_NOXAnnual
        End Get
        Set(ByVal value As Double)
            m_NOXAnnual = value
        End Set
    End Property


    Private m_VOCO3D As Double = -1
    Public Property VOCO3D() As Double
        Get
            Return m_VOCO3D
        End Get
        Set(ByVal value As Double)
            m_VOCO3D = value
        End Set
    End Property


    Private m_VOCAnnual As Double = -1
    Public Property VOCAnnual() As Double
        Get
            Return m_VOCAnnual
        End Get
        Set(ByVal value As Double)
            m_VOCAnnual = value
        End Set
    End Property

End Class
