using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos = Dominio.Modelos;

namespace Infraestrutura.Mapeamentos
{
    public class MapEstadia : IEntityTypeConfiguration<Modelos.Estadia>
    {
        public void Configure(EntityTypeBuilder<Modelos.Estadia> builder)
        {
            builder.ToTable("Estadia");

            builder.HasKey(Estadia => Estadia.Id);
            builder.HasOne(Estadia => Estadia.Carro);
            builder.Property(Estadia => Estadia.Entrada).IsRequired();
            builder.Property(Estadia => Estadia.Saida);
        }
    }
}