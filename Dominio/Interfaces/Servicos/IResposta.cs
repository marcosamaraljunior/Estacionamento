
using Dominio.Interfaces.Infrasestrutura.Erro;

namespace Dominio.Interfaces.Servicos
{
    public interface IResposta<T>
    {
        T Resultado { get; set; }
        IErro Erro { get; set; }

        bool TemErro();

    }

}