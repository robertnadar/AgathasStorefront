﻿<%@ Page Title="" Language="C#"
    MasterPageFile="~/Views/Shared/CustomerAccount.Master"
    Inherits="System.Web.Mvc.ViewPage<CustomersOrderSummaryView>" %>
<%@ Import Namespace="AspNetDesign.Services.ViewModels" %>
<%@ Import Namespace="AspNetDesign.Controller.ViewModels.CustomerAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Your Order History
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Your Orders</h2>
    <ul class="list-group">
        <% foreach (OrderSummaryView order in Model.Orders)
           {
        %>
        <li class="list-group-item"><%=Html.Encode(order.Created.ToLongDateString()) %>
            <% if (order.IsSubmitted == false)
               { %>
            <%=Html.ActionLink("Pay", "CreatePaymentFor", "Payment", new { orderId = order.Id}, null)%>
            <% } %>
            <%=Html.ActionLink("View Detail", "Detail", "Order", new { orderId = order .Id}, null)%>
        </li>
        <% }%>
    </ul>
</asp:Content>
