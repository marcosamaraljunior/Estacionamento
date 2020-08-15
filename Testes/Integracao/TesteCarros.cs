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
                placa = "XXX-1254",
                modelo = "Gol",
                cor = "Prata",
                tamanho = "Medio"
            };
            //When
            var retorno = await _api.PostAsync("/carro", ConverterParaJSON<Object>(carro));
            var conteudo = retorno.Content.ReadAsStringAsync();

            //Then
            conteudo.Id.ToString().Should().NotBeNullOrEmpty();

        }
        [Fact]
        public async Task Deve_Retornar_Objeto_Carro_Por_Sua_Placa()
        {
            //Given

            //When
            var retorno = await _api.GetAsync("/carro/XXX-1254");
            var carroJson = await retorno.Content.ReadAsStringAsync();
            var carro = Converter<Dictionary<string, string>>(carroJson);
            //Then
            carro["placa"].Should().Be("XXX-1254");
            carro["tamanho"].Should().Be("Medio");
            carro["cor"].Should().Be("Prata");

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
                placa = "XXX-1256",
                modelo = "Gol",
                cor = "Prata",
                tamanho = "Medio"
            };


            //When

            var retorno = await _api.PostAsync("/carro", ConverterParaJSON<Object>(carro));
            var conteudo = await retorno.Content.ReadAsStringAsync();

            var erro = Converter<Dictionary<string, string>>(conteudo);

            //Then

            retorno.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            erro["mensagem"].Should().Be("Carro ja cadastrado(a) com esta placa.");


        }
    }



}