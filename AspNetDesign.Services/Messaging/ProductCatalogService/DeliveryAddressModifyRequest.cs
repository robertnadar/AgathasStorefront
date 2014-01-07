using AspNetDesign.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Services.Messaging.ProductCatalogService
{
    public class DeliveryAddressModifyRequest
    {
        public string CustomerIdentityToken { get; set; }
        public DeliveryAddressView Address { get; set; }
    }
}
