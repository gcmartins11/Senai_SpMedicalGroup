using Microsoft.EntityFrameworkCore;
using SpMedicalGroup.WebApi.Controllers;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using SpMedicalGroup.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public List<Consultas> Listar()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {

                if (LoginController.usuarioLogado == null)
                {
                    return null;
                }

                switch (LoginController.usuarioLogado.IdCredencial)
                {
                    case 1:
                        return ctx.Consultas.ToList();

                    case 2:
                        return ctx.Consultas.Where(c => c.IdMedico == LoginController.usuarioLogado.Id).ToList();

                    case 3:
                        return ctx.Consultas.Where(c => c.IdPaciente == LoginController.usuarioLogado.Id).ToList();

                    default:
                        return null;
                }


            }
        }
    }
}
