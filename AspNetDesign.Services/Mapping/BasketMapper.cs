using AspNetDesign.Model.Basket;
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
    }
}
