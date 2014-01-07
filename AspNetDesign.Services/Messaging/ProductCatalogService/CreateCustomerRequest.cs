using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Services.Messaging.ProductCatalogService
{
    public class CreateCustomerRequest
    {
        public string CustomerIdentityToken { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
