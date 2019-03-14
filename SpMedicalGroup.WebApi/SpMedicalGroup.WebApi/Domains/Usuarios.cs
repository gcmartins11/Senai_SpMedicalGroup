using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Medicos = new HashSet<Medicos>();
            Pacientes = new HashSet<Pacientes>();
        }

        public int Id { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Informe o email")]
        [DataType(DataType.EmailAddress, ErrorMessage ="O formato do email é inválido")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password, ErrorMessage = "O formato da senha é inválido")]
        public string Senha { get; set; }

        public int? IdCredencial { get; set; }

        public Credenciais IdCredencialNavigation { get; set; }
        public ICollection<Medicos> Medicos { get; set; }
        public ICollection<Pacientes> Pacientes { get; set; }
    }
}
