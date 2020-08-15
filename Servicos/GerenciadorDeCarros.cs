using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Modelos;
using Dominio.Enums;
using Dominio.DTOs;
using Infraestrutura.Erros;
using Dominio.Interfaces.Infraestrutura.Repositorios;
using Dominio.Interfaces.Servicos;

namespace Servicos
{
    public class GerenciadorDeCarros : IGerenciadorDeCarros
    {

        private IRepoCarros _repoCarros;

        public GerenciadorDeCarros(IRepoCarros repo)
        {
            _repoCarros = repo;
        }

        public async Task<Carro> AtualizarCadastro(CarroDTO dadosCarro)
        {
            var carro = await _repoCarros.BuscarPorPlaca(dadosCarro.Placa);

            carro.Modelo = dadosCarro.Modelo;
            carro.Cor = (ECor)Enum.Parse(typeof(ECor), dadosCarro.Cor);
            carro.Placa = dadosCarro.Placa;
            carro.Tamanho = (ETamanho)Enum.Parse(typeof(ETamanho), dadosCarro.Tamanho);

            return await _repoCarros.Atualizar(carro);

        }

        public async Task<Carro> BuscarCarroPorPlaca(string placa)
        {
            return await _repoCarros.BuscarPorPlaca(placa);
        }

        public async Task<List<Carro>> BuscarCarros()
        {
            return await _repoCarros.Buscar();
        }

        public async Task<IResposta<Carro>> CadastrarCarro(CarroDTO dadosCarro)
        {

            var objResposta = new Resposta<Carro>();

            var carroEncontrado = await _repoCarros.BuscarPorPlaca(dadosCarro.Placa);

            if (carroEncontrado == null)
            {
                var carro = new Carro(dadosCarro.Modelo, (ECor)Enum.Parse(typeof(ECor), dadosCarro.Cor),
                      dadosCarro.Placa, (ETamanho)Enum.Parse(typeof(ETamanho), dadosCarro.Tamanho));

                objResposta.Resultado = await _repoCarros.Inserir(carro);
            }
            else
            {
                objResposta.Erro = new ErroObjetoExistente("Carro", "placa");
            }

            return objResposta;

        }
        public void removerCadastroPorPlaca(string placa) => _repoCarros.Remover(placa);
    }
}