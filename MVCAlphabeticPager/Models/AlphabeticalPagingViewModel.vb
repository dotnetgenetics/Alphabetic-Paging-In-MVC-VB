Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class AlphabeticalPagingViewModel

    Public Property Products() As List(Of ProductModel)
        Get
            Return m_ProductID
        End Get
        Set(value As List(Of ProductModel))
            m_ProductID = value
        End Set
    End Property
    Private m_ProductID As List(Of ProductModel)

    Public Property FirstLetters() As List(Of String)
        Get
            Return m_FirstLetters
        End Get
        Set(value As List(Of String))
            m_FirstLetters = value
        End Set
    End Property
    Private m_FirstLetters As List(Of String)

    Public Property SelectedLetter() As String
        Get
            Return m_SelectedLetter
        End Get
        Set(value As String)
            m_SelectedLetter = value
        End Set
    End Property
    Private m_SelectedLetter As String

End Class
