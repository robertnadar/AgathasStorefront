using AspNetDesign.Services.ViewModels;
using System.Collections.Generic;

namespace AspNetDesign.Services.Messaging.ProductCatalogService
{
    public class GetAllDispatchOptionsResponse
    {
        public IEnumerable<DeliveryOptionView> DeliveryOptions { get; set; }
    }
}
