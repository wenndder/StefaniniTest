using System.Collections.Generic;

namespace TesteStefanini.Domain.Models.Requests
{
    public class UpdateOrderRequest
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<OrderItem> Items { get; set; }
        public bool IsPaid { get; set; }
    }
}
