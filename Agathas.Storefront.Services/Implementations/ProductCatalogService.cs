using Agathas.Storefront.Infrastructure.Quering;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agathas.Storefront.Services.Mapping;

namespace Agathas.Storefront.Services.Implementations
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IProductTitleRepository _productTitleRespository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductCatalogService(IProductTitleRepository productTitleRepository, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productTitleRespository = productTitleRepository;
        }

        private IEnumerable<Product> GetAllProductsMatchingQueryAndSort(GetProductsByCategoryRequest request, Query productQuery)
        {
            IEnumerable<Product> productsMatchingRefinement = _productRepository.FindBy(productQuery);
            switch (request.SortBy)
            {
                case ProductsSortBy.PriceHighToLow:
                    productsMatchingRefinement = productsMatchingRefinement.OrderByDescending(p => p.Price);
                    break;
                case ProductsSortBy.PriceLowToHigh:
                    productsMatchingRefinement = productsMatchingRefinement.OrderBy(p => p.Price);
                    break;
            }
            return productsMatchingRefinement;
        }

        public  GetFeaturedProductResponse GetFeaturedProducts()
        {
            GetFeaturedProductResponse response = new GetFeaturedProductResponse();
            Query productQuery = new Query();
            productQuery.OrderByProperty = new OrderByClause
            {
                Desc = true,
                PropertyName = PropertyNameHelper.ResolvePropertyName<ProductTitle>(pt => pt.Price)
            };
            response.Products = _productTitleRespository.FindBy(productQuery, 0, 6).ConvertToProductViews();
            return response;
        }

        public GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request)
        {
            GetProductsByCategoryResponse response;
            Query productQuery = ProductSearchRequestQueryGenerator.CreateQueryFor(request);
            IEnumerable<Product> productMatchingRefinemens = GetAllProductsMatchingQueryAndSort(request, productQuery);
            response = productMatchingRefinemens.CreateProductSearchResultsFrom(request);
            response.SelectedCategoryName = _categoryRepository.FindBy(request.CategoryId).Name;
            return response;
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
            GetProductResponse response = new GetProductResponse();
            ProductTitle productTitle = _productTitleRespository.FindBy(request.ProductId);
            response.Product = productTitle.ConvertToProductDetailView();
            return response;
        }

        public GetAllCategoriesResponse GetAllCategories()
        {
            GetAllCategoriesResponse response = new GetAllCategoriesResponse();
            IEnumerable<Category> categories = _categoryRepository.FindAll();
            response.Categories = categories.ConvertToCategoryViews();
            return response;
        }
    }
}
