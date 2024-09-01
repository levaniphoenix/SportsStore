using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(ProductModel model)
        {
            await productRepository.AddAsync(mapper.Map<Product>(model));
        }

        public async Task DeleteAsync(int modelId)
        {
            await productRepository.DeleteByIdAsync(modelId);
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var products = await productRepository.GetAllAsync();
            return mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public async Task<ProductModel> GetByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            return mapper.Map<ProductModel>(product);
        }

        public Task UpdateAsync(ProductModel model)
        {
            productRepository.Update(mapper.Map<Product>(model));
            return Task.CompletedTask;
        }

        public IEnumerable<string> getAllCategories()
        {
            return productRepository.Products.Select(x =>x.Category).Distinct().OrderBy(x => x);
        }
    }
}
