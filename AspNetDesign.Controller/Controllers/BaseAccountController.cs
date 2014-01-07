using AspNetDesign.Controller.ActionArguments;
using AspNetDesign.Infrastructure.Authentication;
using AspNetDesign.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetDesign.Controller.Controllers
{
    public class BaseAccountController : System.Web.Mvc.Controller
    {
        protected readonly ILocalAuthenticationService _authenticationService;
        protected readonly ICustomerService _customerService;
        protected readonly IExternalAuthenticationService _externalAuthenticationService;
        protected readonly IFormsAuthentication _formsAuthentication;
        protected readonly IActionArguments _actionArguments;

        public BaseAccountController(ILocalAuthenticationService authenticationService, ICustomerService customerService, IExternalAuthenticationService externalAuthenticationService,
        IFormsAuthentication formsAuthentication,
        IActionArguments actionArguments)
        {
            _authenticationService = authenticationService;
            _customerService = customerService;
            _externalAuthenticationService = externalAuthenticationService;
            _formsAuthentication = formsAuthentication;
            _actionArguments = actionArguments;
        }

        public ActionResult RedirectBasedOn(string returnUrl)
        {
            if (returnUrl == ActionArgumentKey.GoToCheckout.ToString())
                return RedirectToAction("Checkout", "Checkout");
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionArgumentKey GetReturnActionFrom(string returnUrl)
        {
            if (!String.IsNullOrEmpty(returnUrl) &&
            returnUrl.ToLower().Contains("checkout"))
                return ActionArgumentKey.GoToCheckout;
            else
                return ActionArgumentKey.GoToAccount;
        }
    }
}
