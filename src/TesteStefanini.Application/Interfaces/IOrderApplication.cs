using TesteStefanini.Domain.Models;
using TesteStefanini.Domain.Models.Requests;

namespace TesteStefanini.Application.Interfaces
{
    public interface IOrderApplication
    {
        Order CreateOrder(CreateOrderRequest createOrderRequest);
        GetOrderResponse GetOrder(GetOrderRequest getOrderRequest);

        void DeleteOrder(DeleteOrderRequest deleteOrderRequest);

        void UpdateOrder(UpdateOrderRequest updateOrderRequest);
    }
}
