using AspNetDesign.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Model.Shipping
{
    public interface IDeliveryOptionRepository : IReadOnlyRepository<DeliveryOption,int>
    {
    }
}
