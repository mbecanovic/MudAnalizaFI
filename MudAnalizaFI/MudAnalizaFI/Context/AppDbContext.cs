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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Element>()
                .HasOne(e => e.Gustina)
                .WithMany()
                .HasForeignKey(e => e.GustinaId)
                .OnDelete(DeleteBehavior.Restrict); // ← Ovde sprečavaš brisanje povezanih elemenata*/

        }
    }

}
