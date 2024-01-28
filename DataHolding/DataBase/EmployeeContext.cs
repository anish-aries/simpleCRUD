using Microsoft.EntityFrameworkCore;
using DataHolding.Models.Main;
namespace DataHolding.DataBase
{
    public class EmployeeContext : DbContext // control + . for creating Constructor.........
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {
        }

        // set property of Model......


        public DbSet<EmployeeRecord> EmployeeRecords { get; set; }
        //public object Employees { get; internal set; }

        // table name is Employees..........
    }
}
