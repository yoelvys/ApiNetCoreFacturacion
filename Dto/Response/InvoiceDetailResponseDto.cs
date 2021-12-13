using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Response
{
    public class InvoiceDetailResponseDto
    {
        
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string SubProductName { get; set; }

        public int Amount { get; set; }
 
        public double UnitPrice { get; set; }

        public double SubTotal { get; set; }
    }
}
