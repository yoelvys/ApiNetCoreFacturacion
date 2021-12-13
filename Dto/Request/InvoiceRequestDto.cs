using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Request
{
    public class InvoiceRequestDto
    {

        [Required]
        public String Number { get; set; }

        public DateTime InvoiceDate { get; set; }

        [Required]
        public ClientRequestDto ClientRequest { get; set; }

        public ICollection<InvoiceDetailRequestDto> Details { get; set; } = new HashSet<InvoiceDetailRequestDto>();
    }
}
