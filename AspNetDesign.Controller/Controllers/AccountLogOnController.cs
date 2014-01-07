using AspNetDesign.Controller.ActionArguments;
using AspNetDesign.Controller.ViewModels.Account;
using AspNetDesign.Infrastructure.Authentication;
using AspNetDesign.Services.Interfaces;
using AspNetDesign.Services.Messaging.ProductCatalogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetDesign.Controller.Controllers
{
    public class AccountLogOnController : BaseAccountController
    {
        public AccountLogOnController(ILocalAuthenticationService authenticationService,ICustomerService customerService,IExternalAuthenticationService externalAuthenticationService, IFormsAuthentication formsAuthentication, IActionArguments actionArguments)
            : base(authenticationService, customerService,externalAuthenticationService,formsAuthentication, actionArguments)
        {
        }

        public ActionResult LogOn()
        {
            AccountView accountView = InitializeAccountViewWithIssue(false, "");
            return View(accountView);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(string email, string password, string returnUrl)
        {
            User user = _authenticationService.Login(email, password);
            if (user.IsAuthenticated)
            {
                _formsAuthentication.SetAuthenticationToken(user.AuthenticationToken);
                if (!String.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                AccountView accountView = InitializeAccountViewWithIssue(true, "Sorry we could not log you in. Please try again.");
                accountView.CallBackSettings.ReturnUrl = GetReturnActionFrom(returnUrl).ToString();
                return View("LogOn", accountView);
            }
        }

        public ActionResult ReceiveTokenAndLogon(string token, string returnUrl)
        {
            User user = _externalAuthenticationService.GetUserDetailsFrom(token);
            if (user.IsAuthenticated)
            {
                _formsAuthentication.SetAuthenticationToken(user.AuthenticationToken);
                GetCustomerRequest getCustomerRequest = new GetCustomerRequest();
                getCustomerRequest.CustomerIdentityToken = user.AuthenticationToken;
                GetCustomerResponse getCustomerResponse = _customerService.GetCustomer(getCustomerRequest);
                if (getCustomerResponse.CustomerFound)
                {
                    return RedirectBasedOn(returnUrl);
                }
                else
                {
                    AccountView accountView = InitializeAccountViewWithIssue(true,
                    "Sorry we could not find your customer account. " +
                    "If you don’t have an account with us " +
                    "please register.");
                    accountView.CallBackSettings.ReturnUrl = returnUrl;
                    return View("LogOn", accountView);
                }
            }
            else
            {
                AccountView accountView = InitializeAccountViewWithIssue(true,
                "Sorry we could not log you in." +
                " Please try again.");
                accountView.CallBackSettings.ReturnUrl = returnUrl;
                return View("LogOn", accountView);
            }
        }

        public ActionResult SignOut()
        {
            _formsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private AccountView InitializeAccountViewWithIssue(bool hasIssue,string message)
        {
            AccountView accountView = new AccountView();
            accountView.CallBackSettings.Action = "ReceiveTokenAndLogon";
            accountView.CallBackSettings.Controller = "AccountLogOn";
            accountView.HasIssue = hasIssue;
            accountView.Message = message;
            string returnUrl = _actionArguments.GetValueForArgument(ActionArgumentKey.ReturnUrl);
            accountView.CallBackSettings.ReturnUrl = GetReturnActionFrom(returnUrl).ToString();
            return accountView;
        }
    }

}
