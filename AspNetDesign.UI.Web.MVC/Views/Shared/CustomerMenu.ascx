<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<ul class="list-group">
    <li class="list-group-item"><%=Html.ActionLink("Your Details", "Detail", "Customer") %></li>
    <li class="list-group-item"><%=Html.ActionLink("Delivery Address Book", "DeliveryAddresses", "Customer")%></li>
    <li class="list-group-item"><%=Html.ActionLink("Your Orders", "List", "Order")%></li>
</ul>
