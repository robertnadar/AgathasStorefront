using AspNetDesign.Model.Products;
using AspNetDesign.Services.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Services.Mapping
{
    public static class ProductTitleMapper
    {
        public static IEnumerable<ProductSummaryView> ConvertToProductViews(this IEnumerable<ProductTitle> products)
        {
            return Mapper.Map<IEnumerable<ProductTitle>, IEnumerable<ProductSummaryView>>(products);
        }

        public static ProductView ConvertToProductDetailView(this ProductTitle title)
        {
            return Mapper.Map<ProductTitle, ProductView>(title);
        }
    }
}
