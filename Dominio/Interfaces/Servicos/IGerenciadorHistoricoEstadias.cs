using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Modelos;

namespace Dominio.Interfaces.Servicos
{
    public interface IGerenciadorHistoricoEstadias
    {
        Task<List<HistoricoEstadia>> BuscarEstadias();
        void DeletarEstadias();
    }
}