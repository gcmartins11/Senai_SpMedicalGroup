using System;
using System.Collections.Generic;

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class Especialidades
    {
        public Especialidades()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        public string Especialidade { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
