Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Text
Imports System.Web.Mvc
Imports System.Runtime.CompilerServices

'Public Class HtmlHelper
Public Module HtmlHelpers

    <Extension()>
    Public Function AlphabeticalPager(html As HtmlHelper, selectedLetter As String, firstLetters As IEnumerable(Of String), pageLink As Func(Of String, String)) As HtmlString
        Dim sb = New StringBuilder()
        Dim numbers = Enumerable.Range(0, 10).[Select](Function(i) i.ToString())
        Dim alphabet = Enumerable.Range(65, 26).[Select](Function(i) ChrW(i).ToString()).ToList()
        alphabet.Insert(0, "All")
        alphabet.Insert(1, "0-9")

        Dim ul = New TagBuilder("ul")
        ul.AddCssClass("pagination")
        ul.AddCssClass("alpha")

        For Each letter As String In alphabet
            Dim li = New TagBuilder("li")

            If firstLetters.Contains(letter) OrElse (firstLetters.Intersect(numbers).Any() AndAlso letter = "0-9") OrElse letter = "All" Then
                If selectedLetter = letter OrElse String.IsNullOrEmpty(selectedLetter) AndAlso letter = "All" Then
                    li.AddCssClass("active")
                    Dim span = New TagBuilder("span")
                    span.SetInnerText(letter)
                    li.InnerHtml = span.ToString()
                Else
                    Dim a = New TagBuilder("a")
                    a.MergeAttribute("href", pageLink(letter))
                    a.InnerHtml = letter
                    li.InnerHtml = a.ToString()
                End If
            Else
                li.AddCssClass("inactive")
                Dim span = New TagBuilder("span")
                span.SetInnerText(letter)
                li.InnerHtml = span.ToString()
            End If
            sb.Append(li.ToString())
        Next

        ul.InnerHtml = sb.ToString()
        Return New HtmlString(ul.ToString())
    End Function

End Module
