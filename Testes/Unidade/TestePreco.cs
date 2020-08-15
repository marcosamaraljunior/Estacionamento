using System;
using Dominio.Fabricas;
using Dominio.Modelos;
using FluentAssertions;
using Xunit;

namespace Unidade
{
    public class TestePreco
    {
        [Fact]
        public void Deve_Retornar_6_Ao_Calcular_Preco_De_Tres_Horas()
        {
            //Given
            DateTime entrada = DateTime.Parse("2020-08-14 06:40:00");
            DateTime saida = DateTime.Parse("2020-08-14 09:40:00");

            //When
            var preco = new Preco(new FabricaDuracao().DataInicio(entrada).DataFinal(saida).Criar());

            //Then

            preco.ValorDuracao.Should().Be(6.0);
        }

        [Fact]
        public void Deve_Retornar_1_e_50_Ao_Calcular_Preco_De_Meia_Hora()
        {
            //Given
            DateTime entrada = DateTime.Parse("2020-08-14 06:40:00");
            DateTime saida = DateTime.Parse("2020-08-14 07:25:00");

            //When
            var preco = new Preco(new FabricaDuracao().DataInicio(entrada).DataFinal(saida).Criar());

            //Then

            preco.ValorDuracao.Should().Be(1.5);
        }

        [Fact]
        public void Deve_Retornar_20_Ao_Calcular_Preco_De_Doze_Horas()
        {
            //Given
            DateTime entrada = DateTime.Parse("2020-08-14 06:40:00");
            DateTime saida = DateTime.Parse("2020-08-14 18:50:00");

            //When
            var preco = new Preco(new FabricaDuracao().DataInicio(entrada).DataFinal(saida).Criar());

            //Then

            preco.ValorDuracao.Should().Be(20.0);
        }

        [Fact]
        public void Deve_Retornar_60_Ao_Calcular_Preco_De_Dois_Dias()
        {
            //Given
            DateTime entrada = DateTime.Parse("2020-08-14 06:40:00");
            DateTime saida = DateTime.Parse("2020-08-16 18:50:00");

            //When
            var preco = new Preco(new FabricaDuracao().DataInicio(entrada).DataFinal(saida).Criar());

            //Then

            preco.ValorDuracao.Should().Be(60.0);
        }

        [Fact]
        public void Deve_Retornar_200_Ao_Calcular_Preco_De_Um_MES()
        {
            //Given
            DateTime entrada = DateTime.Parse("2020-08-14 06:40:00");
            DateTime saida = DateTime.Parse("2020-09-16 18:50:00");

            //When
            var preco = new Preco(new FabricaDuracao().DataInicio(entrada).DataFinal(saida).Criar());

            //Then

            preco.ValorDuracao.Should().Be(200.0);
        }
    }
}