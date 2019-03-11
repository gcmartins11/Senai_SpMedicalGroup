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
        public int? StatusConsulta { get; set; }
    }
}
