using Dominio.Enums;

namespace Dominio.Modelos
{
    public class Preco
    {
        public Preco(Duracao duracao)
        {
            Duracao = duracao;
        }

        public Duracao Duracao { get; set; }
        public int Quantidade { get; set; }
        public double ValorDuracao
        {
            get => CalcularValorDuracao();
            set => ValorDuracao = value;
        }

        private double CalcularValorDuracao()
        {
            switch (Duracao.Tipo)
            {
                case EDuracao.Hora: return 2.0 * Duracao.Quantidade;
                case EDuracao.DozeHoras: return 20.0 * Duracao.Quantidade;
                case EDuracao.Diaria: return 30.0 * Duracao.Quantidade;
                case EDuracao.Mensal: return 200.0 * Duracao.Quantidade;
                default: return 1.50;

            }
        }

    }
}