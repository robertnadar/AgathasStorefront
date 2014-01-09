<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<CategoryView>>" %>
<%@ Import Namespace="AspNetDesign.Services.ViewModels" %>
<ul class="nav navbar-nav navbar-right">
    <li class="dropdown">
        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Categories<b class="caret"></b></a>
        <ul class="dropdown-menu"> 
            <% foreach (CategoryView categoryView in Model)
               { %>
            <li><%= Html.ActionLink(categoryView.Name, "GetProductsByCategory", "Product", new { categoryId = categoryView.Id }, null)%></li>
            <% } %>
        </ul>
    </li>
</ul>