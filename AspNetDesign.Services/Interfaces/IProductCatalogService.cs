using AspNetDesign.Services.Messaging.ProductCatalogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Services.Interfaces
{
    public interface IProductCatalogService
    {
        GetFeaturedProductResponse GetFeaturedProducts();
        GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request);
        GetProductResponse GetProduct(GetProductRequest request);
        GetAllCategoriesResponse GetAllCategories();
    }
}
