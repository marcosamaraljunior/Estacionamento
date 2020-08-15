using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos = Dominio.Modelos;

namespace Infraestrutura.Mapeamentos
{
    public class MapHistoricoEstadia : IEntityTypeConfiguration<Modelos.HistoricoEstadia>
    {
        public void Configure(EntityTypeBuilder<Modelos.HistoricoEstadia> builder)
        {
            builder.ToTable("Historico_Estadia");

            builder.HasKey(Estadia => Estadia.Id);
            builder.HasOne(Estadia => Estadia.Carro);
            builder.Property(Estadia => Estadia.Entrada).IsRequired();
            builder.Property(Estadia => Estadia.Saida).IsRequired();
        }
    }
}