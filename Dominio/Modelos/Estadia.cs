using System;

namespace Dominio.Modelos
{
    public class Estadia : ModeloBase
    {


        public Estadia(Carro carro, DateTime entrada)
        {
            Id = Guid.NewGuid();
            Carro = carro;
            Entrada = entrada;
            Saida = null;

        }
        public Estadia() { }

        public Carro Carro { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public double Valor { get; set; }



    }
}