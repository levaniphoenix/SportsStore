using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Resource;
using Data;
using Data.Entities;
using Data.Repositories;

namespace SportsStore.tests.DataTests
{
    public class ProductRepositoryTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task ProductRepositoryGetByIdAsyncReturnsSingleValue(int id)
        {
            using var context =  new StoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var prodcutRepository = new ProductRepository(context);

            var product = await prodcutRepository.GetByIdAsync(id);

            var expexted = ExpectedProducts.FirstOrDefault(x => x.ProductID == id);

            Assert.Equal(expexted, product, new ProductEqualityComparer());
        }

        [Fact]
        public async Task ProductRepositoryGetAllAsyncReturnsAllValues()
        {
            using var context = new StoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var prodcutRepository = new ProductRepository(context);

            var products = await prodcutRepository.GetAllAsync();

            Assert.Equal(products, ExpectedProducts, new ProductEqualityComparer());
        }

        [Fact]
        public async Task ProductRepositoryAddAsyncAddsValueToDatabase()
        {
            using var context = new StoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var prodcutRepository = new ProductRepository(context);

            var product = new Product { ProductID = 3 };

            await prodcutRepository.AddAsync(product);
            await context.SaveChangesAsync();

            Assert.True(context.Products.Count() == 3);
        }

        [Fact]
        public async Task ProductRepositoryDeleteByIdAsyncDeletesEntity()
        {
            using var context = new StoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var prodcutRepository = new ProductRepository(context);

            await prodcutRepository.DeleteByIdAsync(1);
            await context.SaveChangesAsync();

            Assert.True(context.Products.Count() == 1);
        }

        [Fact]
        public async Task ProductRepositoryUpdateUpdatesEntity()
        {
            using var context = new StoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var prodcutRepository = new ProductRepository(context);

            var product = new Product { ProductID = 1, Name = "company A Kayak",
                Description = "A boat for one person",
                Category = "Watersports",
                Price = 275
            };

            prodcutRepository.Update(product);
            await context.SaveChangesAsync();

            var updatedProduct = await prodcutRepository.GetByIdAsync(1);

            Assert.Equal(product, updatedProduct, new ProductEqualityComparer());
        }

        private static IEnumerable<Product> ExpectedProducts =>
            new[]
            {
                new Product
                {
                    ProductID = 1,
                    Name = "Kayak",
                    Description = "A boat for one person",
                    Category = "Watersports",
                    Price = 275
                },
                new Product
                {
                    ProductID = 2,
                    Name = "Lifejacket",
                    Description = "Protective and fashionable",
                    Category = "Watersports",
                    Price = 48.95m
                }
            };
    }
}
