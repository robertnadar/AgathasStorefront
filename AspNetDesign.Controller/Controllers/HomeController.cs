using AspNetDesign.Services.Interfaces;
using AspNetDesign.Services.Messaging.ProductCatalogService;
using AspNetDesign.Controller.ViewModels.ProductCatalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AspNetDesign.Infrastructure.CookieStorage;

namespace AspNetDesign.Controller.Controllers
{
    public class HomeController : ProductCatalogBaseController
    {
        private readonly IProductCatalogService _productCatalogService;
        public HomeController(IProductCatalogService productCatalogService, ICookieStorageService cookieStorageService) : base(cookieStorageService, productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }

        public ActionResult Index()
        {
            HomePageView homePageView = new HomePageView();
            homePageView.Categories = base.GetCategories();
            homePageView.BasketSummary = base.GetBasketSummaryView();

            GetFeaturedProductResponse response = _productCatalogService.GetFeaturedProducts();
            homePageView.Products = response.Products;
            return View(homePageView);

        }
    }
}
