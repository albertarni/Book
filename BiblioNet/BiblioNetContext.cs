using BiblioNet.Models;
using Microsoft.EntityFrameworkCore;

namespace BiblioNet
{
    public class BiblioNetContext : DbContext
    {
        public BiblioNetContext(DbContextOptions<BiblioNetContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
