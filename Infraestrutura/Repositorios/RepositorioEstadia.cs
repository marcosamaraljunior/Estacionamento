using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Dominio.Interfaces.Infraestrutura.Repositorios;

namespace Infraestrutura.Repositorios
{
    public class RepositorioEstadia : IRepoEstadia
    {

        private readonly Contextos.MyContext _context;

        public DbSet<Dominio.Modelos.Estadia> _dataset;

        public RepositorioEstadia(Contextos.MyContext context)
        {
            _context = context;
            _dataset = _context.Set<Dominio.Modelos.Estadia>();
        }


        public Estadia BuscarPorPlaca(string placa) => _dataset.Include(e => e.Carro).FirstOrDefault(e => e.Carro.Placa == placa);


        public Estadia SalvarEntrada(Estadia estadia)
        {
            _dataset.Add(estadia);
            _context.SaveChanges();
            return estadia;
        }
        public Estadia SalvarSaida(Estadia estadia)
        {
            _dataset.Update(estadia);
            _context.SaveChanges();
            var estadiasCompletas = _dataset.Where(e => e.Saida != null).ToList();
            _dataset.RemoveRange(estadiasCompletas);
            _context.SaveChanges();
            return estadia;
        }


    }
}