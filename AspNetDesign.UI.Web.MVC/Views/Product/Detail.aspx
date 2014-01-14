<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ProductCatalog.Master" Inherits="System.Web.Mvc.ViewPage<ProductDetailView>" %>

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
    <div class="row">
        <div class="col-md-3">
            <img src="<%=Html.Resolve("/Content/Images/Products/" + Model.Product.Name.ToString() + ".jpg") %>" class="imageSize"/>
        </div>
        <div class="col-md-9">
            <p><%=Model.Product.Price %>$</p>
            <p>
                <select id="productsizes">
                    <% foreach (ProductSizeOption option in Model.Product.Products)
                       {%>
                    <option value="<%=option.Id %>"><%=option.SizeName %></option>
                    <%
}%>
                </select>
                <input type="button" onclick="javascript:addProductToBasket();" class="btn btn-primary" value="+ Add to cart" />
            </p>
            <p>
                * - Rutrum mattis nulla sodales<br />
                * - Duis sodales tempor felis ac<br />
                * - Ut porta metus a metus<br />
            </p>
        </div>
    </div>
</asp:Content>
