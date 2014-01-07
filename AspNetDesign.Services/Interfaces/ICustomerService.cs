using AspNetDesign.Services.Messaging.ProductCatalogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Services.Interfaces
{
    public interface ICustomerService
    {
        CreateCustomerResponse CreateCustomer(CreateCustomerRequest request);
        GetCustomerResponse GetCustomer(GetCustomerRequest request);
        ModifyCustomerResponse ModifyCustomer(ModifyCustomerRequest request);
        DeliveryAddressAddResponse AddDeliveryAddress(DeliveryAddressAddRequest request);
        DeliveryAddressModifyResponse ModifyDeliveryAddress(DeliveryAddressModifyRequest request);        
    }
}
