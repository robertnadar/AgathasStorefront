using AspNetDesign.Controller.JSONDTOs;
using AspNetDesign.Controller.ViewModels;
using AspNetDesign.Controller.ViewModels.ProductCatalog;
using AspNetDesign.Infrastructure.CookieStorage;
using AspNetDesign.Services.Implementations;
using AspNetDesign.Services.Interfaces;
using AspNetDesign.Services.Messaging.ProductCatalogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetDesign.Controller.Controllers
{
    public class BasketController : ProductCatalogBaseController
    {
        private readonly IBasketService _basketService;
        private readonly ICookieStorageService _cookieStorageService;

        public BasketController(IProductCatalogService productCatalogService, IBasketService basketService, ICookieStorageService cookieStorageService)
            : base(cookieStorageService, productCatalogService)
        {
            _basketService = basketService;
            _cookieStorageService = cookieStorageService;
        }

        public ActionResult Detail()
        {
            BasketDetailView basketView = new BasketDetailView();
            Guid basketId = base.GetBasketId();

            GetBasketRequest basketRequest = new GetBasketRequest()
            {
                BasketId = basketId
            };

            GetBasketResponse basketResponse = _basketService.GetBasket(basketRequest);
            GetAllDispatchOptionsResponse dispatchOptionsResponse = _basketService.GetAllDispatchOptions();
            basketView.Basket = basketResponse.Basket;
            basketView.Categories = base.GetCategories();
            basketView.BasketSummary = base.GetBasketSummaryView();
            basketView.DeliveryOptions = dispatchOptionsResponse.DeliveryOptions;

            return View("View", basketView);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult RemoveItem(int productId)
        {
            ModifyBasketRequest request = new ModifyBasketRequest();
            request.ItemsToRemove.Add(productId);

            request.BasketId = base.GetBasketId();
            ModifyBasketResponse response = _basketService.ModifyBasket(request);

            SaveBasketSummaryToCookie(response.Basket.NumberOfItems, response.Basket.BasketTotal);

            BasketDetailView basketDetailView = new BasketDetailView();
            basketDetailView.BasketSummary = new BasketSummaryView()
            {
                BasketTotal = response.Basket.BasketTotal,
                NumberOfItems = response.Basket.NumberOfItems
            };

            basketDetailView.Basket = response.Basket;
            basketDetailView.DeliveryOptions = _basketService.GetAllDispatchOptions().DeliveryOptions;

            return Json(basketDetailView);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UpdateShipping(int shippingServiceId)
        {
            ModifyBasketRequest request = new ModifyBasketRequest();
            request.SetShippingServiceIdTo = shippingServiceId;
            request.BasketId = base.GetBasketId();

            BasketDetailView basketDetailView = new BasketDetailView();

            ModifyBasketResponse response = _basketService.ModifyBasket(request);
            SaveBasketSummaryToCookie(response.Basket.NumberOfItems, response.Basket.BasketTotal);

            basketDetailView.BasketSummary = new BasketSummaryView
            {
                BasketTotal = response.Basket.BasketTotal,
                NumberOfItems = response.Basket.NumberOfItems
            };

            basketDetailView.Basket = response.Basket;
            basketDetailView.DeliveryOptions = _basketService.GetAllDispatchOptions().DeliveryOptions;

            return Json(basketDetailView);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UpdateItems(JsonBasketQtyUpdateRequest jsonBasketQtyUpdateRequest)
        {
            ModifyBasketRequest request = new ModifyBasketRequest();
            request.BasketId = base.GetBasketId();
            request.ItemsToUpdate = jsonBasketQtyUpdateRequest.ConvertToBasketItemsUpdateRequests();

            BasketDetailView basketDetailView = new BasketDetailView();
            ModifyBasketResponse response = _basketService.ModifyBasket(request);
            SaveBasketSummaryToCookie(response.Basket.NumberOfItems, response.Basket.BasketTotal);

            basketDetailView.BasketSummary = new BasketSummaryView
            {
                BasketTotal = response.Basket.BasketTotal,
                NumberOfItems = response.Basket.NumberOfItems
            };
            basketDetailView.Basket = response.Basket;
            basketDetailView.DeliveryOptions = _basketService.GetAllDispatchOptions().DeliveryOptions;
            return Json(basketDetailView);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AddToBasket(int productId)
        {
            BasketSummaryView basketSummary = new BasketSummaryView();
            Guid basketId = base.GetBasketId();
            bool createNewBasket = basketId == Guid.Empty;

            if (!createNewBasket)
            {
                ModifyBasketRequest modifyBasketRequest = new ModifyBasketRequest();
                modifyBasketRequest.ProductsToAdd.Add(productId);
                modifyBasketRequest.BasketId = basketId;

                try
                {
                    ModifyBasketResponse response = _basketService.ModifyBasket(modifyBasketRequest);
                    basketSummary = response.Basket.ConvertToSummary();
                    SaveBasketSummaryToCookie(basketSummary.NumberOfItems, basketSummary.BasketTotal);
                }
                catch (BasketDoesNotExistException ex)
                {
                    createNewBasket = true;
                }
            }
            if (createNewBasket)
            {
                CreateBasketRequest createBasketRequest = new CreateBasketRequest();
                createBasketRequest.ProductsToAdd.Add(productId);

                CreateBasketResponse response = _basketService.CreateBasket(createBasketRequest);
                SaveBasketIdToCookie(response.Basket.Id);
                basketSummary = response.Basket.ConvertToSummary();
                SaveBasketSummaryToCookie(basketSummary.NumberOfItems, basketSummary.BasketTotal);
            }
            return Json(basketSummary);
        }

        private void SaveBasketIdToCookie(Guid basketId)
        {
            _cookieStorageService.Save(CookieDataKeys.BasketId.ToString(), basketId.ToString(), DateTime.Now.AddDays(1));
        }

        private void SaveBasketSummaryToCookie(int numberOfItems, string basketTotal)
        {
            _cookieStorageService.Save(CookieDataKeys.BasketItems.ToString(), numberOfItems.ToString(), DateTime.Now.AddDays(1));
            _cookieStorageService.Save(CookieDataKeys.BasketTotal.ToString(), basketTotal.ToString(), DateTime.Now.AddDays(1));
        }
    }
}
