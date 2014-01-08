using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Services.Messaging.OrderService
{
    public class SetOrderPaymentRequest
    {
        public string PaymentToken { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMerchant { get; set; }
        public int OrderId { get; set; }
    }
}
