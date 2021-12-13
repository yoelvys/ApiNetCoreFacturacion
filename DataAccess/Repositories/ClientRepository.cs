using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly FacturacionDBContext _context;

        public ClientRepository(FacturacionDBContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Client>> GetAllAsync()
        {
            return await _context.Set<Client>().ToListAsync();
        }

        public async Task<Client> FindByDNI(string dni)
        {
            return await _context.Set<Client>().Where(c => c.DNI == dni).SingleOrDefaultAsync();
        }
    }
}
