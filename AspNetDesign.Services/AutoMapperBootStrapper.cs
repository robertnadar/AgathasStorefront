using AspNetDesign.Model;
using AspNetDesign.Model.Basket;
using AspNetDesign.Model.Categories;
using AspNetDesign.Model.Customers;
using AspNetDesign.Model.Orders;
using AspNetDesign.Model.Orders.States;
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

            // Customer
            Mapper.CreateMap<Customer, CustomerView>();
            Mapper.CreateMap<DeliveryAddress, DeliveryAddressView>();

            // Orders
            Mapper.CreateMap<Order, OrderView>();
            Mapper.CreateMap<OrderItem, OrderItemView>();
            Mapper.CreateMap<Address, DeliveryAddressView>();
            Mapper.CreateMap<Order, OrderSummaryView>().ForMember(o => o.IsSubmitted, ov => ov.ResolveUsing<OrderStatusResolver>());

            //IProductAttribute
            Mapper.CreateMap<IProductAttribute, Refinement>();

            //Global Money Formatter
            Mapper.AddFormatter<MoneyFormatter>();
        }
    }

    public class OrderStatusResolver : ValueResolver<Order, bool>
    {
        protected override bool ResolveCore(Order source)
        {
            if (source.Status == OrderStatus.Submitted)
            {
                return true;
            }
            else
            {
                return false;
            }
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
