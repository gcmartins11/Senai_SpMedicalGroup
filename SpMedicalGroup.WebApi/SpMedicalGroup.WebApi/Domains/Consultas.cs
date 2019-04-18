using System;
using System.Collections.Generic;

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class Consultas
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataConsulta { get; set; }
        public TimeSpan HoraConsulta { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public int? IdStatus { get; set; }

        public Medicos IdMedicoNavigation { get; set; }
        public Pacientes IdPacienteNavigation { get; set; }
        public StatusConsulta IdStatusNavigation { get; set; }
    }
}
