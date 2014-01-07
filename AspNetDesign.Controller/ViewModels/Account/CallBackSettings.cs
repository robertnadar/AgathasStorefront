using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Controller.ViewModels.Account
{
    public class CallBackSettings
    {
        public string ReturnUrl { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
