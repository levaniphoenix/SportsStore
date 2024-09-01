using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly StoreDbContext context;

        public ProductRepository(StoreDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Product> Products => context.Products;

        public async Task AddAsync(Product entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public void Delete(Product entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            context.Remove(context.Products.Single(a => a.ProductID == id));
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await Products.Where(x => x.ProductID == id).SingleAsync();
            return product;
        }

        public void Update(Product entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
