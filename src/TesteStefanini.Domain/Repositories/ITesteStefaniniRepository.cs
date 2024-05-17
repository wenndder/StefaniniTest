using TesteStefanini.Domain.Models;
using TesteStefanini.Domain.Models.Requests;
using System;
using System.Collections.Generic;

namespace TesteStefanini.Domain.Repositories
{
    public interface ITesteStefaniniRepository
    {
        Order CreateOrder(CreateOrderRequest createOrderRequest, DateTime now, bool isPaid = false);
        Order GetOrder(int Id);
        Product CreateProduct(CreateProductRequest createProductRequest);
        Product GetProduct(int Id);
        List<Item> GetItems(int id);
        void SaveChanges();      
        void DeleteOrder(int Id);
        void DeleteProduct(int Id);
        void UpdateOrder( UpdateOrderRequest updateOrderRequest);
        void UpdateProduct(UpdateProductRequest updateProductRequest);
    }
}
