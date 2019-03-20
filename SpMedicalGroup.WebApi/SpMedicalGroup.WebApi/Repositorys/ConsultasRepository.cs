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
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {

                switch (credencial)
                {
                    case "Paciente":
                        Usuarios usuario = ctx.Usuarios.Find(idUsuario);

                        List<Consultas> consultas = ctx.Consultas
                            .Where(c => c.IdPaciente == usuario.Id)
                            .Include(c => c.IdPacienteNavigation)
                            .Include(c => c.IdMedicoNavigation)
                            //.Include(c => c.StatusConsultaNavigation)
                            .ToList();

                        return consultas;

                    //case "Medico":
                    //    break;

                    //case "Administrador":
                    //    break;

                    default:
                        return null;
                }

            }
        }
    }
}
