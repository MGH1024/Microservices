using Microsoft.EntityFrameworkCore;
using Services.ProductApi.Models;

namespace Services.ProductApi.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}