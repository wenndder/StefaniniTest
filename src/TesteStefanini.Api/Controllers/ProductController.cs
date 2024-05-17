using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteStefanini.Application.Interfaces;
using TesteStefanini.Domain.Models;
using TesteStefanini.Domain.Models.Requests;
using Swashbuckle.AspNetCore.Annotations;


namespace TesteStefanini.Api.Controllers
{

    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductApplication _productApplication;

        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        /// <summary>
        /// Create an Product 
        /// </summary>
        /// <param name="createProductRequest">Infos from the product.</param>
        /// <returns>The object created</returns>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Product created", typeof(Product))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server fails to process request")]
        public IActionResult CreateProduct([FromBody] CreateProductRequest createProductRequest)
        {
            var response = _productApplication.CreateProduct(createProductRequest);

            return Ok(response);
        }

        /// <summary>
        /// Get an product 
        /// </summary>
        /// <param name="getProductRequest">Infos from the product.</param>
        /// <returns>The object created</returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Product founded", typeof(Product))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server fails to process request")]
        public IActionResult GetProduct([FromQuery] GetProductRequest getProductRequest)
        {
            var response = _productApplication.GetProduct(getProductRequest);

            return Ok(response);
        }

        /// <summary>
        /// Update an product 
        /// </summary>
        /// <param name="updateProductRequest">Infos from the product.</param>
        /// <returns>The object created</returns>
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, "Product updated", typeof(Product))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server fails to process request")]
        public IActionResult UpdateProduct([FromBody] UpdateProductRequest updateProductRequest)
        {
            _productApplication.UpdateProduct(updateProductRequest);
            return Ok();
        }

        /// <summary>
        /// Delete an product 
        /// </summary>
        /// <param name="deleteProductRequest">Product Id.</param>
        [HttpDelete]
        [SwaggerResponse(StatusCodes.Status200OK, "Product deleted", typeof(Product))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server fails to process request")]
        public IActionResult DeleteProduct([FromQuery] DeleteProductRequest deleteProductRequest)
        {
            _productApplication.DeleteProduct(deleteProductRequest);
            return Ok();
        }
    }
}
