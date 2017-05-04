Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class ProductModel
    Public Property ProductID() As Integer
        Get
            Return m_ProductID
        End Get
        Set(value As Integer)
            m_ProductID = Value
        End Set
    End Property
    Private m_ProductID As Integer

    Public Property ProductNumber() As String
        Get
            Return m_ProductNumber
        End Get
        Set(value As String)
            m_ProductNumber = Value
        End Set
    End Property
    Private m_ProductNumber As String

    Public Property ProductName() As String
        Get
            Return m_ProductName
        End Get
        Set(value As String)
            m_ProductName = Value
        End Set
    End Property
    Private m_ProductName As String

    Public Property StandardCost() As Decimal
        Get
            Return m_StandardCost
        End Get
        Set(value As Decimal)
            m_StandardCost = value
        End Set
    End Property
    Private m_StandardCost As Decimal

    Public Property Color() As String
        Get
            Return m_Color
        End Get
        Set(value As String)
            m_Color = value
        End Set
    End Property
    Private m_Color As String

    Public Property ProductCategory() As String
        Get
            Return m_ProductCategory
        End Get
        Set(value As String)
            m_ProductCategory = value
        End Set
    End Property
    Private m_ProductCategory As String

End Class
