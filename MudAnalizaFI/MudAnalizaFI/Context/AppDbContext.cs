using Microsoft.EntityFrameworkCore;
using Shared;

namespace MudAnalizaFI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Paket> Paketi { get; set; }
        public DbSet<Element> Elementi { get; set; }
        public DbSet<Gustina> Gustine { get; set; }
    }
}
