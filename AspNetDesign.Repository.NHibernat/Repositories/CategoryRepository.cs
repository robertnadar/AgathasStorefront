using AspNetDesign.Infrastructure.Domain;
using AspNetDesign.Model.Categories;

namespace AspNetDesign.Repository.NHibernat.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork uow):base(uow)
        {

        }
    }
}
