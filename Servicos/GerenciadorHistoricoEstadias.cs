using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Interfaces.Infraestrutura.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.Modelos;

namespace Servicos
{
    public class GerenciadorHistoricoEstadias : IGerenciadorHistoricoEstadias
    {
        private IRepoHistoricoEstadias _repoHistoricoEstadias;
        public GerenciadorHistoricoEstadias(IRepoHistoricoEstadias repo)
        {
            _repoHistoricoEstadias = repo;
        }

        public async Task<List<HistoricoEstadia>> BuscarEstadias()
        {
            return await _repoHistoricoEstadias.BuscarEstadias();
        }

        public void DeletarEstadias()
        {
            _repoHistoricoEstadias.DeletarEstadias();
        }
    }
}