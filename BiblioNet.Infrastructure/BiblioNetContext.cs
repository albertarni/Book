

using BiblioNet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BiblioNet.Infrastructure
{
    public class BiblioNetContext : DbContext
    {
        public BiblioNetContext(DbContextOptions<BiblioNetContext> options) : base(options)
        {
        }

        public DbSet<BookDAL> Books { get; set; }
        public DbSet<EmployeeDAL> Employees { get; set; }
    }
}
