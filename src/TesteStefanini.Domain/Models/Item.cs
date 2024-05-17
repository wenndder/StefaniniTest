using System;
using System.Text.Json.Serialization;

namespace TesteStefanini.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}