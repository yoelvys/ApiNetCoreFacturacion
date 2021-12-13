using Dto.Request;
using Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IInvoiceService
    {
        Task<InvoiceResponseDto> CreateAsync(InvoiceRequestDto invoiceRequestDto);

        Task<ICollection<InvoiceResponseDto>> GetAll();

        Task<InvoiceResponseDto> FindByNumberAsync(string number);
    }
}