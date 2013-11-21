using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Model.Shipping
{
    public class NullDeliveryOption : IDeliveryOption
    {
        public int Id
        {
            get;
            set;
        }

        public decimal FreeDeliverThreshold
        {
            get { return 0; }
        }

        public decimal Cost
        {
            get { return 0; }
        }

        public ShippingService ShippingService
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public decimal GetDeliveryChargeForBasketTotalOf(decimal total)
        {
            return 0;
        }
    }
}
