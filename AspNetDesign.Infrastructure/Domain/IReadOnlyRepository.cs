using AspNetDesign.Infrastructure.Quering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Infrastructure.Domain
{
    public interface IReadOnlyRepository<T, TId>  where T : IAggregateRoot
    {
        IEnumerable<T> FindAll();
        T FindBy(TId id);
        IEnumerable<T> FindBy(Query query);
        IEnumerable<T> FindBy(Query query, int index, int count);
    }
}
