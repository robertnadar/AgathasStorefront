using AspNetDesign.Services.Messaging.ProductCatalogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Controller.JSONDTOs
{
    public static class JsonDtoMapper
    {
        public static IList<ProductQtyUpdateRequest> ConvertToBasketItemsUpdateRequests(this JsonBasketQtyUpdateRequest jsonBasketQtyUpdateRequest)
        {
            return jsonBasketQtyUpdateRequest.ConvertToBasketItemsUpdateRequests();
        }

        public static IList<ProductQtyUpdateRequest> ConvertToBasketItemsUpdateRequests(this JsonBasketItemUpdateRequest[] jsonBasketItemUpdateRequest)
        {
            int i = 0;
            IList<ProductQtyUpdateRequest> basketItemsUpdateRequests = new List<ProductQtyUpdateRequest>();
            for (i = 0; i < jsonBasketItemUpdateRequest.Length; i++)
            {
                basketItemsUpdateRequests.Add(jsonBasketItemUpdateRequest[i].ConvertToBasketItemUpdateRequest());
            }
            return basketItemsUpdateRequests;
        }

        public static ProductQtyUpdateRequest ConvertToBasketItemUpdateRequest(this JsonBasketItemUpdateRequest jsonBasketItemUpdateRequest)
        {
            return new ProductQtyUpdateRequest { 
                ProductId = jsonBasketItemUpdateRequest.ProductId,
                NewQty = jsonBasketItemUpdateRequest.Qty
            };
        }
    }
}
