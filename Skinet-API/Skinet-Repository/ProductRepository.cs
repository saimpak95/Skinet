using Microsoft.EntityFrameworkCore;
using Skinet_DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skinet_Repository
{
    public interface IProductRepository
    {
        Task<Product> GetProductsByIDAsync(int ID);

        Task<IReadOnlyList<Product>> GetProductsAsync();
    }

    public class ProductRepository : IProductRepository
    {
        private readonly DataContext db;

        public ProductRepository(DataContext db)
        {
            this.db = db;
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await db.Products.Include(b=>b.ProductBrand).Include(t=>t.ProductType).ToListAsync();
        }

        public async Task<Product> GetProductsByIDAsync(int ID)
        {
            return await db.Products.Include(b => b.ProductBrand).Include(t => t.ProductType).FirstOrDefaultAsync(p=>p.Id==ID);
        }
    }
}