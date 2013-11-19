using Agathas.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.StorefrontController.ViewModels.ProductCatalog
{
    public class ProductSearchResultView : BaseProductCatalogPageView
    {
        public ProductSearchResultView()
        {
            RefinementGroups = new List<RefinementGroup>();
        }
        public IEnumerable<RefinementGroup> RefinementGroups { get; set; }
        public string SelectedCategoryName { get; set; }
        public int SelectedCategory { get; set; }
        public int NoOfTitlesFound { get; set; }
        public int TotalNoOfPages { get; set; }
        public int CurrentPage { get; set; }

        public IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
