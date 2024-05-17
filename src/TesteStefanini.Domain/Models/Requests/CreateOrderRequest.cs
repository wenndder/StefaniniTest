using System.Collections.Generic;

namespace TesteStefanini.Domain.Models.Requests
{
    public class CreateOrderRequest
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<OrderItem> Items { get; set; }

    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
