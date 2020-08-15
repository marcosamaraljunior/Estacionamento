
using Dominio.Interfaces.Infrasestrutura.Erro;

namespace Infraestrutura.Erros
{
    public class ErroObjetoExistente : IErro
    {
        public string Mensagem { get; set; }
        public int StatusCode { get; set; }

        public ErroObjetoExistente(string objeto, string atributo)
        {
            Mensagem = $"{objeto} ja cadastrado(a) com esta {atributo}.";
            StatusCode = 400;
        }
    }
}