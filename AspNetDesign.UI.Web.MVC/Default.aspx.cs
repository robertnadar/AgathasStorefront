using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetDesign.UI.Web.MVC
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var httpContext = HttpContext.Current;
            httpContext.Server.TransferRequest("/", true);
        }
    }
}