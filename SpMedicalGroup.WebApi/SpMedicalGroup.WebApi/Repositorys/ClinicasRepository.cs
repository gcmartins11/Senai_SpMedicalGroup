using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Clinicas> Listar()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Clinicas.ToList();
            }
        }
    }
}
