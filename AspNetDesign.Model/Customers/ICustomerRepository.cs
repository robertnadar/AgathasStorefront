using AspNetDesign.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Model.Customers
{
    public interface ICustomerRepository : IRepository<Customer,int>
    {
        Customer FindBy(string identityToken);
    }
}
