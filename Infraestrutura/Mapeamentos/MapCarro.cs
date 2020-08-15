using Dominio.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Modelos = Dominio.Modelos;

namespace Infraestrutura.Mapeamentos
{
    public class MapCarro : IEntityTypeConfiguration<Modelos.Carro>
    {
        public void Configure(EntityTypeBuilder<Modelos.Carro> builder)
        {

            builder.ToTable("Carro");

            builder.HasKey(Carro => Carro.Id);
            builder.Property(Carro => Carro.Modelo);
            builder.Property(Carro => Carro.Cor).HasConversion(new EnumToStringConverter<ECor>()).IsRequired();
            builder.Property(Carro => Carro.Placa);
            builder.Property(Carro => Carro.Tamanho).HasConversion(new EnumToStringConverter<ETamanho>()).IsRequired();
        }
    }
}