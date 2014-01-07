using AspNetDesign.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Controller.ViewModels.CustomerAccount
{
    public class CustomerDeliveryAddressView : BaseCustomerAccountView
    {
        public CustomerView CustomerView { get; set; }
        public DeliveryAddressView Address { get; set; }
    }
}
