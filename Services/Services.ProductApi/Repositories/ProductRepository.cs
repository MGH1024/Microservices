using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.ProductApi.DbContexts;
using Services.ProductApi.Models;
using Services.ProductApi.Models.DTOs;

namespace Services.ProductApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ProductRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        var productList = await _db.Products.ToListAsync();
        return _mapper.Map<List<ProductDto>>(productList);
    }

    public async Task<ProductDto> GetProductById(int productId)
    {
        var product = await _db
            .Products
            .Where(a => a.ProductId == productId)
            .FirstOrDefaultAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
    {
        var product = _mapper.Map<ProductDto, Product>(productDto);
        if (product.ProductId > 0)
        {
            _db.Products.Update(product);
        }
        else
        {
            await _db.Products.AddAsync(product);
        }

        await _db.SaveChangesAsync();
        return _mapper.Map<Product, ProductDto>(product);
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        var product = await _db
            .Products
            .Where(a => a.ProductId == productId)
            .FirstOrDefaultAsync();

        if (product is null)
            return false;
        _db.Products.Remove(product);
        await _db.SaveChangesAsync();
        return true;
    }
}