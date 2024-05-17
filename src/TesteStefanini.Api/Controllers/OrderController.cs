using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteStefanini.Application.Interfaces;
using TesteStefanini.Domain.Models;
using TesteStefanini.Domain.Models.Requests;
using Swashbuckle.AspNetCore.Annotations;

namespace TesteStefanini.Api.Controllers
{

    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly IOrderApplication _orderApplication;

        public OrderController(IOrderApplication orderApplication)
        {
            _orderApplication = orderApplication;
        }

        /// <summary>
        /// Create an order 
        /// </summary>
        /// <param name="createOrderRequest">Infos from the order.</param>
        /// <returns>The object created</returns>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Order created", typeof(Order))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server fails to process request")]
        public IActionResult CreateOrder([FromBody] CreateOrderRequest createOrderRequest)
        {
            var response = _orderApplication.CreateOrder(createOrderRequest);

            return Ok(response);
        }

        /// <summary>
        /// Get an order 
        /// </summary>
        /// <param name="getOrderRequest">Infos from the order.</param>
        /// <returns>The object created</returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Order founded", typeof(Order))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server fails to process request")]
        public IActionResult GetOrder([FromQuery] GetOrderRequest getOrderRequest)
        {
            var response = _orderApplication.GetOrder(getOrderRequest);

            return Ok(response);
        }

        /// <summary>
        /// Update an order 
        /// </summary>
        /// <param name="updateOrderRequest">Infos from the order.</param>
        /// <returns>The object created</returns>
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, "Order updated", typeof(Order))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server fails to process request")]
        public IActionResult UpdateOrder([FromBody] UpdateOrderRequest updateOrderRequest)
        {
            _orderApplication.UpdateOrder(updateOrderRequest);
            return Ok();
        }

        /// <summary>
        /// Delete an order 
        /// </summary>
        /// <param name="deleteOrderRequest">Order Id.</param>
        [HttpDelete]
        [SwaggerResponse(StatusCodes.Status200OK, "Order deleted", typeof(Order))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server fails to process request")]
        public IActionResult DeleteOrder([FromQuery] DeleteOrderRequest deleteOrderRequest)
        {
            _orderApplication.DeleteOrder(deleteOrderRequest);
            return Ok();
        }
    }
}
