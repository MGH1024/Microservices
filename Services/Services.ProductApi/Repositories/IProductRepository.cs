using Services.ProductApi.Models;
using Services.ProductApi.Models.DTOs;

namespace Services.ProductApi.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<ProductDto> GetProductById(int productId);
    Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
    Task<bool> DeleteProduct(int productId);
}