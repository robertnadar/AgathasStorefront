<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AccountView>" %>

<%@ Import Namespace="AspNetDesign.Controller.ViewModels.Account" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>
<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <legend>Log On</legend>
    <div class="col-xs-6">
        <% if (Model.HasIssue)
           { %>
        <p>
            <div style="color: #D63301; background-color: #FFCCBA; padding: 15px 10px 15px 50px;">
                <%=Html.Encode(Model.Message)%>
            </div>
        </p>
        <% } %>

        <p>Login with your existing account associated with this site</p>
        <hr />
        <% Html.RenderPartial("~/Views/Shared/JanrainLogin.ascx", Model.CallBackSettings); %>
    </div>
    <div class="col-xs-6">

        <% using (Html.BeginForm())
           { %>
        <p>Login with an account created with us. <%= Html.ActionLink("Register", "Register", "AccountRegister") %> if you don’t have an account.</p>
        <hr />
        <div class="col-xs-6">
            <p>
                <label for="username">Email:</label><br />
                <%= Html.TextBox("email","", new{@class="form-control"})%>
            </p>
            <p>
                <label for="password">Password:</label><br />
                <%= Html.Password("password", "", new{@class="form-control"}) %>
            </p>
            <p>
                <input type="submit" value="Log On" class="btn btn-primary" />
            </p>
        </div>
    </div>
    <% } %>
</asp:Content>
