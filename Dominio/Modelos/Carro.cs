using System;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.Enums;

namespace Dominio.Modelos
{
    public class Carro : ModeloBase
    {
        public Carro(string modelo, ECor cor, string placa, ETamanho tamanho)
        {
            Id = Guid.NewGuid();
            Modelo = modelo;
            Cor = cor;
            Placa = placa;
            Tamanho = tamanho;
        }
        public Carro() { }

        public string Modelo { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public ECor Cor { get; set; }
        public string Placa { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public ETamanho Tamanho { get; set; }


    }
}