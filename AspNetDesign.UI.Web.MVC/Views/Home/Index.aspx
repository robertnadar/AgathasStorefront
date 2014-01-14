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
    <div class="col-xs-6 col-md-3">
        <div class="thumbnail">
            <a 
                href="<%=Url.Action("Detail", "Product",new { id = product.Id }, null) %>">
                <img  src="<%=Html.Resolve("/Content/Images/Products/" + product.Name.ToString() +".jpg")%>" class="image-link"/></a>
            <div class="caption">
                <h5><%= Html.ActionLink(product.BrandName + " " + product.Name,"Detail", "Product", new { id = product.Id }, null)%></h5>
                <p><%= Html.Encode(product.Price)%> $</p>
            </div>
        </div>
    </div>
    <%}%>
</asp:Content>
