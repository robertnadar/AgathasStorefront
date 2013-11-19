using AspNetDesign.Infrastructure.Domain;
using AspNetDesign.Model.Products;
using NHibernate;

namespace AspNetDesign.Repository.NHibernat.Repositories
{
    public class ProductRepository : Repository<Product, int>, IAggregateRoot
    {
        public ProductRepository(IUnitOfWork uow) : base(uow)
        {

        }

        public override void AppendCriteria(ICriteria criteria)
        {
            criteria.CreateAlias("Title", "ProductTitle");
            criteria.CreateAlias("ProductTitle.Category", "Category");
            criteria.CreateAlias("ProductTitle.Brand", "Brand");
            criteria.CreateAlias("ProductTitle.Color", "Color");
        }
    }
}
