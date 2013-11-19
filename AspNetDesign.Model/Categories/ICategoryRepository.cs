using Agathas.Storefront.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Model.Categories
{
    public interface ICategoryRepository : IReadOnlyRepository<Category, int>
    {
    }
}
