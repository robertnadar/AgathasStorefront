using AspNetDesign.Infrastructure.Domain;
using AspNetDesign.Infrastructure.Quering;
using AspNetDesign.Model.Customers;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Repository.NHibernat.Repositories
{
    public class CustomerRepository : Repository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public Customer FindBy(string identityToken)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(Customer)).Add(Expression.Eq(PropertyNameHelper.ResolvePropertyName<Customer>(c => c.IdentityToken), identityToken));
            IList<Customer> customers = criteriaQuery.List<Customer>();

            Customer customer = customers.FirstOrDefault();
            return customer;
        }
    }
}
