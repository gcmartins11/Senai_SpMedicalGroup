using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IClinicasRepository
    {
        List<Clinicas> Listar();

        List<Clinicas> ListarComMedicos();

        Clinicas GetById(int id);

        void Cadastrar(Clinicas clinica);

        void Atualizar(Clinicas clinica);
    }
}
