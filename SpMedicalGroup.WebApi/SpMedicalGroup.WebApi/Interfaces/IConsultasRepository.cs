using SpMedicalGroup.WebApi.Controllers;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IConsultasRepository
    {
        List<ConsultasViewModel> Listar(string credencial, int idUsuario);

        void Cadastrar(Consultas consulta);

        void AtualizarStatus(ConsultasViewModel consulta);

        void AtualizarDescricao(ConsultasViewModel consulta);
    }
}
