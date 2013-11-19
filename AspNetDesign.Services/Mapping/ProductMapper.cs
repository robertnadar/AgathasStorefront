using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;
using Agathas.Storefront.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Services.Mapping
{
    public static class ProductMapper
    {
        public static GetProductsByCategoryResponse CreateProductSearchResultsFrom( this IEnumerable<Product> productsMatchingRefinement, GetProductsByCategoryRequest request)
        {
            GetProductsByCategoryResponse productSearchResultView = new GetProductsByCategoryResponse();
            IEnumerable<ProductTitle> productsFound = productsMatchingRefinement.Select(p => p.Title).Distinct();
            productSearchResultView.SelectedCategory = request.CategoryId;
            productSearchResultView.NoOfTitlesFound = productsFound.Count();
            productSearchResultView.TotalNumberOfPages = NoOfResultPagesGiven(request.NoOfResultsPerPage, productSearchResultView.NoOfTitlesFound);
            productSearchResultView.RefinementGroups = GenerateAvailableProductRefinementsFrom(productsFound);
            productSearchResultView.Products = CropProductListToSatisfyGivenIndex(request.Index, request.NoOfResultsPerPage, productsFound);
            return productSearchResultView;
        }

        private static IEnumerable<ProductSummaryView> CropProductListToSatisfyGivenIndex(int pageIndex, int noOfResultsPerPage, IEnumerable<ProductTitle> productsFound)
        {
            if (pageIndex > 1)
            {
                int numToSkip = (pageIndex - 1) * noOfResultsPerPage;
                return productsFound.Take(noOfResultsPerPage).ConvertToProductViews();
            }
            else
            {
                return productsFound.Skip(pageIndex).Take(noOfResultsPerPage).ConvertToProductViews();
            }
        }

        private static int NoOfResultPagesGiven(int noOfResultsPerPage, int noOfTitlesFound)
        {
            if (noOfTitlesFound < noOfResultsPerPage)
                return 1;
            else
            {
                return (noOfTitlesFound / noOfResultsPerPage) + (noOfTitlesFound % noOfResultsPerPage);
            }
        }

        private static IList<RefinementGroup> GenerateAvailableProductRefinementsFrom(IEnumerable<ProductTitle> productsFound)
        {
            var brandsRefinementGroup = productsFound.Select(p => p.Brand).Distinct().ToList().ConvertAll<IProductAttribute>(b => (IProductAttribute)b).ConvertToRefinementGroup(RefinementGroupings.brand);
            var colorsRefinementGroup = productsFound.Select(p =>p.Color).Distinct().ToList().ConvertAll<IProductAttribute>(b=>(IProductAttribute)b).ConvertToRefinementGroup(RefinementGroupings.color);
            var sizesRefinementGroup = (from p in productsFound
                                            from si in p.Products select si.Size).Distinct().ToList().ConvertAll<IProductAttribute>(b=>(IProductAttribute)b).ConvertToRefinementGroup(RefinementGroupings.size);

            IList<RefinementGroup> refinementGroup = new List<RefinementGroup>();
            refinementGroup.Add(brandsRefinementGroup);
            refinementGroup.Add(colorsRefinementGroup);
            refinementGroup.Add(colorsRefinementGroup);

            return refinementGroup;
        }
    }
}
