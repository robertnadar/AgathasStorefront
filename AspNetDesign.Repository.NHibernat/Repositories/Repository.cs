using AspNetDesign.Infrastructure.Domain;
using AspNetDesign.Infrastructure.Quering;
using NHibernate;
using System.Collections.Generic;

namespace AspNetDesign.Repository.NHibernat.Repositories
{
    public abstract class Repository<T, TEntityKey> where T: IAggregateRoot
    {
        private IUnitOfWork _uow;

        public Repository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(T entity)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void Save(T entity)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public T FindBy(TEntityKey Id)
        {
            return SessionFactory.GetCurrentSession().Get<T>(Id);
        }

        public IEnumerable<T> FindAll()
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            return criteriaQuery.List<T>();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            return criteriaQuery.SetFetchSize(count).SetFirstResult(index).List<T>();
        }

        public IEnumerable<T> FindBy(Query query)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            AppendCriteria(criteriaQuery);

            query.TranslateIntoNHQuery<T>(criteriaQuery);

            return criteriaQuery.List<T>();
        }

        public IEnumerable<T> FindBy(Query query, int index, int count)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            AppendCriteria(criteriaQuery);

            query.TranslateIntoNHQuery<T>(criteriaQuery);

            return criteriaQuery.SetFetchSize(count).SetFirstResult(index).List<T>();
        }

        public virtual void AppendCriteria(ICriteria criteria)
        {

        }
    }
}
