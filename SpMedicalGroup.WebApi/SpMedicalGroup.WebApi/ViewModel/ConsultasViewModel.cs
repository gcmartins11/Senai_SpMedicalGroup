using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.ViewModel
{
    public class ConsultasViewModel
    {

        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime DataConsulta { get; set; }

        public TimeSpan HoraConsulta { get; set; }

        public int? IdPaciente { get; set; }

        public string NomePaciente { get; set; }

        public int? IdMedico { get; set; }

        public string NomeMedico { get; set; }
        public string Especialidade { get; set; }

        public int? IdStatusConsulta { get; set; }

        public string Status { get; set; }

    }
}
