using AspNetDesign.Infrastructure.CookieStorage;
using AspNetDesign.Services.Interfaces;
using AspNetDesign.Services.Messaging.ProductCatalogService;
using AspNetDesign.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetDesign.Controller.Controllers
{
    public class ProductCatalogBaseController : BaseController
    {
        private readonly IProductCatalogService _productCatalogService;

        public ProductCatalogBaseController(ICookieStorageService cookieStorageService, IProductCatalogService productCatalogService) : base(cookieStorageService)
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
