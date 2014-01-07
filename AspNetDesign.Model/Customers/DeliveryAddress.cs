using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Model.Customers
{
    public class DeliveryAddress : Address
    {
        public string Name { get; set; }
        public Customer Customer { get; set; }
        protected override void Validate()
        {
            base.Validate();
            if (String.IsNullOrEmpty(Name))
                base.AddBrokenRules(DeliveryAddressBusinessRules.NameRequired);
            if (Customer == null)
                base.AddBrokenRules(DeliveryAddressBusinessRules.CustomerRequired);
        }
    }
}
