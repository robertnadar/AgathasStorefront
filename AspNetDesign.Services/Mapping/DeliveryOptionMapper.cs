using AspNetDesign.Model.Shipping;
using AspNetDesign.Services.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Services.Mapping
{
    public static class DeliveryOptionMapper
    {
        public static IEnumerable<DeliveryOptionView> ConvertToDeliveryOptionViews(this IEnumerable<DeliveryOption> deliveryOptions)
        {
            return Mapper.Map<IEnumerable<DeliveryOption>, IEnumerable<DeliveryOptionView>>(deliveryOptions);
        }
    }
}
