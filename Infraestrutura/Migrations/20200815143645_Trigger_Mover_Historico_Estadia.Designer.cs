﻿// <auto-generated />
using System;
using Infraestrutura.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestrutura.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200815143645_Trigger_Mover_Historico_Estadia")]
    partial class Trigger_Mover_Historico_Estadia
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.Modelos.Carro", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Modelo")
                        .HasColumnType("text");

                    b.Property<string>("Placa")
                        .HasColumnType("text");

                    b.Property<string>("Tamanho")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("Dominio.Modelos.Estadia", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("CarroId")
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("Entrada")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("Saida")
                        .HasColumnType("datetime");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CarroId");

                    b.ToTable("Estadia");
                });

            modelBuilder.Entity("Dominio.Modelos.Estadia", b =>
                {
                    b.HasOne("Dominio.Modelos.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroId");
                });
#pragma warning restore 612, 618
        }
    }
}