using Dominio.Enums;

namespace Dominio.Modelos
{
    public class Duracao
    {
        public Duracao(EDuracao tipo, int quantidade)
        {
            Tipo = tipo;
            Quantidade = quantidade;
        }

        public EDuracao Tipo { get; set; }
        public int Quantidade { get; set; }
    }
}