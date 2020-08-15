using System;

namespace Dominio.Modelos
{
    public class HistoricoEstadia : ModeloBase
    {


        public HistoricoEstadia(Carro carro, DateTime entrada)
        {
            Id = Guid.NewGuid();
            Carro = carro;
            Entrada = entrada;
            Saida = null;

        }
        public HistoricoEstadia() { }

        public Carro Carro { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public double Valor { get; set; }



    }
}