using AspNetDesign.Services.Interfaces;
using AspNetDesign.Services.Messaging.ProductCatalogService;
using AspNetDesign.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetDesignController.Controllers
{
    public class ProductCatalogBaseController : Controller
    {
        private readonly IProductCatalogService _productCatalogService;
        public ProductCatalogBaseController(IProductCatalogService productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }

        public IEnumerable<CategoryView> GetCategories()
        {
            GetAllCategoriesResponse response = _productCatalogService.GetAllCategories();
            return response.Categories;
        }
    }
}
