using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class Clinicas
    {
        public Clinicas()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a razão social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Informe o nome fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Informe o cnpj")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o numero")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Informe o bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o estado")]
        public string Estado { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
