using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

#nullable disable

namespace tp3.Models.EntityFramework
{
    public partial class tp3Context : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        public tp3Context()
        {
        }

        public tp3Context(DbContextOptions<tp3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Favoris> Favoris { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Compte> Comptes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // optionsBuilder.UseLoggerFactory(MyLoggerFactory).EnableSensitiveDataLogging().UseNpgsql("Server=localhost;port=5432;Database=FilmsDB; uid=postgres;\npassword=postgres;");
                //optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_France.1252");

            modelBuilder.Entity<Favoris>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.CompteId })
                    .HasName("pk_favoris");

                entity.HasOne(d => d.FilmFavori)
                    .WithMany(p => p.FavorisFilm)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avis_film");

                entity.HasOne(d => d.CompteFavori)
                    .WithMany(p => p.FavorisCompte)
                    .HasForeignKey(d => d.CompteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avis_utilisateur");
            });

            modelBuilder.Entity<Compte>()
                .Property(b => b.DateCreation)
                .HasDefaultValueSql("CURRENT_DATE");
            modelBuilder.Entity<Compte>()
               .Property(b => b.Pays)
               .HasDefaultValue("France");
            modelBuilder.Entity<Compte>()
                .HasIndex(u => u.Mel)
                .IsUnique();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
