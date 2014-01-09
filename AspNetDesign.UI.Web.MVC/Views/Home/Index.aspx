<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ProductCatalog.Master" Inherits="System.Web.Mvc.ViewPage<HomePageView>" %>

<%@ Import Namespace="AspNetDesign.Controller.ViewModels.ProductCatalog" %>
<%@ Import Namespace="AspNetDesign.Services.ViewModels" %>
<%@ Import Namespace="AspNetDesign.UI.Web.MVC.Helpers" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="clear: both;"></div>
    <h2>Top Products</h2>
    <div id="items" style="border-width: 1px; padding: 0px; margin: 0px">
        <ul class="items-list">
            <% foreach (ProductSummaryView product in Model.Products)
               {%>
            <li class="item-detail">
                <a class="item-productimage-link"
                    href="<%=Url.Action("Detail", "Product",new { id = product.Id }, null) %>">
                    <img class="item-productimage" src="<%=Html.Resolve("/Content/Images/Products/" + product.Id.ToString() +".jpg")%>" /></a>
                <div class="item-productname"> <%= Html.ActionLink(product.BrandName + " " + product.Name,"Detail", "Product", new { id = product.Id }, null)%>
                </div>
                <div class="item-price">
                    <%= Html.Encode(product.Price)%>
                </div>
            </li>
            <%}%>
        </ul>
    </div>
</asp:Content>
