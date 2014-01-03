using AspNetDesign.Infrastructure.Domain;
using AspNetDesign.Model.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Repository.NHibernat.Repositories
{
    public class DeliveryOptionRepository : Repository<DeliveryOption, int>, IDeliveryOptionRepository
    {
        public DeliveryOptionRepository(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
