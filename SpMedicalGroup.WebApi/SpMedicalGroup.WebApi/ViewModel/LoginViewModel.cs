using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.ViewModel
{
    public class LoginViewModel : Pacientes
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
