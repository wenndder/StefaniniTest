using TesteStefanini.Application.Interfaces;
using TesteStefanini.Commons.ErrorHandler;
using TesteStefanini.Domain.Models;
using TesteStefanini.Domain.Models.Constants;
using TesteStefanini.Domain.Models.Requests;
using TesteStefanini.Domain.Repositories;
using System.Net;

namespace TesteStefanini.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly ITesteStefaniniRepository _testestefaniniRepository;

        public ProductApplication(ITesteStefaniniRepository testestefaniniRepository)
        {
            _testestefaniniRepository = testestefaniniRepository;
        }

        public Product CreateProduct(CreateProductRequest createProductRequest)
        {
            var product = _testestefaniniRepository.CreateProduct(createProductRequest);

            _testestefaniniRepository.SaveChanges();

            return product;
        }

        public Product GetProduct(GetProductRequest getProductRequest)
        {
            var product = _testestefaniniRepository.GetProduct(getProductRequest.Id);

            if (product == null)
            {
                throw new GenericException((int)HttpStatusCode.NotFound, Constants.PRODUCT_NOT_EXISTS);
            }

            return product;
        }

        public void UpdateProduct(UpdateProductRequest updateProductRequest)
        {
            var product = _testestefaniniRepository.GetProduct(updateProductRequest.Id);

            if (product != null)
            {
                _testestefaniniRepository.UpdateProduct(updateProductRequest);
            }

        }

        public void DeleteProduct(DeleteProductRequest deleteProductRequest)
        {
            _testestefaniniRepository.DeleteProduct(deleteProductRequest.Id);
        }
    }
}
