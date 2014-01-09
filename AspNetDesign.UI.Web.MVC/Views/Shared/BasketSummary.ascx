<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<BasketSummaryView>" %>
<%@ Import Namespace="AspNetDesign.Controller.ViewModels" %>
<%--<div id="smoverlay" class="smoverlay"></div>
<div id="basketSummary">
    <span class="basket-details">
        <%=Html.ActionLink("Your Basket", "Detail", "Basket")%>
        <span id="basket-summary-text">
            <% if (Model.NumberOfItems == 0)
               { %>
                    is empty
            <% }
               else
               { %>
            <%=Model.NumberOfItems%> Item(s) at <%=Model.BasketTotal%>
            <% }%>
        </span>
    </span>
</div>--%>
<%=Html.ActionLink("Your Basket", "Detail", "Basket")%>
<% if (Model.NumberOfItems == 0)
   { %>
                    is empty
            <% }
   else
   { %>
<%=Model.NumberOfItems%> Item(s) at <%=Model.BasketTotal%>
<% }%>
