using DataAccess.Repositories;
using Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClientResponseDto> FindByDNI(string dni)
        {
           var client = await _repository.FindByDNI(dni);
            if (client == null)
                return null;

           return new ClientResponseDto { 
                Id = client.Id,
                Name = client.Name,
                DNI = dni,
            };
        }

        public async Task<ICollection<ClientResponseDto>> GetAllAsync()
        {
            var clients = await _repository.GetAllAsync();

            return clients.Select(c => new ClientResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                DNI = c.DNI,
            }).ToList();
        }
    }
}
