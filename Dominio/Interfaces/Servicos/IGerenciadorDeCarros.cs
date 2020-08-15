using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.DTOs;
using Dominio.Modelos;

namespace Dominio.Interfaces.Servicos
{
    public interface IGerenciadorDeCarros
    {
        Task<IResposta<Carro>> CadastrarCarro(CarroDTO dadosCarro);
        Task<Carro> BuscarCarroPorPlaca(string placa);
        Task<List<Carro>> BuscarCarros();
        Task<Carro> AtualizarCadastro(CarroDTO dadosCarro);
        void removerCadastroPorPlaca(string placa);

    }
}