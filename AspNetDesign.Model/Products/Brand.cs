using AspNetDesign.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Model.Products
{
    public class Brand : EntityBase<int>, IProductAttribute
    {
        public string Name { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
