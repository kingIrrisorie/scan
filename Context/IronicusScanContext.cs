using Microsoft.EntityFrameworkCore;
using scan.Models;

namespace scan.Context
{
    public class IronicusScanContext : DbContext
    {
        public IronicusScanContext(DbContextOptions<IronicusScanContext> options) : base(options){}

        public DbSet<Manga> Mangas {get; set;}
        public DbSet<Author> Authors {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manga>()
                .HasOne(m => m.Author)
                .WithMany(a => a.Mangas)
                .HasForeignKey(m => m.AuthorId);

            modelBuilder.Entity<Chapter>()
                .HasOne(c => c.Manga)
                .WithMany(m => m.Chapters)
                .HasForeignKey(c => c.MangaId);

            modelBuilder.Entity<Page>()
                .HasOne(p => p.Chapter)
                .WithMany(c => c.Pages)
                .HasForeignKey(p => p.ChapterId);

            modelBuilder.Entity<Manga>()
                .HasMany(m => m.Genders)
                .WithMany(g => g.Mangas)
                .UsingEntity(j => j.ToTable("MangaGenero"));

            base.OnModelCreating(modelBuilder);
        }
    }
}