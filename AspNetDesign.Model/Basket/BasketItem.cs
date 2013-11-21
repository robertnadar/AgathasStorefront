using AspNetDesign.Infrastructure.Domain;
using AspNetDesign.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Model.Basket
{
    public class BasketItem : EntityBase<int>
    {
        private int _qty;
        private Product _product;
        private Basket _basket;

        public BasketItem()
        {

        }

        public BasketItem(int qty, Product product, Basket basket)
        {
            _qty = qty;
            _product = product;
            _basket = basket;
        }

        public decimal LineTotal()
        {
            return Product.Price * Qty;
        }

        public int Qty { get { return _qty;}}
        public Product Product {get {return _product;}}
        public Basket Basket {get {return _basket;}}

        public bool Contains(Product product)
        {
            return Product == product;
        }

        public void IncreaseItemQtyBy(int qty)
        {
            _qty += qty;
        }

        public void ChangeItemQtyTo(int qty)
        {
            _qty = qty;
        }

        protected override void Validate()
        {
            if (Qty < 0)
                base.AddBrokenRules(BasketItemBusinessRules.QtyInvalid);
            if (Product == null)
                base.AddBrokenRules(BasketItemBusinessRules.ProductRequired);
            if (Basket == null)
                base.AddBrokenRules(BasketItemBusinessRules.BasketRequired);
        }
    }
}
