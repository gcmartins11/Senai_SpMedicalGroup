﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpMedicalGroup.WebApi.Domains;

namespace SpMedicalGroup.WebApi.Migrations
{
    [DbContext(typeof(SpMedGroupContext))]
    partial class SpMedGroupContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpMedicalGroup.WebApi.Domains.Clinicas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnName("BAIRRO")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnName("CIDADE")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnName("CNPJ")
                        .HasMaxLength(12)
                        .IsUnicode(false);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnName("ESTADO")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnName("LOGRADOURO")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnName("NOME_FANTASIA")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<int>("Numero")
                        .HasColumnName("NUMERO");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnName("RAZAO_SOCIAL")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Cnpj")
                        .IsUnique()
                        .HasName("UQ__CLINICAS__AA57D6B451AC04ED");

                    b.HasIndex("RazaoSocial")
                        .IsUnique()
                        .HasName("UQ__CLINICAS__10D918D9384F292A");

                    b.ToTable("CLINICAS");
                });

            modelBuilder.Entity("SpMedicalGroup.WebApi.Domains.Consultas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnName("DATA_CONSULTA")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .HasColumnName("DESCRICAO")
                        .HasColumnType("text");

                    b.Property<TimeSpan>("HoraConsulta")
                        .HasColumnName("HORA_CONSULTA");

                    b.Property<int?>("IdMedico")
                        .HasColumnName("ID_MEDICO");

                    b.Property<int?>("IdPaciente")
                        .HasColumnName("ID_PACIENTE");

                    b.Property<int?>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_STATUS")
                        .HasDefaultValueSql("((1))");

                    b.HasKey("Id");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.HasIndex("IdStatus");

                    b.ToTable("CONSULTAS");
                });

            modelBuilder.Entity("SpMedicalGroup.WebApi.Domains.Credenciais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Credencial")
                        .IsRequired()
                        .HasColumnName("CREDENCIAL")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("CREDENCIAIS");
                });

            modelBuilder.Entity("SpMedicalGroup.WebApi.Domains.Especialidades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnName("ESPECIALIDADE")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("ESPECIALIDADES");
                });

            modelBuilder.Entity("SpMedicalGroup.WebApi.Domains.Medicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnName("CRM")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<int?>("IdClinica")
                        .HasColumnName("ID_CLINICA");

                    b.Property<int?>("IdEspecialidade")
                        .HasColumnName("ID_ESPECIALIDADE");

                    b.Property<int?>("IdUsuario")
                        .HasColumnName("ID_USUARIO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Crm")
                        .IsUnique()
                        .HasName("UQ__MEDICOS__C1F887FF8B00054C");

                    b.HasIndex("IdClinica");

                    b.HasIndex("IdEspecialidade");

                    b.HasIndex("IdUsuario");

                    b.ToTable("MEDICOS");
                });

            modelBuilder.Entity("SpMedicalGroup.WebApi.Domains.Pacientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnName("BAIRRO")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnName("CIDADE")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DATA_NASCIMENTO")
                        .HasColumnType("date");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnName("ESTADO")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<int?>("IdUsuario")
                        .HasColumnName("ID_USUARIO");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnName("LOGRADOURO")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<int>("Numero")
                        .HasColumnName("NUMERO");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnName("RG")
                        .HasMaxLength(9)
                        .IsUnicode(false);

                    b.Property<string>("Telefone")
                        .HasColumnName("TELEFONE")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique()
                        .HasName("UQ__PACIENTE__C1F89731314B3FB6");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("Rg")
                        .IsUnique()
                        .HasName("UQ__PACIENTE__321537C89E60A7DA");

                    b.ToTable("PACIENTES");
                });

            modelBuilder.Entity("SpMedicalGroup.WebApi.Domains.StatusConsulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnName("SITUACAO")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("STATUS_CONSULTA");
                });

            modelBuilder.Entity("SpMedicalGroup.WebApi.Domains.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<int?>("IdCredencial")
                        .HasColumnName("ID_CREDENCIAL");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("SENHA")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ__USUARIOS__161CF724B38F03E3");

                    b.HasIndex("IdCredencial");

                    b.ToTable("USUARIOS");
                });

            modelBuilder.Entity("SpMedicalGroup.WebApi.Domains.Consultas", b =>
                {
                    b.HasOne("SpMedicalGroup.WebApi.Domains.Medicos", "IdMedicoNavigation")
                        .WithMany("Consultas")
                        .HasForeignKey("IdMedico")
                        .HasConstraintName("FK__CONSULTAS__ID_ME__628FA481");

                    b.HasOne("SpMedicalGroup.WebApi.Domains.Pacientes", "IdPacienteNavigation")
                        .WithMany("Consultas")
                        .HasForeignKey("IdPaciente")
                        .HasConstraintName("FK__CONSULTAS__ID_PA__619B8048");

                    b.HasOne("SpMedicalGroup.WebApi.Domains.StatusConsulta", "IdStatusNavigation")
                        .WithMany("Consultas")
                        .HasForeignKey("IdStatus")
                        .HasConstraintName("FK__CONSULTAS__ID_ST__6383C8BA");
                });

            modelBuilder.Entity("SpMedicalGroup.WebApi.Domains.Medicos", b =>
                {
                    b.HasOne("SpMedicalGroup.WebApi.Domains.Clinicas", "IdClinicaNavigation")
                        .WithMany("Medicos")
                        .HasForeignKey("IdClinica")
                        .HasConstraintName("FK__MEDICOS__ID_CLIN__5CD6CB2B");

                    b.HasOne("SpMedicalGroup.WebApi.Domains.Especialidades", "IdEspecialidadeNavigation")
                        .WithMany("Medicos")
                        .HasForeignKey("IdEspecialidade")
                        .HasConstraintName("FK__MEDICOS__ID_ESPE__5BE2A6F2");

                    b.HasOne("SpMedicalGroup.WebApi.Domains.Usuarios", "IdUsuarioNavigation")
                        .WithMany("Medicos")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__MEDICOS__ID_USUA__5AEE82B9");
                });

            modelBuilder.Entity("SpMedicalGroup.WebApi.Domains.Pacientes", b =>
                {
                    b.HasOne("SpMedicalGroup.WebApi.Domains.Usuarios", "IdUsuarioNavigation")
                        .WithMany("Pacientes")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__PACIENTES__ID_US__5535A963");
                });

            modelBuilder.Entity("SpMedicalGroup.WebApi.Domains.Usuarios", b =>
                {
                    b.HasOne("SpMedicalGroup.WebApi.Domains.Credenciais", "IdCredencialNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdCredencial")
                        .HasConstraintName("FK__USUARIOS__ID_CRE__5070F446");
                });
#pragma warning restore 612, 618
        }
    }
}
