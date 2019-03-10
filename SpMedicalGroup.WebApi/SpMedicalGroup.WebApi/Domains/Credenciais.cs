using System;
using System.Collections.Generic;

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class Credenciais
    {
        public Credenciais()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Credencial { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
