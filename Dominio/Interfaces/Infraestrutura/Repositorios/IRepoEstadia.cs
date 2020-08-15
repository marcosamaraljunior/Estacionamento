using Dominio.Modelos;

namespace Dominio.Interfaces.Infraestrutura.Repositorios
{
    public interface IRepoEstadia
    {
        Estadia SalvarEntrada(Estadia estadia);
        Estadia SalvarSaida(Estadia estadia);
        Estadia BuscarPorPlaca(string carro);

    }
}