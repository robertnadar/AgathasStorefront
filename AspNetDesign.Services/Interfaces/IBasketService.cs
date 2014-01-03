using AspNetDesign.Services.Messaging.ProductCatalogService;

namespace AspNetDesign.Services.Interfaces
{
    public interface IBasketService
    {
        GetBasketResponse GetBasket(GetBasketRequest basketRequest);
        CreateBasketResponse CreateBasket(CreateBasketRequest basketRequest);
        ModifyBasketResponse ModifyBasket(ModifyBasketRequest request);
        GetAllDispatchOptionsResponse GetAllDispatchOptions();
    }
}
