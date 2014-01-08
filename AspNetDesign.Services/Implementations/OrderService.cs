using AspNetDesign.Infrastructure.Domain;
using AspNetDesign.Infrastructure.Logging;
using AspNetDesign.Model.Basket;
using AspNetDesign.Model.Customers;
using AspNetDesign.Model.Orders;
using AspNetDesign.Services.Messaging.OrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetDesign.Services.Mapping;
using AspNetDesign.Services.Interfaces;

namespace AspNetDesign.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _uow;

        public OrderService(IOrderRepository orderRepository, IBasketRepository basketRepository, ICustomerRepository customerRepository, IUnitOfWork uow)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _uow = uow;
        }

        public CreateOrderResponse CreateOrder(CreateOrderRequest request)
        {
            CreateOrderResponse response = new CreateOrderResponse();
            Customer customer = _customerRepository.FindBy(request.CustomerIdentityToken);
            Basket basket = _basketRepository.FindBy(request.BasketId);
            DeliveryAddress deliveryAddress = customer.DeliveryAddressBook.Where(d => d.Id == request.DeliveryId).FirstOrDefault();

            Order order = basket.ConvertToOrder();
            order.Customer = customer;
            order.DeliveryAddress = deliveryAddress;
            _orderRepository.Save(order);
            _basketRepository.Remove(basket);
            _uow.Commit();
            response.Order = order.ConvertToOrderView();
            return response;
        }
        public SetOrderPaymentResponse SetOrderPayment(
        SetOrderPaymentRequest paymentRequest)
        {
            SetOrderPaymentResponse paymentResponse = new SetOrderPaymentResponse();
            Order order = _orderRepository.FindBy(paymentRequest.OrderId);
            try
            {
                order.SetPayment(
                PaymentFactory.CreatePayment(paymentRequest.PaymentToken,
                paymentRequest.Amount,
                paymentRequest.PaymentMerchant));
                _orderRepository.Save(order);
                _uow.Commit();
            }
            catch (OrderAlreadyPaidForException ex)
            {
                // Out of scope of case study:
                // Refund the payment using the payment service.
                LoggingFactory.GetLogger().Log(ex.Message);
            }
            catch (PaymentAmountDoesNotEqualOrderTotalException ex)
            {
                // Out of scope of case study:
                // Refund the payment using the payment service.
                LoggingFactory.GetLogger().Log(ex.Message);
            }
            paymentResponse.Order = order.ConvertToOrderView();
            return paymentResponse;
        }
        public GetOrderResponse GetOrder(GetOrderRequest request)
        {
            GetOrderResponse response = new GetOrderResponse();
            Order order = _orderRepository.FindBy(request.OrderId);
            response.Order = order.ConvertToOrderView();
            return response;
        }
    }

}
