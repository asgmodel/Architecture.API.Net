using APILAHJA.Models;
using Microsoft.EntityFrameworkCore;

namespace APILAHJA.Data
{
  public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
