using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Model.Orders
{
    public class CannotAmendOrderException : Exception
    {
        public CannotAmendOrderException(string message) : base(message)
        {

        }
    }
}
