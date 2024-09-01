using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repositories;
using Data;

namespace SportsStore.tests.DataTests
{
    public class OrderRepositoryTests
    {

        [Fact]
        public async Task ProductRepositoryAddAsyncAddsValueToDatabase()
        {
            using var context = new StoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderRepository = new OrderRepository(context);

            var order = new Order()
            {
                Name = "1",
                Line1 = "1",
                City = "Tbilisi",
                Country = "Georgia",
                OrderDetails = new List<OrderDetail>() { new OrderDetail() { ProductID = 1,Quantity = 1}, new OrderDetail() { ProductID = 2, Quantity = 1 } }
            };
            await orderRepository.AddAsync(order);

            await context.SaveChangesAsync();

            Assert.True(context.OrderDetails.Count() == 2);
            Assert.True(context.Orders.Count() == 1);
        }
    }
}
