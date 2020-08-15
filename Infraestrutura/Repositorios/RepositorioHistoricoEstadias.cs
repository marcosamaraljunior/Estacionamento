using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces.Infraestrutura.Repositorios;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorios
{
    public class RepositorioHistoricoEstadias : IRepoHistoricoEstadias
    {

        private readonly Contextos.MyContext _context;

        public DbSet<Dominio.Modelos.HistoricoEstadia> _dataset;

        public RepositorioHistoricoEstadias(Contextos.MyContext context)
        {
            _context = context;
            _dataset = _context.Set<Dominio.Modelos.HistoricoEstadia>();
        }
        public async Task<List<HistoricoEstadia>> BuscarEstadias()
        {
            return await _dataset.Include(e => e.Carro).ToListAsync();
        }

        public void DeletarEstadias()
        {
            var estadias = _dataset.Where(e => e.Saida != null).ToList();
            _dataset.RemoveRange(estadias);
            _context.SaveChanges();
        }
    }
}