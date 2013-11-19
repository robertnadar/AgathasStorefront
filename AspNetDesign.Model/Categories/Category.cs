using AspNetDesign.Infrastructure.Domain;
using AspNetDesign.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Model.Categories
{
    public class Category : EntityBase<int>, IAggregateRoot, IProductAttribute
    {
        public string Name { get; set; }
     
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
