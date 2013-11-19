using AspNetDesign.Services.ViewModels;

namespace AspNetDesign.Controller.ViewModels.ProductCatalog
{
    public class ProductDetailView : BaseProductCatalogPageView 
    {
        public ProductView Product { get; set; }
    }
}
