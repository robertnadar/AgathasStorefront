using AspNetDesign.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Model.Basket
{
    public static class BasketItemFactory
    {
        public static BasketItem CreateItemFor(Basket basket, Product product)
        {
            return new BasketItem(1, product, basket);
        }
    }
}
