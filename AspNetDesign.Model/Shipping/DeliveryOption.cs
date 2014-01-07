using AspNetDesign.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Model.Shipping
{
    public class DeliveryOption : EntityBase<int>, IAggregateRoot, IDeliveryOption
    {
        private readonly decimal _freeDeliveryThreshold;
        private readonly decimal _cost;
        private readonly ShippingService _shippingAddress;

        public DeliveryOption()
        {

        }

        public DeliveryOption(decimal freeDeliveryThreshold, decimal cost, ShippingService shippingService)
        {
            _freeDeliveryThreshold = freeDeliveryThreshold;
            _cost = cost;
            _shippingAddress = shippingService;
        }


        public decimal FreeDeliverThreshold
        {
            get { return _freeDeliveryThreshold; }
        }

        public decimal Cost
        {
            get { return _cost; }
        }

        public ShippingService ShippingService
        {
            get { return _shippingAddress; }
        }

        public decimal GetDeliveryChargeForBasketTotalOf(decimal total)
        {
            if (total > FreeDeliverThreshold)
            {
                return 0;
            }
            return Cost;
        }

        protected override void Validate()
        {
           // throw new NotImplementedException();
        }
    }
}
