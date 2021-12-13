using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Response
{
    public class InvoiceResponseDto
    {
        public int Id { get; set; }

        public ClientResponseDto ClientResponseDto { get; set; }

        public ICollection<InvoiceDetailResponseDto> Details { get; set; } = new HashSet<InvoiceDetailResponseDto>();


        public String Number { get; set; }

        public DateTime InvoiceDate { get; set; }


        public double SubTotal { get; set; }


        public double IVA { get; set; }

        public double Total { get; set; }
    }
}
