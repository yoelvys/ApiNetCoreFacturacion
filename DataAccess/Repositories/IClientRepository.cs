using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IClientRepository
    {
        Task<Client> FindByDNI(string dni);
        Task<ICollection<Client>> GetAllAsync();
    }
}