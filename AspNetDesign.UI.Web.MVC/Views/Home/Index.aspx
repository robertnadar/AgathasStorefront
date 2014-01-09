<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ProductCatalog.Master" Inherits="System.Web.Mvc.ViewPage<HomePageView>" %>

<%@ Import Namespace="AspNetDesign.Controller.ViewModels.ProductCatalog" %>
<%@ Import Namespace="AspNetDesign.Services.ViewModels" %>
<%@ Import Namespace="AspNetDesign.UI.Web.MVC.Helpers" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Top Products</h3>   
    <% foreach (ProductSummaryView product in Model.Products)
       {%>
    <div class="col-sm-6 col-md-4">
        <div class="thumbnail">
            <a class="item-productimage-link"
                href="<%=Url.Action("Detail", "Product",new { id = product.Id }, null) %>">
                <img class="item-productimage" src="<%=Html.Resolve("/Content/Images/Products/" + product.Id.ToString() +".jpg")%>" /></a>
            <div class="caption">
                <h3><%= Html.ActionLink(product.BrandName + " " + product.Name,"Detail", "Product", new { id = product.Id }, null)%></h3>
                <p><%= Html.Encode(product.Price)%> $</p>
            </div>
        </div>
    </div>
    <%}%>
</asp:Content>
