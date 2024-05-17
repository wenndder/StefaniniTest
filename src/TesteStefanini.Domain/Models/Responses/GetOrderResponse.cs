using System.Collections.Generic;

namespace TesteStefanini.Domain.Models.Requests
{
    public class GetOrderResponse
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public bool IsPaid { get; set; }
        public  double TotalAmount { get; set; }
        public List<ListItems> Items { get; set; }   

    }

    public class ListItems
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
