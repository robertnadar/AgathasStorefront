using AspNetDesign.Controller.ViewModels;
using AspNetDesign.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Controller
{
    public static class BasketMapper
    {
        public static BasketSummaryView ConvertToSummary(this BasketView basket)
        {
            return new BasketSummaryView
            {
                BasketTotal = basket.BasketTotal,
                NumberOfItems = basket.NumberOfItems
            };
        }
    }
}
