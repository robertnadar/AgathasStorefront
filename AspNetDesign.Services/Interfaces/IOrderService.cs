using AspNetDesign.Services.Messaging.OrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Services.Interfaces
{
    public interface IOrderService
    {
        CreateOrderResponse CreateOrder(CreateOrderRequest request);
        SetOrderPaymentResponse SetOrderPayment(SetOrderPaymentRequest paymentRequest);
        GetOrderResponse GetOrder(GetOrderRequest request);
    }
}
