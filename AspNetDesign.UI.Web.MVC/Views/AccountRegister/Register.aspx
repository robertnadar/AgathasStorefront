<%@ Page Language="C#"
    MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<AccountView>" %>

<%@ Import Namespace="AspNetDesign.Controller.ViewModels.Account" %>
<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>
<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <% if (Model.HasIssue)
       { %>
    <p>
        <div style="color: #D63301; background-color: #FFCCBA; padding: 15px 10px 15px 50px;">
            <%=Html.Encode(Model.Message)%>
        </div>
    </p>
    <% } %>
    <div class="col-xs-6">
        <h5>Associate an existing account with us</h5>
        <hr />
        <div>
            <% Html.RenderPartial("~/Views/Shared/JanrainLogin.ascx", Model.CallBackSettings); %>
        </div>
    </div>
    <div class="col-xs-6">
        <% using (Html.BeginForm())
           { %>
        <h5>Don’t have an internet account? Create an account with us</h5>
        <hr />
        <div class="col-xs-6">
            <p>
                <label for="email">Email:</label><br />
                <%= Html.TextBox("email","", new{@class="form-control"}) %>
            </p>
            <p>
                <label for="password">Password:</label><br />
                <%= Html.Password("password","", new{@class="form-control"}) %>
            </p>
            <p>
                <label for="confirmPassword">Confirm password:</label><br />
                <%= Html.Password("confirmPassword","", new{@class="form-control"}) %>
            </p>
            <p>
                <label for="email">First Name:</label><br />
                <%= Html.TextBox("FirstName","", new{@class="form-control"})%>
            </p>
            <p>
                <label for="email">Second Name:</label><br />
                <%= Html.TextBox("SecondName","", new{@class="form-control"})%>
            </p>
            <p>
                <input type="submit" value="Register" class="btn btn-primary" />
            </p>
        </div>
    </div>
    <% } %>
</asp:Content>
