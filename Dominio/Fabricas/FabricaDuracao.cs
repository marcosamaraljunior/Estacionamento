using System;
using Dominio.Enums;
using Dominio.Modelos;

namespace Dominio.Fabricas
{
    public class FabricaDuracao
    {
        public DateTime _dataInicio { get; set; }
        public DateTime _dataFinal { get; set; }
        private int Quantidade { get; set; } = 1;


        public FabricaDuracao DataInicio(DateTime dataInicio)
        {
            _dataInicio = dataInicio;
            return this;
        }
        public FabricaDuracao DataFinal(DateTime dataFinal)
        {
            _dataFinal = dataFinal;
            return this;
        }

        private int calcularQuantidade(int medidaEmSegundos, int totalSegundos) => totalSegundos / medidaEmSegundos;

        private bool Hora(int segundos) => (segundos > 3600 && segundos < 43200) ? true : false;
        private bool DozeHoras(int segundos) => (segundos > 43200 && segundos < 86440) ? true : false;
        private bool Diaria(int segundos) => (segundos > 86440 && segundos < 2592000) ? true : false;
        private bool Mensal(int segundos) => segundos > 2592000 ? true : false;


        public Duracao Criar()
        {

            var diferencaEmSegundos = System.Convert.ToInt32(System.Math.Floor(_dataFinal.Subtract(_dataInicio).TotalSeconds));

            if (Hora(diferencaEmSegundos))
            {
                Quantidade = calcularQuantidade(3600, diferencaEmSegundos);
                return new Duracao(EDuracao.Hora, Quantidade);
            }
            else if (DozeHoras(diferencaEmSegundos))
            {
                return new Duracao(EDuracao.DozeHoras, Quantidade);
            }
            else if (Diaria(diferencaEmSegundos))
            {
                Quantidade = calcularQuantidade(86440, diferencaEmSegundos);
                return new Duracao(EDuracao.Diaria, Quantidade);
            }
            else if (Mensal(diferencaEmSegundos))
            {
                Quantidade = calcularQuantidade(2592000, diferencaEmSegundos);
                return new Duracao(EDuracao.Mensal, Quantidade);
            }
            else
            {
                return new Duracao(EDuracao.MeiaHora, Quantidade);
            }

        }
    }
}