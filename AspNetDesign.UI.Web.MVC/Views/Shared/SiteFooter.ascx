<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="AspNetDesign.UI.Web.MVC.Helpers" %>
<div id="prefooter">
    <span style="float: left; margin-left: 20px;">
        <table>
            <tr>
                <td>
                    <ul>
                        <li class="footer-list-header">Help:</li>
                    </ul>
                </td>
                <td>
                    <ul>
                        <li class="footer-list-header">About:</li>
                    </ul>
                </td>
                <td>
                    <ul>
                        <li class="footer-list-header">Social:</li>
                    </ul>
                </td>
            </tr>
        </table>
    </span>
    <span style="float: right; margin-top: 60px; margin-right: 10px;">
        <a href="<%=Html.Resolve("") %>">
            <%--<img alt="Clothing Store" src="<%=Html.Resolve("/Content/Images/Structure/sm_logo.png")%>" border="0" />--%>
        </a>
    </span>
</div>
<div id="footer">
</div>
