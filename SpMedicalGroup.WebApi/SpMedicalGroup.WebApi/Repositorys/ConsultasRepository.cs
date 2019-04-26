using System;
using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using SpMedicalGroup.WebApi.Controllers;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using SpMedicalGroup.WebApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace SpMedicalGroup.WebApi.Repositorys
{
    public class ConsultasRepository : IConsultasRepository
    {
        public void AtualizarDescricao(ConsultasViewModel consulta)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                Consultas consultaUpdate = ctx.Consultas.Find(consulta.Id);
                consultaUpdate.Descricao = consulta.Descricao;
                ctx.SaveChanges();
            }
        }

        public void AtualizarStatus(ConsultasViewModel consulta)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                Consultas consultaUpdate = ctx.Consultas.Find(consulta.Id);

                switch (consulta.Status)
                {
                    case "Agendada":
                        consultaUpdate.IdStatus = 1;
                        break;

                    case "Realizada":
                        consultaUpdate.IdStatus = 2;
                        break;

                    case "Cancelada":
                        consultaUpdate.IdStatus = 3;
                        break;  

                    default:
                        break;
                }

                ctx.SaveChanges();

            }
        }

        public void Cadastrar(Consultas consulta)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Consultas.Add(consulta);
                ctx.SaveChanges();
            }
        }

        public List<ConsultasViewModel> Listar(string credencial, int idUsuario)
        {

            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                List<ConsultasViewModel> consultasRetorno = new List<ConsultasViewModel>();


                switch (credencial)
                {

                    case "Paciente":

                        Pacientes pacienteProcurado = ctx.Pacientes.Where(p => p.IdUsuario == idUsuario).FirstOrDefault();

                        List<Consultas> consultasPaciente = ctx.Consultas
                            .Where(c => c.IdPaciente == pacienteProcurado.Id)
                            .Include(c => c.IdMedicoNavigation)
                            .Include(c => c.IdStatusNavigation)
                            .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)
                            .ToList();

                        foreach (var consulta in consultasPaciente)
                        {
                            ConsultasViewModel consultaRetorno = new ConsultasViewModel()
                            {
                                Id = consulta.Id,
                                DataConsulta = consulta.DataConsulta,
                                HoraConsulta = consulta.HoraConsulta,
                                IdPaciente = consulta.IdPaciente,
                                NomePaciente = consulta.IdPacienteNavigation.Nome,
                                IdMedico = consulta.IdMedico,
                                NomeMedico = consulta.IdMedicoNavigation.Nome,
                                Especialidade = consulta.IdMedicoNavigation.IdEspecialidadeNavigation.Especialidade,
                                Descricao = consulta.Descricao,
                                IdStatusConsulta = consulta.IdStatus,
                                Status = consulta.IdStatusNavigation.Situacao
                            };
                            consultasRetorno.Add(consultaRetorno);
                        }

                        return consultasRetorno;

                    case "Medico":

                        Medicos medicoProcurado = ctx.Medicos.Where(m => m.IdUsuario == idUsuario).FirstOrDefault();

                        List<Consultas> consultasMedico = ctx.Consultas
                        .Where(m => m.IdMedico == medicoProcurado.Id)
                        .Include(m => m.IdPacienteNavigation)
                        .Include(m => m.IdStatusNavigation)
                        .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)
                        .ToList();

                        foreach (var consulta in consultasMedico)
                        {
                            ConsultasViewModel consultaRetorno = new ConsultasViewModel()
                            {
                                Id = consulta.Id,
                                DataConsulta = consulta.DataConsulta,
                                HoraConsulta = consulta.HoraConsulta,
                                IdPaciente = consulta.IdPaciente,
                                NomePaciente = consulta.IdPacienteNavigation.Nome,
                                IdMedico = consulta.IdMedico,
                                NomeMedico = consulta.IdMedicoNavigation.Nome,
                                Especialidade = consulta.IdMedicoNavigation.IdEspecialidadeNavigation.Especialidade,
                                Descricao = consulta.Descricao,
                                IdStatusConsulta = consulta.IdStatus,
                                Status = consulta.IdStatusNavigation.Situacao
                            };
                            consultasRetorno.Add(consultaRetorno);
                        }

                        return consultasRetorno;


                    case "Administrador":

                        List<Consultas> todasConsultas = ctx.Consultas
                            .Include(p => p.IdPacienteNavigation)
                            .Include(m => m.IdMedicoNavigation)
                            .Include(m => m.IdStatusNavigation) //.ThenInclude(situacao => situacao.Situacao)
                            .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)
                            .ToList();

                        foreach (var consulta in todasConsultas)
                        {
                            ConsultasViewModel consultaRetorno = new ConsultasViewModel()
                            {
                                Id = consulta.Id,
                                DataConsulta = consulta.DataConsulta,
                                HoraConsulta = consulta.HoraConsulta,
                                IdPaciente = consulta.IdPaciente,
                                NomePaciente = consulta.IdPacienteNavigation.Nome,
                                IdMedico = consulta.IdMedico,
                                NomeMedico = consulta.IdMedicoNavigation.Nome,
                                Especialidade = consulta.IdMedicoNavigation.IdEspecialidadeNavigation.Especialidade,
                                Descricao = consulta.Descricao,
                                IdStatusConsulta = consulta.IdStatus,
                                Status = consulta.IdStatusNavigation.Situacao
                            };
                            consultasRetorno.Add(consultaRetorno);
                        }

                        return consultasRetorno;

                    default:
                        return null;
                }

            }
        }
    }
}
