using System;
using System.Collections.Generic;

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class StatusConsulta
    {
        public StatusConsulta()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        public string StatusConsulta1 { get; set; }

        public ICollection<Consultas> Consultas { get; set; }
    }
}
