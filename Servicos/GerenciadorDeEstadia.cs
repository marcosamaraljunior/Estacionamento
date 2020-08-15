using System;
using System.Threading.Tasks;
using Dominio.Fabricas;
using Dominio.Interfaces.Infraestrutura.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.Modelos;
using Infraestrutura.Erros;

namespace Servicos
{

    public class GerenciadorDeEstadia : IGerenciadorDeEstadia
    {

        private IRepoEstadia _repoEstadia;
        private IRepoCarros _repoCarros;

        public GerenciadorDeEstadia(IRepoEstadia repo, IRepoCarros repocarro)
        {
            _repoEstadia = repo;
            _repoCarros = repocarro;
        }

        private double GerarValorDeEstadia(Estadia estadia)
        {
            return new Preco(new FabricaDuracao()
                            .DataInicio(estadia.Entrada)
                            .DataFinal(estadia.Saida.Value)
                            .Criar())
                            .ValorDuracao;
        }

        public async Task<IResposta<Estadia>> EntrarCarro(string placa)
        {
            var objResposta = new Resposta<Estadia>();
            var carro = await _repoCarros.BuscarPorPlaca(placa);

            var estadiaExistente = _repoEstadia.BuscarPorPlaca(carro.Placa);

            if (estadiaExistente != null)
            {
                objResposta.Erro = new ErroObjetoExistente("Estadia", "Placa");
            }
            else
            {
                objResposta.Resultado = _repoEstadia.SalvarEntrada(new Estadia(carro, DateTime.Now));
            }

            return objResposta;

        }

        public IResposta<Estadia> RetirarCarro(string placa)
        {
            var estadia = _repoEstadia.BuscarPorPlaca(placa);
            var objResposta = new Resposta<Estadia>();

            if (estadia.Saida == null)
            {
                estadia.Saida = DateTime.Now;
                estadia.Valor = GerarValorDeEstadia(estadia);
                _repoEstadia.SalvarSaida(estadia);
                objResposta.Resultado = estadia;
            }
            else
            {
                objResposta.Erro = new ErroObjetoInexistente("Estadia", "Placa");
            }
            return objResposta;


        }


    }
}