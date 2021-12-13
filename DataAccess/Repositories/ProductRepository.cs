using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly FacturacionDBContext _context;

        public ProductRepository(FacturacionDBContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _context.Set<Product>().ToListAsync();
        }

        public async Task<ICollection<Product>> GetAllByProductNameAsync(string productName)
        {
            return await _context.Set<Product>()
                .Where(p => p.Name.ToLower().Equals(productName.ToLower()))
                .ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Set<Product>().Where(p => p.Id == id).SingleOrDefaultAsync();
        }

        public async Task<ICollection<string>> GetDistinctProductNameAsync()
        {
            return await _context.Set<Product>().Select(p => p.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Set<Product>().AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Set<Product>().Attach(product);
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
