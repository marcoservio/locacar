﻿// <auto-generated />
using System;
using LocaCar.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocaCar.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LocaCar.Api.Models.Ano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_ano");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("codigo_ano");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome_ano");

                    b.Property<DateTime>("last_update_amd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("anos", (string)null);
                });

            modelBuilder.Entity("LocaCar.Api.Models.AnoModelo", b =>
                {
                    b.Property<int>("AnoId")
                        .HasColumnType("int")
                        .HasColumnName("idAno_amd");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int")
                        .HasColumnName("idModelo_amd");

                    b.Property<DateTime>("last_update_amd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("AnoId", "ModeloId");

                    b.HasIndex("ModeloId");

                    b.ToTable("anos_modelos", (string)null);
                });

            modelBuilder.Entity("LocaCar.Api.Models.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_car");

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)")
                        .HasColumnName("ano_car");

                    b.Property<int>("CapacidadePassageiros")
                        .HasColumnType("int")
                        .HasColumnName("capacidadePassageiros_car");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("cor_car");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("descricao_car");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("marca_car");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("modelo_car");

                    b.Property<string>("Motor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("motor_car");

                    b.Property<int>("NumeroPortas")
                        .HasColumnType("int")
                        .HasColumnName("numeroPortas_car");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("preco_car");

                    b.Property<decimal>("Quilometragem")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("quilometragem_car");

                    b.Property<string>("TipoCorpo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tipoCorpo_car");

                    b.Property<string>("Transmissao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("transmissao_car");

                    b.Property<DateTime>("last_update_amd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("carros", (string)null);
                });

            modelBuilder.Entity("LocaCar.Api.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_mar");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("codigo_mar");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome_mar");

                    b.Property<DateTime>("last_update_amd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("marcas", (string)null);
                });

            modelBuilder.Entity("LocaCar.Api.Models.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_mod");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("codigo_mod");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int")
                        .HasColumnName("idMarca_mod");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome_mod");

                    b.Property<DateTime>("last_update_amd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("modelos", (string)null);
                });

            modelBuilder.Entity("LocaCar.Api.Models.AnoModelo", b =>
                {
                    b.HasOne("LocaCar.Api.Models.Ano", "Ano")
                        .WithMany("AnoModelo")
                        .HasForeignKey("AnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocaCar.Api.Models.Modelo", "Modelo")
                        .WithMany("AnoModelo")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ano");

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("LocaCar.Api.Models.Modelo", b =>
                {
                    b.HasOne("LocaCar.Api.Models.Marca", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("LocaCar.Api.Models.Ano", b =>
                {
                    b.Navigation("AnoModelo");
                });

            modelBuilder.Entity("LocaCar.Api.Models.Marca", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("LocaCar.Api.Models.Modelo", b =>
                {
                    b.Navigation("AnoModelo");
                });
#pragma warning restore 612, 618
        }
    }
}
