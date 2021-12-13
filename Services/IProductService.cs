using Dto.Request;
using Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        Task<ICollection<ProductResponseDto>> GetAllAsync();

        Task<ICollection<string>> GetDistinctProductNameAsync();

        Task<ICollection<ProductResponseDto>> GetAllByProductNameAsync(string productName);

        Task<ProductResponseDto> CreateAsync(ProductRequestDto product);

        Task<ProductResponseDto> UpdateAsync(int id, ProductRequestDto product);
    }
}