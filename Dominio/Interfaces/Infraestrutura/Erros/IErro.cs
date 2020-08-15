namespace Dominio.Interfaces.Infrasestrutura.Erro
{
    public interface IErro
    {
        string Mensagem { get; set; }
        int StatusCode { get; set; }
    }
}