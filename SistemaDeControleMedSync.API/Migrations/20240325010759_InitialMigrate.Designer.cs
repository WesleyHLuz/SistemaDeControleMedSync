﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDeControleMedSync.API.Context;

#nullable disable

namespace SistemaDeControleMedSync.API.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20240325010759_InitialMigrate")]
    partial class InitialMigrate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EspecialidadeMedico", b =>
                {
                    b.Property<int>("EspecialidadesId")
                        .HasColumnType("int");

                    b.Property<int>("MedicosId")
                        .HasColumnType("int");

                    b.HasKey("EspecialidadesId", "MedicosId");

                    b.HasIndex("MedicosId");

                    b.ToTable("EspecialidadeMedico");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ConvenioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ConvenioId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.Entities.Convenio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cobertura")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Convenios");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.Entities.Especialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.Entities.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("empresaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("empresaId");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.Entities.MedicoEspecialidade", b =>
                {
                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<int>("EspecialidadeId")
                        .HasColumnType("int");

                    b.HasKey("MedicoId", "EspecialidadeId");

                    b.HasIndex("EspecialidadeId");

                    b.ToTable("MedicoEspecialidades");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.ValueObject.Cpf", b =>
                {
                    b.ToTable("Cpf");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.ValueObject.Email", b =>
                {
                    b.ToTable("Email");
                });

            modelBuilder.Entity("EspecialidadeMedico", b =>
                {
                    b.HasOne("SistemaDeControleMedSync.API.Entities.Especialidade", null)
                        .WithMany()
                        .HasForeignKey("EspecialidadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeControleMedSync.API.Entities.Medico", null)
                        .WithMany()
                        .HasForeignKey("MedicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.Entities.Cliente", b =>
                {
                    b.HasOne("SistemaDeControleMedSync.API.Entities.Convenio", "Convenio")
                        .WithMany()
                        .HasForeignKey("ConvenioId");

                    b.Navigation("Convenio");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.Entities.Convenio", b =>
                {
                    b.HasOne("SistemaDeControleMedSync.API.Entities.Empresa", "Empresa")
                        .WithMany("ConveniosAceitos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.Entities.Especialidade", b =>
                {
                    b.HasOne("SistemaDeControleMedSync.API.Entities.Empresa", "Empresa")
                        .WithMany("Especialidades")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.Entities.Medico", b =>
                {
                    b.HasOne("SistemaDeControleMedSync.API.Entities.Empresa", "Empresa")
                        .WithMany("Medicos")
                        .HasForeignKey("empresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.Entities.MedicoEspecialidade", b =>
                {
                    b.HasOne("SistemaDeControleMedSync.API.Entities.Especialidade", "Especialidade")
                        .WithMany()
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeControleMedSync.API.Entities.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidade");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.Entities.Usuario", b =>
                {
                    b.HasOne("SistemaDeControleMedSync.API.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("SistemaDeControleMedSync.API.Entities.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId");

                    b.Navigation("Cliente");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaDeControleMedSync.API.Entities.Empresa", b =>
                {
                    b.Navigation("ConveniosAceitos");

                    b.Navigation("Especialidades");

                    b.Navigation("Medicos");
                });
#pragma warning restore 612, 618
        }
    }
}
