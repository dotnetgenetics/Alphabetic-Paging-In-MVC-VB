'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class ProductSubcategory
    Public Property ProductSubcategoryID As Integer
    Public Property ProductCategoryID As Integer
    Public Property Name As String
    Public Property rowguid As System.Guid
    Public Property ModifiedDate As Date

    Public Overridable Property Products As ICollection(Of Product) = New HashSet(Of Product)

End Class
