using AspNetDesign.Services.ViewModels;

namespace AspNetDesignController.ViewModels.ProductCatalog
{
    public class ProductDetailView : BaseProductCatalogPageView 
    {
        public ProductView Product { get; set; }
    }
}
