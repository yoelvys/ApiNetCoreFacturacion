using DataAccess.Repositories;
using Dto.Request;
using Dto.Response;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<ProductResponseDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();

            return products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                SubProduct = p.SubProduct,
                UnitPrice = p.UnitPrice,

            }).ToList();
        }

        public async Task<ICollection<ProductResponseDto>> GetAllByProductNameAsync(string productName)
        {
            var products = await _repository.GetAllByProductNameAsync(productName);

            return products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                SubProduct = p.SubProduct,
                UnitPrice = p.UnitPrice,

            }).ToList();
        }

        public async Task<ICollection<string>> GetDistinctProductNameAsync()
        {
            return await _repository.GetDistinctProductNameAsync();
        }

        public async Task<ProductResponseDto> CreateAsync(ProductRequestDto product)
        {
            Product newProduct = await _repository.CreateAsync(new Product
            {
                Name = product.Name,
                SubProduct = product.SubProduct,
                UnitPrice = product.UnitPrice,

            });

            return new ProductResponseDto
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                SubProduct = newProduct.SubProduct,
                UnitPrice = newProduct.UnitPrice,
            };

        }

        public async Task<ProductResponseDto> UpdateAsync(int id, ProductRequestDto product)
        {
            Product newProduct = await _repository.UpdateAsync(new Product
            {
                Id = id,
                Name = product.Name,
                SubProduct = product.SubProduct,
                UnitPrice = product.UnitPrice,

            });

            return new ProductResponseDto
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                SubProduct = newProduct.SubProduct,
                UnitPrice = newProduct.UnitPrice,
            };
        }
    }
}
