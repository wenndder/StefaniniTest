using TesteStefanini.Application.Interfaces;
using TesteStefanini.Commons.ErrorHandler;
using TesteStefanini.Domain.Models;
using TesteStefanini.Domain.Models.Constants;
using TesteStefanini.Domain.Models.Requests;
using TesteStefanini.Domain.Repositories;
using System;
using System.Net;
using System.Collections.Generic;

namespace TesteStefanini.Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly ITesteStefaniniRepository _testestefaniniRepository;

        public OrderApplication(ITesteStefaniniRepository testestefaniniRepository)
        {
            _testestefaniniRepository = testestefaniniRepository;
        }

        public Order CreateOrder(CreateOrderRequest createOrderRequest)
        {
            var date = DateTime.Now;
            var paid = false;

            var order = _testestefaniniRepository.CreateOrder(createOrderRequest, date, paid);

            _testestefaniniRepository.SaveChanges();

            return order;
        }

        public GetOrderResponse GetOrder(GetOrderRequest getOrderRequest)
        {
            var order = _testestefaniniRepository.GetOrder(getOrderRequest.Id);

            if (order == null)
            {
                throw new GenericException((int)HttpStatusCode.NotFound, Constants.ORDER_NOT_EXISTS);
            }

            double totalAmount = 0;

            var items = _testestefaniniRepository.GetItems(order.Id);
            var listItems = new List<ListItems>();
            foreach (var item in items)
            {
                var product = _testestefaniniRepository.GetProduct(item.ProductId);

                if (product != null)
                {
                    listItems.Add(new ListItems()
                    {
                        Id = item.Id,
                        Price = product.Price,
                        ProductId = product.Id,
                        ProductName = product.Name,
                        Quantity = item.Quantity
                    });
                    totalAmount += product.Price * item.Quantity;
                }
            }

            return new GetOrderResponse()
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail,
                IsPaid = order.IsPaid,
                TotalAmount = totalAmount,
                Items = listItems
            };
        }

        public void UpdateOrder(UpdateOrderRequest updateOrderRequest)
        {
            var order = _testestefaniniRepository.GetOrder(updateOrderRequest.Id);

            if (order != null)
            {
                _testestefaniniRepository.UpdateOrder(updateOrderRequest);
            }
                
        }

        public void DeleteOrder(DeleteOrderRequest deleteOrderRequest)
        {
           _testestefaniniRepository.DeleteOrder(deleteOrderRequest.Id);
        }
    }
}
