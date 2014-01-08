using AspNetDesign.Infrastructure.CookieStorage;
using AspNetDesign.Infrastructure.Logging;
using AspNetDesign.Infrastructure.Payments;
using AspNetDesign.Services.Interfaces;
using AspNetDesign.Services.Messaging.OrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetDesign.Controller.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly ICookieStorageService _cookieStorageService;

        public PaymentController(ICookieStorageService cookieStorageService, IPaymentService paymentService, IOrderService orderService)
            : base(cookieStorageService)
        {
            _paymentService = paymentService;
            _orderService = orderService;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void PaymentCallBack(FormCollection collection)
        {
            int orderId = _paymentService.GetOrderIdFor(collection);
            GetOrderRequest request = new GetOrderRequest() { OrderId = orderId };
            GetOrderResponse response = _orderService.GetOrder(request);
            OrderPaymentRequest orderPaymentRequest = response.Order.ConvertToOrderPaymentRequest();
            TransactionResult transactionResult = _paymentService.HandleCallBack(orderPaymentRequest, collection);
            if (transactionResult.PaymentOk)
            {
                SetOrderPaymentRequest paymentRequest = new SetOrderPaymentRequest();
                paymentRequest.Amount = transactionResult.Amount;
                paymentRequest.PaymentToken = transactionResult.PaymentToken;
                paymentRequest.PaymentMerchant = transactionResult.PaymentMerchant;
                paymentRequest.OrderId = orderId;
                _orderService.SetOrderPayment(paymentRequest);
            }
            else
            {
                LoggingFactory.GetLogger().Log(String.Format("Payment not ok for order id {0}, payment token {1}",orderId, transactionResult.PaymentToken));
            }
        }

        public ActionResult CreatePaymentFor(int orderId)
        {
            GetOrderRequest request = new GetOrderRequest() { OrderId = orderId };
            GetOrderResponse response = _orderService.GetOrder(request);
            OrderPaymentRequest orderPaymentRequest = response.Order.ConvertToOrderPaymentRequest();
            PaymentPostData paymentPostData = _paymentService.GeneratePostDataFor(orderPaymentRequest);
            return View("PaymentPost", paymentPostData);
        }

        public ActionResult PaymentComplete()
        {
            return View();
        }

        public ActionResult PaymentCancel()
        {
            return View();
        }
    }
}
