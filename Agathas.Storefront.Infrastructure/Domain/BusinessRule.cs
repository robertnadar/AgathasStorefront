using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Infrastructure.Domain
{
    public class BusinessRule
    {
        private string _property;
        private string _rule;

        public BusinessRule(string property, string rule)
        {
            _property = property;
            _rule = rule;
        }

        public string MyProperty
        {
            get
            {
                return _property;
            }
            set
            {
                value = _property;
            }
        }

        public string Rule
        {
            get {
                return _rule;
            }
            set {
                value = _rule;
            }
        }
    }
}
