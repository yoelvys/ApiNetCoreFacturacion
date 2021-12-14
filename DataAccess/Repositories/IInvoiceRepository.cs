using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IInvoiceRepository
    {
        Task<Invoice> CreateAsync(Invoice invoice);

        Task<ICollection<Invoice>> GetAll();

        Task<ICollection<Invoice>> FindByNumberAsync(string number);

        Task<Invoice> GetAsync(int id);
    }
}