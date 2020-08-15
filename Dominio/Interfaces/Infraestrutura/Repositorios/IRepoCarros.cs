using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Modelos;

namespace Dominio.Interfaces.Infraestrutura.Repositorios
{
    public interface IRepoCarros
    {
        Task<Carro> Inserir(Carro carro);
        Task<List<Carro>> Buscar();
        Task<Carro> BuscarPorPlaca(string placa);
        Task<Carro> Atualizar(Carro carro);
        void Remover(string placa);
    }
}