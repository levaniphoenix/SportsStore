using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public IQueryable<Order> Orders => context.Orders;

        public readonly StoreDbContext context;

        public OrderRepository(StoreDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Order entity)
        {
            await context.OrderDetails.AddRangeAsync(entity.OrderDetails);
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
