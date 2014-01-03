using AspNetDesign.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Controller.ViewModels.ProductCatalog
{
    public class BasketDetailView :BaseProductCatalogPageView
    {
        public BasketView Basket { get; set; }
        public IEnumerable<DeliveryOptionView> DeliveryOptions { get; set; }
    }
}
