using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces.Infraestrutura.Repositorios;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorios
{
    public class RepositorioCarros : IRepoCarros
    {

        private Contextos.MyContext _context;
        private DbSet<Dominio.Modelos.Carro> _dataset;

        public RepositorioCarros(Contextos.MyContext context)
        {
            _context = context;
            _dataset = _context.Set<Dominio.Modelos.Carro>();
        }

        public async Task<List<Carro>> Buscar()
        {
            var carros = await _dataset.ToListAsync();
            return carros;
        }
        public async Task<Carro> BuscarPorPlaca(string placa)
        {
            return await _dataset.FirstOrDefaultAsync(c => c.Placa == placa);
        }
        public async Task<Carro> Inserir(Carro carro)
        {
            _dataset.Add(carro);
            _context.SaveChanges();
            return await Task.FromResult(carro);
        }
        public async Task<Carro> Atualizar(Carro carro)
        {
            _dataset.Update(carro);
            _context.SaveChanges();
            return await BuscarPorPlaca(carro.Placa);
        }
        public void Remover(string placa)
        {
            var carro = _dataset.FirstOrDefault(c => c.Placa == placa);
            _dataset.Remove(carro);
            _context.SaveChanges();
        }
    }
}