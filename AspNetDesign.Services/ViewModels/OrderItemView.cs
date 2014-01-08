using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Services.ViewModels
{
    public class OrderItemView
    {
        public string ProductName { get; set; }
        public string ProductSizeName { get; set; }
        public int Id { get; set; }
        public int Qty { get; set; }
        public string Price { get; set; }
    }
}
