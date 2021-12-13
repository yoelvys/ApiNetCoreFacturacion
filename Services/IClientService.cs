using Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IClientService
    {
        Task<ClientResponseDto> FindByDNI(string dni);
        Task<ICollection<ClientResponseDto>> GetAllAsync();
    }
}
