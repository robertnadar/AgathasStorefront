using AspNetDesign.Model.Basket;
using AspNetDesign.Model.Categories;
using AspNetDesign.Model.Products;
using AspNetDesign.Model.Shipping;
using AspNetDesign.Services.ViewModels;
using AutoMapper;

namespace AspNetDesign.Services
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            //Product Title and Product
            Mapper.CreateMap<ProductTitle, ProductSummaryView>();
            Mapper.CreateMap<ProductTitle, ProductView>();
            Mapper.CreateMap<Product, ProductSummaryView>();
            Mapper.CreateMap<Product, ProductSizeOption>();

            //Category
            Mapper.CreateMap<Category, CategoryView>();

            //Basket
            Mapper.CreateMap<DeliveryOption, DeliveryOptionView>();
            Mapper.CreateMap<BasketItem, BasketItemView>();
            Mapper.CreateMap<Basket, BasketView>();

            //IProductAttribute
            Mapper.CreateMap<IProductAttribute, Refinement>();

            //Global Money Formatter
            Mapper.AddFormatter<MoneyFormatter>();
        }
    }

    public class MoneyFormatter : IValueFormatter
    {
        public string FormatValue(ResolutionContext context)
        {
            if (context.SourceValue is decimal)
            {
                decimal money = (decimal)context.SourceValue;
                return money.ToString();//.FormatMoney();
            }
            return context.SourceValue.ToString();
        }
    }

}
