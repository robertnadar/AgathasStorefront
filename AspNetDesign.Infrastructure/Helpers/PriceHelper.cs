using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Infrastructure.Helpers
{
    public static class PriceHelper
    {
        public static string FormatMoney(this decimal price)
        {
            return String.Format("${0}", price);
        }
    }
}
