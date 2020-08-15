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

            var carroInsert = new
            {
                placa = "TTT-0004",
                modelo = "EGol",
                cor = "Prata",
                tamanho = "Medio"
            };
            await _api.PostAsync("/carro", ConverterParaJSON<Object>(carroInsert));
            //Given
            var carro = new
            {
                Placa = "TTT-0004"
            };

            //When
            var retorno = await _api.PostAsync("/estadias", ConverterParaJSON<Object>(carro));
            var conteudo = await retorno.Content.ReadAsStringAsync();
            var estadia = Converter<Dictionary<string, object>>(conteudo);
            var carroEstadia = Converter<Dictionary<string, string>>(estadia["carro"].ToString());

            await _api.GetAsync($"/estadias/{carro.Placa}");  // LIMPEZA 
            var deletado = await _api.DeleteAsync("/estadias/hist"); // LIMPEZA
            await _api.DeleteAsync("/carro/TTT-0004"); // LIMPEZA
            //Then

            estadia["entrada"].ToString().Should().NotBeNullOrWhiteSpace();
            carroEstadia["placa"].Should().Be("TTT-0004");
            carroEstadia["modelo"].Should().Be("EGol");

        }

        [Fact]
        public async Task Deve_Retornar_Uma_Estadia_Ao_Retirar_Um_Carro()
        {
            //Given
            var carroInsert = new
            {
                placa = "TTT-0005",
                modelo = "EPassat",
                cor = "Preto",
                tamanho = "Grande"
            };

            var carro = new
            {
                Placa = "TTT-0005"
            };

            await _api.PostAsync("/carro", ConverterParaJSON<Object>(carroInsert));
            await _api.PostAsync("/estadias", ConverterParaJSON<Object>(carro));

            string placa = "TTT-0005";

            //When

            var retorno = await _api.GetAsync($"/estadias/{placa}");
            var conteudo = await retorno.Content.ReadAsStringAsync();
            var estadia = Converter<Dictionary<string, object>>(conteudo);

            await _api.DeleteAsync("/estadias/hist"); // LIMPEZA
            await _api.DeleteAsync("/carro/TTT-0005"); // LIMPEZA

            //Then
            estadia["entrada"].ToString().Should().NotBeNullOrWhiteSpace();
            estadia["saida"].ToString().Should().NotBeNullOrWhiteSpace();
            estadia["valor"].ToString().Should().NotBeNullOrWhiteSpace();
            estadia["carro"].ToString().Should().NotBeNullOrWhiteSpace();

            //Then
        }

        [Fact]
        public async Task Deve_Retornar_Um_Erro_Ao_Retirar_uma_Estadia_Inexistente()
        {
            //Given
            string placa = "TTT-0006";


            //When

            var retorno = await _api.GetAsync($"/estadias/{placa}");
            var conteudo = await retorno.Content.ReadAsStringAsync();
            var erro = Converter<Dictionary<string, object>>(conteudo);

            //Then
            erro["mensagem"].Should().Be("Nao existe estadia para esta(e) placa.");


            //Then
        }
    }


}