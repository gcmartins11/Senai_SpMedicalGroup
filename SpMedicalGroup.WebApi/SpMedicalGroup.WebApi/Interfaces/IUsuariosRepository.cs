using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IUsuariosRepository
    {
        List<Usuarios> Listar();

        void Cadastrar(Usuarios usuario);
    }
}
