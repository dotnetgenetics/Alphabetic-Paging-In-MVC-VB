@Code
    ViewData("Title") = "Alphabet Based Paging"
End Code

@ModelType MVCAlphabeticPager.AlphabeticalPagingViewModel

<br />
<div class="panel panel-primary">
    <div class="panel-heading panel-head">Product Listing</div>
    <div class="panel-body">
        @Html.AlphabeticalPager(Model.SelectedLetter, Model.FirstLetters, Function(x) Url.Action("Index", New With {.selectedLetter = x}))
        <table class="table" style="margin: 4px">
            <tr>
                <th>
                    @Html.DisplayName("Product ID")
                </th>
                <th>
                    @Html.DisplayName("Product Number")
                </th>
                <th>
                    @Html.DisplayName("Product Name")
                </th>
                <th>
                    @Html.DisplayName("Standard Cost")
                </th>
                <th>
                    @Html.DisplayName("Color")
                </th>
                <th>
                    @Html.DisplayName("Category")
                </th>
            </tr>
            @For Each item In Model.Products
                Dim currentItem = item
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) currentItem.ProductID)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) currentItem.ProductNumber)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) currentItem.ProductName)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) currentItem.StandardCost)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) currentItem.Color)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) currentItem.ProductCategory)
                </td>
            </tr>   
            Next

        </table>
        @Html.AlphabeticalPager(Model.SelectedLetter, Model.FirstLetters, Function(x) Url.Action("Index", New With {.selectedLetter = x}))
    </div>
</div>