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

        Usuarios GetById(int id);

        void Cadastrar(Usuarios usuario);

        Usuarios BuscarEmailSenha(string email, string senha);
    }
}
