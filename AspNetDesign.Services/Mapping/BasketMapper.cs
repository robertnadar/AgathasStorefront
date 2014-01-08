using AspNetDesign.Model.Basket;
using AspNetDesign.Model.Orders;
using AspNetDesign.Services.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Services.Mapping
{
    public static class BasketMapper
    {
        public static BasketView ConvertToBasketView(this Basket basket)
        {
            return Mapper.Map<Basket, BasketView>(basket);
        }

        public static Order ConvertToOrder(this Basket basket)
        {
            Order order = new Order();
            order.ShippingCharge = basket.DeliveryCost();
            order.ShippingService = basket.DeliveryOption.ShippingService;
            foreach (BasketItem item in basket.Items())
            {
                order.AddItem(item.Product, item.Qty);
            }
            return order;
        }
    }
}
