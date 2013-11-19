using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Repository.NHibernat.Repositories
{
    public class ProductTitleRepository: Repository<ProductTitle, int>, IAggregateRoot
    {
        public ProductTitleRepository(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
