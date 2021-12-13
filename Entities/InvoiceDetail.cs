using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class InvoiceDetail : BaseModel
    {
        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string SubProductName { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required]
        public double SubTotal { get; set; }
    }
}
