using Dominio.Interfaces;
using Dominio.Interfaces.Infrasestrutura.Erro;
using Dominio.Interfaces.Servicos;

namespace Servicos
{
    public class Resposta<T> : IResposta<T>
    {
        public T Resultado { get; set; }
        public IErro Erro { get; set; }

        public bool TemErro() => Erro != null;

    }
}