Imports System
Imports System.Collections.Generic


Public Class HomeController
    Inherits System.Web.Mvc.Controller


    Function Index(selectedLetter As String) As ActionResult
        Dim model = New AlphabeticalPagingViewModel()
        model.SelectedLetter = selectedLetter

        Using context = New AdventureWorks2012Entities()

            model.FirstLetters = context.Products.GroupBy(Function(p) p.Name.Substring(0, 1)) _
                .[Select](Function(x) x.Key.ToUpper()).ToList()

            model.Products = New List(Of ProductModel)()

            If String.IsNullOrEmpty(selectedLetter) OrElse selectedLetter = "All" Then

                model.Products.AddRange((From item In context.Products
                        Group Join category In context.ProductSubcategories
                            On item.ProductSubcategoryID Equals category.ProductSubcategoryID
                        Into ProductCategory = Group
                            From category In ProductCategory.DefaultIfEmpty()
                        Select New ProductModel() With { _
                            .ProductName = item.Name, _
                            .ProductID = item.ProductID, _
                            .ProductNumber = item.ProductNumber, _
                            .Color = If((String.IsNullOrEmpty(item.Color)), "NA", item.Color), _
                            .StandardCost = item.StandardCost, _
                            .ProductCategory = If((String.IsNullOrEmpty(category.Name)), "NA", category.Name) _
                }).ToList())
            Else
                If selectedLetter = "0-9" Then
                    Dim numbers = Enumerable.Range(0, 10).[Select](Function(i) i.ToString())

                    model.Products.AddRange((From item In context.Products
                        Where (numbers.Contains(item.Name.Substring(0, 1)))
                        Group Join category In context.ProductSubcategories
                            On item.ProductSubcategoryID Equals category.ProductSubcategoryID
                        Into ProductCategory = Group
                            From category In ProductCategory.DefaultIfEmpty()
                        Select New ProductModel() With { _
                            .ProductName = item.Name, _
                            .ProductID = item.ProductID, _
                            .ProductNumber = item.ProductNumber, _
                            .Color = If((String.IsNullOrEmpty(item.Color)), "NA", item.Color), _
                            .StandardCost = item.StandardCost, _
                            .ProductCategory = If((String.IsNullOrEmpty(category.Name)), "NA", category.Name) _
                    }).ToList())

                Else
                    model.Products.AddRange((From item In context.Products
                        Where (item.Name.StartsWith(selectedLetter))
                        Group Join category In context.ProductSubcategories
                            On item.ProductSubcategoryID Equals category.ProductSubcategoryID
                        Into ProductCategory = Group
                            From category In ProductCategory.DefaultIfEmpty()
                        Select New ProductModel() With { _
                            .ProductName = item.Name, _
                            .ProductID = item.ProductID, _
                            .ProductNumber = item.ProductNumber, _
                            .Color = If((String.IsNullOrEmpty(item.Color)), "NA", item.Color), _
                            .StandardCost = item.StandardCost, _
                            .ProductCategory = If((String.IsNullOrEmpty(category.Name)), "NA", category.Name) _
                    }).ToList())
                End If
            End If

        End Using

        Return View(model)

    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
