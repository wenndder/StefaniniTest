using TesteStefanini.Domain.Models;
using TesteStefanini.Domain.Models.Requests;
using TesteStefanini.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteStefanini.Data.Repositories
{
    public class TesteStefaniniRepository : ITesteStefaniniRepository
    {
        private readonly TesteStefaniniContext _context;

        public TesteStefaniniRepository(TesteStefaniniContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Order CreateOrder(CreateOrderRequest createOrderRequest, DateTime now, bool isPaid = false)
        {
            var order = new Order()
            {
                CreatedAt = now,
                CustomerEmail = createOrderRequest.CustomerEmail,
                CustomerName = createOrderRequest.CustomerName,
                IsPaid = isPaid
            };
            _context.Orders.Add(order);
            _context.SaveChanges();


            foreach (var item in createOrderRequest.Items) {
                _context.Items.Add(new Item()
                {
                    OrderId = _context.Orders.Where(order => order.CreatedAt.Equals(now)).FirstOrDefault().Id,
                    ProductId = _context.Products.Where(product => product.Id.Equals(item.ProductId)).FirstOrDefault().Id,
                    Quantity = item.Quantity,
                });
            }


            return order;
        }

        public Product CreateProduct(CreateProductRequest createProductRequest)
        {
            var product = new Product()
            {
                Name = createProductRequest.Name,
                Price = createProductRequest.Price,
            };
            _context.Products.Add(product);
            return product;
        }

        public Order GetOrder(int id)
        {
            return _context.Orders.Where(order => order.Id.Equals(id)).FirstOrDefault();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Where(product => product.Id.Equals(id)).FirstOrDefault();
        }

        public List<Item> GetItems(int id)
        {
            return _context.Items.Where(item => item.OrderId.Equals(id)).ToList();
        }

        public void UpdateOrder(UpdateOrderRequest updateOrderRequest)
        {
            var order = GetOrder(updateOrderRequest.Id);

            order.CustomerName = updateOrderRequest.CustomerName;
            order.CustomerEmail = updateOrderRequest.CustomerEmail;
            order.IsPaid = updateOrderRequest.IsPaid;

            foreach(var item in _context.Items.Where(item => item.OrderId.Equals(updateOrderRequest.Id)).ToList()){
                _context.Items.Remove(item);
            }

            _context.SaveChanges();

            foreach (var item in updateOrderRequest.Items)
            {
                _context.Items.Add(new Item()
                {
                    OrderId = _context.Orders.Where(order => order.Id.Equals(updateOrderRequest.Id)).FirstOrDefault().Id,
                    ProductId = _context.Products.Where(product => product.Id.Equals(item.ProductId)).FirstOrDefault().Id,
                    Quantity = item.Quantity,
                });
            }
            _context.SaveChanges();
        }

        public void UpdateProduct(UpdateProductRequest updateProductRequest)
        {
            var product = GetProduct(updateProductRequest.Id);

            product.Name = updateProductRequest.Name;
            product.Price = updateProductRequest.Price;

            _context.SaveChanges();
        }
        public void DeleteOrder(int id)
        {
            var order = GetOrder(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var product = GetProduct(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
