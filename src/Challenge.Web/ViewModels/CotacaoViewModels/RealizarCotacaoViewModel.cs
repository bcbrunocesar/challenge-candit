using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Web.ViewModels.CotacaoViewModels
{
    public class RealizarCotacaoViewModel
    {
        [Display(Name = "Nome completo")]
        public string Nome { get; set; }

        [Display(Name="Data nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Nascimento { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public List<string> Coberturas { get; set; }
    }

    public class EnderecoViewModel
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
    }
}