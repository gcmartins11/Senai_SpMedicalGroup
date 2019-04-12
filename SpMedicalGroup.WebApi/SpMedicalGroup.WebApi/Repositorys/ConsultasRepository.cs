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
                        consultaUpdate.StatusConsulta = 1;
                        break;

                    case "Realizada":
                        consultaUpdate.StatusConsulta = 2;
                        break;

                    case "Cancelada":
                        consultaUpdate.StatusConsulta = 3;
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

        public List<Consultas> Listar(string credencial, int idUsuario)
        {
            string StringConexao = @"Data Source=.\SqlExpress; initial catalog=SPMEDICAlGROUP_MANHA; user id=sa; pwd = 132";

            

            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {

                switch (credencial)
                {

                    case "Paciente":

                        Pacientes pacienteProcurado = ctx.Pacientes.Where(p => p.IdUsuario == idUsuario).FirstOrDefault();

                        //List<Pacientes> pacienteProcurado = ctx.Pacientes.Where(c => c.IdUsuario == idUsuario).ToList();

                        List<Consultas> consultas = ctx.Consultas
                            .Where(c => c.IdPaciente == pacienteProcurado.Id)
                            //.Include(c => c.IdPacienteNavigation)
                            //.Where(c => 5 == usuario.Id)
                            //.Include(c => c.IdMedicoNavigation)
                            //.Include(c => c.StatusConsultaNavigation)
                            .ToList();

                        return consultas;

                    //case "Medico":
                    //    break;

                    case "Administrador":
                        List<Consultas> todasConsultas = ctx.Consultas.ToList();
                        return todasConsultas;

                    default:
                        return null;
                }

            }
        }
    }
}
