using Microsoft.EntityFrameworkCore;
using PayrollBudget.API.Models;

namespace PayrollBudget.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Accession> Accessions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FiscalYearCycle> FiscalYearCycles{ get; set; }
        public DbSet<Office> Offices{ get; set; }
        public DbSet<PayPeriod> PayPeriods { get; set; }
        public DbSet<PayrollDetail> PayrollDetails { get; set; }
        public DbSet<Subtotal> Subtotals{ get; set; }
    }
}
