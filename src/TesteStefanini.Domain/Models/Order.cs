using System;

namespace TesteStefanini.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPaid { get; set; }
    }
}