using AspNetDesign.Infrastructure.Domain;
using AspNetDesign.Model.Basket;
using System;

namespace AspNetDesign.Repository.NHibernat.Repositories
{
    public class BasketRepository : Repository<Basket, Guid>, IBasketRepository
    {
        public BasketRepository(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
