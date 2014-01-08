using AspNetDesign.Infrastructure.Payments;
using AspNetDesign.Services.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Controller
{
    public static class OrderMapper
    {
        public static OrderPaymentRequest ConvertToOrderPaymentRequest(this OrderView order)
        {
            return Mapper.Map<OrderView, OrderPaymentRequest>(order);
        }
    }
}
