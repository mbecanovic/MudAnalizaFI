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
        public DbSet<Sablon> Sabloni { get; set; }
        public DbSet<OperacionaLista> OperacionaLista { get; set; }
        public DbSet<TextFieldItem> TextFieldItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TextFieldItem>()
            .HasOne(t => t.Element)
            .WithMany() // Nema navigacione kolekcije nazad u Element
            .HasForeignKey(t => t.ElementId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<TextFieldItem>()
                .HasOne(t => t.PodElementi) // Jedan-na-jedan sa podelementom
                .WithOne()
                .HasForeignKey<TextFieldItem>(t => t.PodElementId)
                .OnDelete(DeleteBehavior.SetNull); // Ako PodElement obrišeš, Postavi null

            base.OnModelCreating(modelBuilder);
        }


    }

}
