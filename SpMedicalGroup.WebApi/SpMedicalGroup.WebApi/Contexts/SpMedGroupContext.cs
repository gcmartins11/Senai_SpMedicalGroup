using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class SpMedGroupContext : DbContext
    {
        public SpMedGroupContext()
        {
        }

        public SpMedGroupContext(DbContextOptions<SpMedGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinicas> Clinicas { get; set; }
        public virtual DbSet<Consultas> Consultas { get; set; }
        public virtual DbSet<Credenciais> Credenciais { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<StatusConsulta> StatusConsulta { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog= SPMEDICALGROUP_MANHA; USER ID = sa; Pwd = 132"); // USER ID = sa; Pwd = 132 // Integrated Security=True
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinicas>(entity =>
            {
                entity.ToTable("CLINICAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("BAIRRO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("CIDADE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("ESTADO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("LOGRADOURO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasColumnName("NOME_FANTASIA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Numero).HasColumnName("NUMERO");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasColumnName("RAZAO_SOCIAL")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consultas>(entity =>
            {
                entity.ToTable("CONSULTAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataConsulta)
                    .HasColumnName("DATA_CONSULTA")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasColumnType("text");

                entity.Property(e => e.HoraConsulta).HasColumnName("HORA_CONSULTA");

                entity.Property(e => e.IdMedico).HasColumnName("ID_MEDICO");

                entity.Property(e => e.IdPaciente).HasColumnName("ID_PACIENTE");

                entity.Property(e => e.StatusConsulta)
                    .HasColumnName("STATUS_CONSULTA")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__CONSULTAS__ID_ME__76969D2E");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__CONSULTAS__ID_PA__75A278F5");

                entity.HasOne(d => d.StatusConsultaNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.StatusConsulta)
                    .HasConstraintName("FK__CONSULTAS__STATU__778AC167");
            });

            modelBuilder.Entity<Credenciais>(entity =>
            {
                entity.ToTable("CREDENCIAIS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Credencial)
                    .IsRequired()
                    .HasColumnName("CREDENCIAL")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Especialidades>(entity =>
            {
                entity.ToTable("ESPECIALIDADES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Especialidade)
                    .IsRequired()
                    .HasColumnName("ESPECIALIDADE")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.ToTable("MEDICOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Crm)
                    .HasColumnName("CRM")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.IdClinica).HasColumnName("ID_CLINICA");

                entity.Property(e => e.IdEspecialidade).HasColumnName("ID_ESPECIALIDADE");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__MEDICOS__ID_CLIN__571DF1D5");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__MEDICOS__ID_ESPE__5629CD9C");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__MEDICOS__ID_USUA__5535A963");
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.ToTable("PACIENTES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("BAIRRO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("CIDADE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("DATA_NASCIMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("ESTADO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("LOGRADOURO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Numero).HasColumnName("NUMERO");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__PACIENTES__ID_US__5070F446");
            });

            modelBuilder.Entity<StatusConsulta>(entity =>
            {
                entity.ToTable("STATUS_CONSULTA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StatusConsulta1)
                    .HasColumnName("STATUS_CONSULTA")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdCredencial).HasColumnName("ID_CREDENCIAL");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCredencialNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdCredencial)
                    .HasConstraintName("FK__USUARIOS__ID_CRE__4D94879B");
            });
        }
    }
}
