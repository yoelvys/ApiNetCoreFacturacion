using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAllAsync();

        Task<ICollection<string>> GetDistinctProductNameAsync();

        Task<ICollection<Product>> GetAllByProductNameAsync(string productName);

        Task<Product> CreateAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<Product> GetAsync(int id);


    }
}