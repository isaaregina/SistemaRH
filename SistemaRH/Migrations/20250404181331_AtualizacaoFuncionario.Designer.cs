﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SistemaRH.Data;

#nullable disable

namespace SistemaRH.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20250404181331_AtualizacaoFuncionario")]
    partial class AtualizacaoFuncionario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SistemaRH.Models.Departamento", b =>
                {
                    b.Property<int>("DepartamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartamentoID"));

                    b.Property<int?>("EmpresaID")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DepartamentoID");

                    b.HasIndex("EmpresaID");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("SistemaRH.Models.Empresa", b =>
                {
                    b.Property<int>("EmpresaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmpresaID"));

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("EmpresaID");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("SistemaRH.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FuncionarioID"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<int>("DepartamentoID")
                        .HasColumnType("integer");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FuncionarioID");

                    b.HasIndex("DepartamentoID");

                    b.HasIndex("EmpresaID");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("SistemaRH.Models.Tarefa", b =>
                {
                    b.Property<int>("TarefaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TarefaID"));

                    b.Property<int>("FuncionarioID")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TarefaID");

                    b.HasIndex("FuncionarioID");

                    b.ToTable("Tarefa");
                });

            modelBuilder.Entity("SistemaRH.Models.Departamento", b =>
                {
                    b.HasOne("SistemaRH.Models.Empresa", null)
                        .WithMany("Departamentos")
                        .HasForeignKey("EmpresaID");
                });

            modelBuilder.Entity("SistemaRH.Models.Funcionario", b =>
                {
                    b.HasOne("SistemaRH.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaRH.Models.Empresa", "Empresa")
                        .WithMany("Funcionarios")
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaRH.Models.Tarefa", b =>
                {
                    b.HasOne("SistemaRH.Models.Funcionario", "Funcionario")
                        .WithMany("Tarefa")
                        .HasForeignKey("FuncionarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("SistemaRH.Models.Empresa", b =>
                {
                    b.Navigation("Departamentos");

                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("SistemaRH.Models.Funcionario", b =>
                {
                    b.Navigation("Tarefa");
                });
#pragma warning restore 612, 618
        }
    }
}
