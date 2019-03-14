using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class Consultas
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        // [DataType(DataType.Date)]
        [Required(ErrorMessage = "Informe a data")]
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage = "Informe a hora")]
        public TimeSpan HoraConsulta { get; set; }

        [Required(ErrorMessage = "Informe o id do paciente")]
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "Informe o id do médico")]
        public int? IdMedico { get; set; }

        public int? StatusConsulta { get; set; }

        public Medicos IdMedicoNavigation { get; set; }
        public Pacientes IdPacienteNavigation { get; set; }
        public StatusConsulta StatusConsultaNavigation { get; set; }
    }
}
