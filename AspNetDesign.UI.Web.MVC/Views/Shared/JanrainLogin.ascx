<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CallBackSettings>" %>
<%@ Import Namespace="AspNetDesign.Controller.ViewModels.Account" %>
<%@ Import Namespace="AspNetDesign.UI.Web.MVC.Helpers" %>
<script type="text/javascript">
    (function () {
        if (typeof window.janrain !== 'object') window.janrain = {};
        if (typeof window.janrain.settings !== 'object') window.janrain.settings = {};
        
        janrain.settings.tokenUrl = '<%=Html.Resolve("/" + Model.Controller +"/" + Model.Action + "/?returnUrl=" + Model.ReturnUrl)%>';
        function isReady() { janrain.ready = true; };
        if (document.addEventListener) {
            document.addEventListener("DOMContentLoaded", isReady, false);
        } else {
            window.attachEvent('onload', isReady);
        }

        var e = document.createElement('script');
        e.type = 'text/javascript';
        e.id = 'janrainAuthWidget';

        if (document.location.protocol === 'https:') {
            e.src = 'https://rpxnow.com/js/lib/aspdesignpatterns-robert/engage.js';
        } else {
            e.src = 'http://widget-cdn.rpxnow.com/js/lib/aspdesignpatterns-robert/engage.js';
        }

        var s = document.getElementsByTagName('script')[0];
        s.parentNode.insertBefore(e, s);
    })();
</script>
<div id="janrainEngageEmbed"></div>