<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CustomerAccount.Master" Inherits="System.Web.Mvc.ViewPage<CustomerDetailView>" %>

<%@ Import Namespace="AspNetDesign.Services.ViewModels" %>
<%@ Import Namespace="AspNetDesign.Controller.ViewModels.CustomerAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Customer Delivery Address Book
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-8">
        <h2 class="breadcrumb">Delivery Addresses</h2>
        <%=Html.ActionLink("Add new address", "AddDeliveryAddress", "Customer")%>
        <ul class="list-group">
            <% foreach (DeliveryAddressView deliveryAddress in Model.Customer.DeliveryAddressBook)
               {
            %>
            <li class="list-group-item"><%=Html.ActionLink(deliveryAddress.Name, "EditDeliveryAddress", "Customer", new { deliveryAddressId = deliveryAddress.Id }, null)%>
            </li>
            <% }%>
        </ul>
    </div>
</asp:Content>
