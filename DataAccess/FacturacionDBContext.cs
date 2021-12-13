using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FacturacionDBContext : DbContext
    {
        public FacturacionDBContext()
        {

        }

        public FacturacionDBContext(DbContextOptions<FacturacionDBContext> options): base(options)
        {

        }

        public DbSet<Client> Client { get; set; }

        public DbSet<Invoice> Invoice { get; set; }

        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }

        public DbSet<Product> Product { get; set; }


    }
}
