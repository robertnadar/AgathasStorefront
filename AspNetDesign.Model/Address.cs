using AspNetDesign.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Model
{
    public class Address : EntityBase<int>
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        protected override void Validate()
        {
            if (String.IsNullOrEmpty(AddressLine1))
                base.AddBrokenRules(AddressBusinessRules.AddressLine1Required);
            if (String.IsNullOrEmpty(City))
                base.AddBrokenRules(AddressBusinessRules.CityRequired);
            if (String.IsNullOrEmpty(State))
                base.AddBrokenRules(AddressBusinessRules.StateRequired);
            if (String.IsNullOrEmpty(Country))
                base.AddBrokenRules(AddressBusinessRules.CountryRequired);
            if (String.IsNullOrEmpty(ZipCode))
                base.AddBrokenRules(AddressBusinessRules.ZipCodeRequired);
        }
    }
}
