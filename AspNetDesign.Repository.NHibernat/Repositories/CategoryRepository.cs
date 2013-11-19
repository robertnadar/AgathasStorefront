﻿using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Model.Categories;

namespace Agathas.Storefront.Repository.NHibernat.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork uow):base(uow)
        {

        }
    }
}
