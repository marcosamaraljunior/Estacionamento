using System.Threading.Tasks;
using Dominio.Modelos;

namespace Dominio.Interfaces.Servicos
{
    public interface IGerenciadorDeEstadia
    {
        Task<IResposta<Estadia>> EntrarCarro(string placa);
        IResposta<Estadia> RetirarCarro(string placa);

    }
}