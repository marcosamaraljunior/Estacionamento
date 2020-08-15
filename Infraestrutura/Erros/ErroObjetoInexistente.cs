using Dominio.Interfaces.Infrasestrutura.Erro;

namespace Infraestrutura.Erros
{
    public class ErroObjetoInexistente : IErro
    {
        public string Mensagem { get; set; }
        public int StatusCode { get; set; }

        public ErroObjetoInexistente(string objeto, string atributo)
        {
            Mensagem = $"Nao existe {objeto} para esta(e) {atributo}.";
            StatusCode = 400;
        }
    }
}