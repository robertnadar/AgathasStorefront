using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AspNetDesign.Model.Customers
{
    public class EmailValidationSpecification
    {
        private static Regex _emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

        public bool IsSatisfiedBy(string email)
        {
            return _emailRegex.IsMatch(email);
        }
    }
}
