using AspNetDesign.Infrastructure.Domain;
using AspNetDesign.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Repository.NHibernat.Repositories
{
    public class ProductTitleRepository: Repository<ProductTitle, int>, IAggregateRoot
    {
        public ProductTitleRepository(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
