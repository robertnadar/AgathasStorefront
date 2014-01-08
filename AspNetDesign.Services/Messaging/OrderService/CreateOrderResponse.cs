using AspNetDesign.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Services.Messaging.OrderService
{
    public class CreateOrderResponse
    {
        public OrderView Order { get; set; }
    }
}
