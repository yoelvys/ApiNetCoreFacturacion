using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Invoice : BaseModel
    {
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public ICollection<InvoiceDetail> Details { get; set; } = new HashSet<InvoiceDetail>();

        [Required]
        public String Number { get; set; }

        public DateTime InvoiceDate { get; set; }

        [Required]
        public double SubTotal { get; set; }

        [Required]
        public double IVA { get; set; }

        [Required]
        public double Total { get; set; }

    }
}
