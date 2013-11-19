using Agathas.Storefront.Infrastructure.Quering;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Services.Implementations
{
    public class ProductSearchRequestQueryGenerator
    {
        public static Query CreateQueryFor(GetProductsByCategoryRequest request)
        {
            Query productQuery = new Query();
            Query colorQuery = new Query();
            Query brandQuery = new Query();
            Query sizeQuery = new Query();
            colorQuery.QueryOperator = QueryOperator.Or;
            foreach (var id in request.ColorIds)
            {
                colorQuery.Add(Criterion.Create<Product>(p => p.Color.Id, id, CriteriaOperator.Equal));
            }
            if (colorQuery.Criteria.Count() > 0)
            {
                productQuery.AddSubQuery(colorQuery);
            }

            brandQuery.QueryOperator = QueryOperator.Or;
            foreach (var id in request.BrandIds)
            {
                brandQuery.Add(Criterion.Create<Product>(p => p.Brand.Id,id, CriteriaOperator.Equal));
            }

            if (brandQuery.Criteria.Count() > 0)
            {
                productQuery.AddSubQuery(brandQuery);
            }

            sizeQuery.QueryOperator = QueryOperator.Or;
            foreach (var id in request.SizeIds)
            {
                sizeQuery.Add(Criterion.Create<Product>(t => t.Size.Id, id, CriteriaOperator.Equal));
            }
            if (sizeQuery.Criteria.Count() > 0)
            {
                productQuery.AddSubQuery(sizeQuery);
            }

            productQuery.Add(Criterion.Create<Product>(t => t.Category.Id, request.CategoryId, CriteriaOperator.Equal));
            return productQuery;
        }
    }
}
