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
                consultaUpdate.StatusConsulta = consulta.StatusConsulta;
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

        public List<ConsultasViewModel> Listar(int id)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {

                switch (id)
                {
                    //case 1:
                    //    return ctx.Consultas.ToList();

                    //case 2:

                    //    Pacientes paciente = ctx.Pacientes.ToList().First(p => p.IdUsuario == id);

                    //    List<Consultas> consultas = ctx.Consultas.Where(c => c.IdMedico == id).ToList();

                    //    List<ConsultasViewModel> consultasRetorno = new List<ConsultasViewModel>();

                    //    foreach (var consulta in consultas)
                    //    {
                    //        ConsultasViewModel consultaRetorno = new ConsultasViewModel
                    //        {
                    //            Id = consulta.Id,
                    //            Descricao = consulta.Descricao,
                    //            DataConsulta = consulta.DataConsulta,
                    //            HoraConsulta = consulta.HoraConsulta,
                    //            IdPaciente = consulta.IdPaciente,
                    //            NomePaciente = paciente.Nome,
                    //            IdMedico = consulta.IdMedico,
                    //            StatusConsulta = consulta.StatusConsulta
                    //        };

                    //        consultasRetorno.Add(consultaRetorno);
                    //    }

                    //    return consultasRetorno;


                    case 3:

                        Pacientes paciente = ctx.Pacientes.Where(p => p.IdUsuario == id);

                        List<Consultas> consultas = ctx.Consultas.Where(c => c.IdPaciente == id).ToList();

                        List<ConsultasViewModel> consultasRetorno = new List<ConsultasViewModel>();

                        foreach (var consulta in consultas)
                        {
                            ConsultasViewModel consultaRetorno = new ConsultasViewModel
                            {
                                Id = consulta.Id,
                                Descricao = consulta.Descricao,
                                DataConsulta = consulta.DataConsulta,
                                HoraConsulta = consulta.HoraConsulta,
                                IdPaciente = consulta.IdPaciente,
                                NomePaciente = paciente.Nome,
                                IdMedico = consulta.IdMedico,
                                StatusConsulta = consulta.StatusConsulta
                            };

                            consultasRetorno.Add(consultaRetorno);
                        }

                        return consultasRetorno;

                        // return ctx.Consultas.Where(c => c.IdPaciente == id).ToList();

                    default:
                        return null;
                }


            }
        }
    }
}
