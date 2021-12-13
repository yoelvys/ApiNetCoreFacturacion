using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly FacturacionDBContext _context;

        public InvoiceRepository(FacturacionDBContext context)
        {
            _context = context;
        }

        public async Task<Invoice> CreateAsync(Invoice invoice)
        {
            await _context.Set<Invoice>().AddAsync(invoice);
            await _context.SaveChangesAsync();

            return invoice;
        }

        public async Task<ICollection<Invoice>> GetAll()
        {
            return await _context.Set<Invoice>()
                .Include(i => i.Client)
                .Include(i => i.Details)
                .ToListAsync();
        }

        public async Task<Invoice> FindByNumberAsync(string number)
        {
            return await _context.Set<Invoice>()
                .Include(i => i.Client)
                .Include(i => i.Details)
                .Where(i => i.Number == number).SingleOrDefaultAsync();
        }
    }
}
