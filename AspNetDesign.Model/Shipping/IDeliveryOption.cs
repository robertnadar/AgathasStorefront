using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Model.Shipping
{
    public interface IDeliveryOption
    {
        int Id { get; set; }
        decimal FreeDeliverThreshold { get;}
        decimal Cost { get;}
        ShippingService ShippingService { get; }
        decimal GetDeliveryChargeForBasketTotalOf(decimal total);
    }
}
