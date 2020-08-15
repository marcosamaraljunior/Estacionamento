using System;
using Dominio.Enums;
using Dominio.Fabricas;
using FluentAssertions;
using Xunit;

namespace Unidade
{
    public class TesteFabricaDuracao
    {
        [Fact]
        public void Deve_Retornar_Um_Enum_De_Uma_Hora_Ao_Receber_Um_Range_de_Datas()
        {
            //Given
            DateTime entrada = DateTime.Parse("2020-08-14 06:40:00");
            DateTime saida = DateTime.Parse("2020-08-14 09:45:00");

            //When
            var horario = new FabricaDuracao().DataInicio(entrada)
                                                .DataFinal(saida)
                                                .Criar();

            //Then
            horario.Tipo.Should().Be((EDuracao)Enum.Parse(typeof(EDuracao), "Hora"));
        }
        [Fact]
        public void Deve_Retornar_Um_Enum_De_Meia_Hora_Ao_Receber_Um_Range_de_Datas()
        {
            //Given
            DateTime entrada = DateTime.Parse("2020-08-14 06:40:00");
            DateTime saida = DateTime.Parse("2020-08-14 07:30:00");

            //When
            var horario = new FabricaDuracao().DataInicio(entrada)
                                                .DataFinal(saida)
                                                .Criar();

            //Then
            horario.Tipo.Should().Be((EDuracao)Enum.Parse(typeof(EDuracao), "MeiaHora"));
        }
        [Fact]
        public void Deve_Retornar_Um_Enum_De_Doze_Horas_Ao_Receber_Um_Range_de_Datas()
        {
            //Given
            DateTime entrada = DateTime.Parse("2020-08-14 06:40:00");
            DateTime saida = DateTime.Parse("2020-08-14 18:45:00");

            //When
            var horario = new FabricaDuracao().DataInicio(entrada)
                                                .DataFinal(saida)
                                                .Criar();

            //Then
            horario.Tipo.Should().Be((EDuracao)Enum.Parse(typeof(EDuracao), "DozeHoras"));
        }
        [Fact]
        public void Deve_Retornar_Um_Enum_Mensal_Ao_Receber_Um_Range_de_Datas()
        {
            //Given
            DateTime entrada = DateTime.Parse("2020-08-14 06:40:00");
            DateTime saida = DateTime.Parse("2020-08-14 18:45:00");

            //When
            var horario = new FabricaDuracao().DataInicio(entrada)
                                                .DataFinal(saida)
                                                .Criar();

            //Then
            horario.Tipo.Should().Be((EDuracao)Enum.Parse(typeof(EDuracao), "DozeHoras"));
        }
    }
}