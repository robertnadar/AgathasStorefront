﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ProductCatalog.Master" Inherits="System.Web.Mvc.ViewPage<ProductDetailView>" %>

<%@ Import Namespace="AspNetDesign.Services.ViewModels" %>
<%@ Import Namespace="AspNetDesign.Controller.ViewModels.ProductCatalog" %>
<%@ Import Namespace="AspNetDesign.UI.Web.MVC.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Model.Product.BrandName %> <%=Model.Product.Name %> for only <%=Model.Product.Price %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function addProductToBasket() {
            showOverlay("smoverlay", "basketSummary", 5);
            var postData = { productId: $("#productsizes").val() };
            $.post('<%=Html.Resolve("/Basket/AddToBasket") %>', postData, updateBasket, "json");
        }
        function updateBasket(basketSummaryView) {
            updateBasketSummary(basketSummaryView);
            hideOverlay("smoverlay");
        }
</script>
    <h2><%=Model.Product.BrandName %> <%=Model.Product.Name %></h2>
    <div>
        <span style="float: left">
            <img src="<%=Html.Resolve("/Content/Images/Products/"+ Model.Product.Id.ToString() + ".jpg") %>" />
        </span>
        <div>
            <%=Model.Product.Price %><br />
            <%=Model.Product.BrandName %> <%=Model.Product.Name %><br />
            <p>
                <select id="productsizes">
                    <% foreach (ProductSizeOption option in Model.Product.Products)
                       {%>
                    <option value="<%=option.Id %>"><%=option.SizeName %></option>
                    <%
}%>
                </select>
                <input type="button" onclick="JavaScript:addProductToBasket();" value="+ Add to cart" />
            </p>
            <p>
                * - Rutrum mattis nulla sodales<br />
                * - Duis sodales tempor felis ac<br />
                * - Ut porta metus a metus<br />
            </p>
        </div>
    </div>
    <div style="clear: both;" />
    <h3>Returns / Delivery / Info</h3>
    <p>
        Pellentesque magna lorem, faucibus quis feugiat non, aliquet in libero.
Integer sit amet gravida erat. Duis sodales tempor felis ac adipiscing.
Suspendisse nonlectus enim.
Vestibulum aliquet imperdiet posuere. Suspendisse ac diam odio.
Ut porta metus a
metus rutrum mattis. Nulla sodales, arcu ut mollis vehicula, tellus ante
ultricies mauris, ultricies porttitor nunc purus a nisi.
    </p>
    <p>
        Nulla ipsum urna, cursus sed consectetur nec, varius quis diam.
Morbi consequat sapien ut leo placerat ornare.
    </p>
</asp:Content>
