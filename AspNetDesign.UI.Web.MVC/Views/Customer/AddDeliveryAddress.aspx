<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CustomerAccount.Master" Inherits="System.Web.Mvc.ViewPage<CustomerDeliveryAddressView>" %>

<%@ Import Namespace="AspNetDesign.Controller.ViewModels.CustomerAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Add Delivery Address
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-8">
        <h2 class="breadcrumb">AddDeliveryAddress</h2>
        <% using (Html.BeginForm())
           {%>
        <% Html.RenderPartial("~/Views/Shared/AddressEdit.ascx", Model.Address); %>
        <p>
            <input type="submit" value="Save" class="btn btn-primary" />
        </p>
        <% } %>
    </div>
</asp:Content>
