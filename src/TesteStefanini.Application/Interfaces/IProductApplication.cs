using TesteStefanini.Domain.Models;
using TesteStefanini.Domain.Models.Requests;

namespace TesteStefanini.Application.Interfaces
{
    public interface IProductApplication
    {
        Product CreateProduct(CreateProductRequest createProductRequest);
        Product GetProduct(GetProductRequest getProductRequest);
        void UpdateProduct(UpdateProductRequest updateProductRequest);
        void DeleteProduct(DeleteProductRequest deleteProductRequest);
    }
}
