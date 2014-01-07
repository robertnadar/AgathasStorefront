using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Infrastructure.Authentication
{
    public class User
    {
        public string AuthenticationToken { get; set; }
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
