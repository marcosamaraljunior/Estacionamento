using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.DataAnnotations;

namespace Infraestrutura.Contextos
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        DbSet<Estadia> Estadia { get; set; }
        DbSet<Carro> Carro { get; set; }
        DbSet<HistoricoEstadia> HistoricoEstadia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=Estacionamento;user=estacionamento;password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Estadia>(new Mapeamentos.MapEstadia().Configure);
            modelBuilder.Entity<Carro>(new Mapeamentos.MapCarro().Configure);
            modelBuilder.Entity<HistoricoEstadia>(new Mapeamentos.MapHistoricoEstadia().Configure);
        }

    }
}