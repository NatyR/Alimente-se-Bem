using Microsoft.EntityFrameworkCore;
using alimentesebem.sesi.domain.Entities;

namespace alimentesebem.sesi.repository.Context
{
    public class ISesiContext : DbContext
    {
        public ISesiContext(DbContextOptions<ISesiContext> options)
        : base(options)
        {

        }

        public DbSet<Noticias> Noticias { get; set; }
        public DbSet<Categorias_Noticias> Categorias_Noticias { get; set; }
        public DbSet<Videos> Videos { get; set; }
        public DbSet<Categorias_Videos> Categorias_Videos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<Unidades_Sesi> Unidades_Sesi { get; set; }
        public DbSet<Nutricionista> Nutricionista { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Dispositivo> Dispositivo { get; set; }
        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Perguntas> Perguntas { get; set; }
        public DbSet<Alternativas> Alternativas { get; set; }
        public DbSet<Respostas> Respostas { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Noticias>().ToTable("Noticias");
            modelBuilder.Entity<Categorias_Noticias>().ToTable("Categorias_Noticias");
            modelBuilder.Entity<Videos>().ToTable("Videos");
            modelBuilder.Entity<Categorias_Videos>().ToTable("Categorias_Videos");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Permissao>().ToTable("Permissao");
            modelBuilder.Entity<Agenda>().ToTable("Agenda");
            modelBuilder.Entity<Unidades_Sesi>().ToTable("Unidades_Sesi");
            modelBuilder.Entity<Nutricionista>().ToTable("Nutricionista");
            modelBuilder.Entity<Dispositivo>().ToTable("Dispositivo");
            modelBuilder.Entity<Restaurante>().ToTable("Restaurante");
            modelBuilder.Entity<Perguntas>().ToTable("Perguntas");
            modelBuilder.Entity<Alternativas>().ToTable("Alternativas");
            modelBuilder.Entity<Respostas>().ToTable("Respostas");






            modelBuilder
                .Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();


            modelBuilder
                .Entity<Nutricionista>()
                .HasIndex(n => n.NIF)
                .IsUnique();

            modelBuilder
                .Entity<Nutricionista>()
                .HasIndex(n => n.Email)
                .IsUnique();

            modelBuilder
                .Entity<Dispositivo>()
                .HasIndex(d => d.Serial)
                .IsUnique();


            base.OnModelCreating(modelBuilder);
        }

    }
}