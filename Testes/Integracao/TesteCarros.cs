using Xunit;
using System.Threading.Tasks;
using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;

namespace Testes.Integracao
{
    public class TesteCarros : IntegracaoBase
    {

        [Fact]
        public async Task Deve_Retornar_Um_Guid_Ao_Cadastrar_Um_Carro()
        {
            //Given
            var carro = new
            {
                placa = "TTT-0001",
                modelo = "Gol",
                cor = "Prata",
                tamanho = "Medio"
            };
            //When
            var retorno = await _api.PostAsync("/carro", ConverterParaJSON<Object>(carro));
            var conteudo = retorno.Content.ReadAsStringAsync();

            await _api.DeleteAsync("/carro/TTT-0001");  // REMOVER RASTROS

            //Then
            conteudo.Id.ToString().Should().NotBeNullOrEmpty();

        }
        [Fact]
        public async Task Deve_Retornar_Objeto_Carro_Por_Sua_Placa()
        {
            //Given

            var carroInsert = new
            {
                placa = "TTT-0002",
                modelo = "Bora",
                cor = "Preto",
                tamanho = "Pequeno"
            };
            await _api.PostAsync("/carro", ConverterParaJSON<Object>(carroInsert));


            //When
            var retorno = await _api.GetAsync("/carro/TTT-0002");
            var carroJson = await retorno.Content.ReadAsStringAsync();
            var carro = Converter<Dictionary<string, string>>(carroJson);

            await _api.DeleteAsync("/carro/TTT-0002");  // REMOVER RASTROS
            //Then
            carro["placa"].Should().Be("TTT-0002");
            carro["tamanho"].Should().Be("Pequeno");
            carro["cor"].Should().Be("Preto");

        }


        [Fact]
        public async Task Deve_Retornar_Uma_Lista_De_Carros()
        {
            //Given
            var retorno = await _api.GetAsync("/carro");
            //When
            var listaCarros = await retorno.Content.ReadAsStringAsync();
            //Then
        }
        [Fact]
        public async void Deve_retornar_Um_Erro_Ao_Inserir_Um_Carro_Com_A_Mesma_Placa()
        {
            //Given

            var carro = new
            {
                placa = "TTT-0003",
                modelo = "Passat",
                cor = "Branco",
                tamanho = "Grande"
            };

            await _api.PostAsync("/carro", ConverterParaJSON<Object>(carro));
            //When


            var retorno = await _api.PostAsync("/carro", ConverterParaJSON<Object>(carro));
            var conteudo = await retorno.Content.ReadAsStringAsync();

            var erro = Converter<Dictionary<string, string>>(conteudo);

            await _api.DeleteAsync("/carro/TTT-0003");  // REMOVER RASTROS

            //Then

            retorno.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            erro["mensagem"].Should().Be("Carro ja cadastrado(a) com esta placa.");


        }
    }



}