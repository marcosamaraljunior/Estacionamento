using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Testes.Integracao
{
    public class TesteEstadia : IntegracaoBase
    {
        [Fact]
        public async Task Deve_Retornar_Um_Guid_Ao_Cadastrar_Estadia()
        {
            //Given
            var carro = new
            {
                Placa = "ZZZ-1287"
            };

            //When
            var retorno = await _api.PostAsync("/estadias", ConverterParaJSON<Object>(carro));
            var conteudo = await retorno.Content.ReadAsStringAsync();
            var estadia = Converter<Dictionary<string, object>>(conteudo);
            var carroEstadia = Converter<Dictionary<string, string>>(estadia["carro"].ToString());

            //Then

            estadia["entrada"].ToString().Should().NotBeNullOrWhiteSpace();
            carroEstadia["placa"].Should().Be("ZZZ-1287");
            carroEstadia["modelo"].Should().Be("Punto Brabo");

        }


        [Fact]
        public async Task Deve_Retornar_Uma_Estadia_Ao_Retirar_Um_Carro()
        {
            //Given
            string placa = "ZZZ-1287";

            //When

            var retorno = await _api.GetAsync($"/estadias/{placa}");
            var conteudo = await retorno.Content.ReadAsStringAsync();
            var estadia = Converter<Dictionary<string, object>>(conteudo);

            //Then
            estadia["entrada"].ToString().Should().NotBeNullOrWhiteSpace();
            estadia["saida"].ToString().Should().NotBeNullOrWhiteSpace();
            estadia["valor"].ToString().Should().NotBeNullOrWhiteSpace();
            estadia["carro"].ToString().Should().NotBeNullOrWhiteSpace();

            //Then
        }
    }


}