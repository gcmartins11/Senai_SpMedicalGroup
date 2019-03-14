using Microsoft.EntityFrameworkCore;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositorys
{
    public class ClinicasRepository : IClinicasRepository
    {

        public void Atualizar(Clinicas clinica)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Clinicas.Update(clinica);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Clinicas clinica)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Clinicas.Add(clinica);
                ctx.SaveChanges();
            }
        }

        public Clinicas GetById(int id)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Clinicas.Find(id);
            }
        }

        public List<Clinicas> Listar()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Clinicas.ToList();
            }
        }

        public List<Clinicas> ListarComMedicos()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Clinicas.Include(x => x.Medicos).ToList();
            }
        }
    }
}
