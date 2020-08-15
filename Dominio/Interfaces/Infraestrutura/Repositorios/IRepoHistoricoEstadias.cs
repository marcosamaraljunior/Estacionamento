using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Modelos;

namespace Dominio.Interfaces.Infraestrutura.Repositorios
{
    public interface IRepoHistoricoEstadias
    {
        Task<List<HistoricoEstadia>> BuscarEstadias();
        void DeletarEstadias();
    }
}