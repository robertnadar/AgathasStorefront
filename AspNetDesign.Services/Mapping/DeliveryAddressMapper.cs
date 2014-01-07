using AspNetDesign.Model.Customers;
using AspNetDesign.Services.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Services.Mapping
{
    public static class DeliveryAddressMapper
    {
        public static DeliveryAddressView ConvertToDeliveryAddressView(this DeliveryAddress deliveryAddress)
        {
            return Mapper.Map<DeliveryAddress, DeliveryAddressView>(deliveryAddress);
        }
    }
}
