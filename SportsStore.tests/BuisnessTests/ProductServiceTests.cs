using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Business.Services;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using FluentAssertions;
using Moq;

namespace SportsStore.tests.BuisnessTests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task ProductServiceGetAllReturnsAllProducts()
        {
            var expected = GetTestProductModels;
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(GetTestProductEntities.AsEnumerable());

            var productService = new ProductService(mockProductRepository.Object,UnitTestHelper.CreateMapperProfile());

            var result = await productService.GetAllAsync();

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task ProductServiceGetByIdReturnsProductModel()
        {
            var expected = GetTestProductModels[0];

            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(GetTestProductEntities[0]);

            var productService = new ProductService(mockProductRepository.Object, UnitTestHelper.CreateMapperProfile());

            var actaul = await productService.GetByIdAsync(1);

            actaul.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task ProductServiceAddAsyncAddsModel()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(m => m.AddAsync(It.IsAny<Product>()));

            var productService = new ProductService(mockProductRepository.Object, UnitTestHelper.CreateMapperProfile());
            var product = GetTestProductModels[0];

            await productService.AddAsync(product);

            mockProductRepository.Verify(x => x.AddAsync(It.Is<Product>(x =>
                x.ProductID == product.ProductID && x.Name == product.Name && x.Price == product.Price)), Times.Once);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task ProductServiceDeleteAsyncDeletesProduct(int id)
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(m => m.DeleteByIdAsync(It.IsAny<int>()));
            var productService = new ProductService(mockProductRepository.Object, UnitTestHelper.CreateMapperProfile());

            await productService.DeleteAsync(id);

            mockProductRepository.Verify(x => x.DeleteByIdAsync(id), Times.Once);
        }

        private static List<ProductModel> GetTestProductModels => new List<ProductModel>()
        {
            new ProductModel{ ProductID = 1, Name = "Kayak", Description = "A boat for one person",Category = "Watersports",Price = 275},
            new ProductModel{ ProductID = 2,Name = "Lifejacket",Description = "Protective and fashionable",Category = "Watersports",Price = 48.95m}
        };

        private static List<Product> GetTestProductEntities => new List<Product>()
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
