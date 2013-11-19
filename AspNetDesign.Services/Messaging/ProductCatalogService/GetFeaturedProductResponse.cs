using Agathas.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Services.Messaging.ProductCatalogService
{
    public class GetFeaturedProductResponse
    {
        public IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
