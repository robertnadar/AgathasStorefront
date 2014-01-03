using AspNetDesign.Controller.Controllers;
using AspNetDesign.Controller.JSONDTOs;
using AspNetDesign.Controller.ViewModels.ProductCatalog;
using AspNetDesign.Infrastructure.Configuration;
using AspNetDesign.Infrastructure.CookieStorage;
using AspNetDesign.Services.Interfaces;
using AspNetDesign.Services.Messaging.ProductCatalogService;
using AspNetDesign.Services.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AspNet.DesignController.Controllers
{
    public class ProductController : ProductCatalogBaseController
    {
        private readonly IProductCatalogService _productService;
        public ProductController(IProductCatalogService productService, ICookieStorageService cookieStorageService) : base(cookieStorageService, productService)
        {
            _productService = productService;
        }

        public ActionResult GetProductsByCategory(int categoryId)
        {
            GetProductsByCategoryRequest productSearchRequest = GenerateInitialProductSearchRequestFrom(categoryId);
            GetProductsByCategoryResponse response = _productService.GetProductsByCategory(productSearchRequest);
            ProductSearchResultView productSearchResultView = GetProductSearchResultViewFrom(response);
            return View("ProductSearchResults", productSearchResultView);
        }

        private ProductSearchResultView GetProductSearchResultViewFrom(GetProductsByCategoryResponse response)
        {
            ProductSearchResultView productSearchResultView = new ProductSearchResultView();
            productSearchResultView.BasketSummary = base.GetBasketSummaryView();
            productSearchResultView.Categories = base.GetCategories();
            productSearchResultView.CurrentPage = response.CurrentPage;
            productSearchResultView.NoOfTitlesFound = response.NoOfTitlesFound;
            productSearchResultView.Products = response.Products;
            productSearchResultView.RefinementGroups = response.RefinementGroups; 
            productSearchResultView.SelectedCategory = response.SelectedCategory;
            productSearchResultView.SelectedCategoryName = response.SelectedCategoryName;
            productSearchResultView.TotalNoOfPages = response.TotalNumberOfPages;
            return productSearchResultView;
        }

        private static GetProductsByCategoryRequest GenerateInitialProductSearchRequestFrom(int categoryId)
        {
            GetProductsByCategoryRequest productSearchRequest = new GetProductsByCategoryRequest();
            productSearchRequest.NoOfResultsPerPage = int.Parse(ApplicationSettingsFactory.GetApplicationSettings().NoOfResultsPerPage);
            productSearchRequest.CategoryId = categoryId;
            productSearchRequest.Index = 1;
            productSearchRequest.SortBy = ProductsSortBy.PriceHighToLow;
            return productSearchRequest;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetProductsByAjax(JsonProductSearchRequest request)
        {
            GetProductsByCategoryRequest productSearchRequest = GenerateProductSearchRequestFrom(request);
            GetProductsByCategoryResponse response = _productService.GetProductsByCategory(productSearchRequest);

            ProductSearchResultView productSearchResultView = GetProductSearchResultViewFrom(response);
            return Json(productSearchResultView);
        }

        private static GetProductsByCategoryRequest GenerateProductSearchRequestFrom(JsonProductSearchRequest request)
        {
            GetProductsByCategoryRequest productSearchRequest = new GetProductsByCategoryRequest();
            productSearchRequest.NoOfResultsPerPage = int.Parse(ApplicationSettingsFactory.GetApplicationSettings().NoOfResultsPerPage);
            productSearchRequest.Index = request.Index;
            productSearchRequest.CategoryId = request.CategoryId;
            productSearchRequest.SortBy = request.SortBy;

            List<RefinementGroup> refinementGroups = new List<RefinementGroup>();
            foreach (var jsonRefinementGroup in request.RefinementGroups)
            {
                switch ((RefinementGroupings)jsonRefinementGroup.GroupId)
                {
                    case RefinementGroupings.brand:
                        productSearchRequest.BrandIds = jsonRefinementGroup.SelectedRefinements;
                        break;
                    case RefinementGroupings.color:
                        productSearchRequest.ColorIds = jsonRefinementGroup.SelectedRefinements;
                        break;
                    case  RefinementGroupings.size:
                        productSearchRequest.SizeIds = jsonRefinementGroup.SelectedRefinements;
                        break;
                    default:
                        break;
                }
            }
            return productSearchRequest;
        }

        public ActionResult Detail(int id)
        {
            ProductDetailView productDetailView = new ProductDetailView();
            GetProductRequest request = new GetProductRequest() { ProductId = id };
            GetProductResponse response = _productService.GetProduct(request);

            ProductView productView = response.Product;
            productDetailView.Product = productView;
            productDetailView.Categories = base.GetCategories();
            productDetailView.BasketSummary = base.GetBasketSummaryView();
            return View(productDetailView);
        }
    }
}
