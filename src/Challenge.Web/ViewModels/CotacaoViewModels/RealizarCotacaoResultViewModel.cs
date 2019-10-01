using System;
using System.ComponentModel.DataAnnotations;
using Challenge.Web.ViewModels.CommandResult;
using Newtonsoft.Json;

namespace Challenge.Web.ViewModels.CotacaoViewModels
{
    public class RealizarCotacaoResultViewModel : BaseResultViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public RespostaCotacaoViewModel Result { get; set; }
    }

    public class RespostaCotacaoViewModel
    {
        [Display(Name = "Prêmio")]
        public double Premio { get; set; }
        public int Parcelas { get; set; }

        [Display(Name = "Valor parcelas")]
        [JsonProperty("Valor_parcelas")]
        public double ValorParcelas { get; set; }

        [Display(Name = "Primeiro vencimento")]
        [JsonProperty("Primeiro_vencimento")]
        public DateTime PrimeiroVencimento { get; set; }

        [Display(Name = "Cobertura total")]
        [JsonProperty("Cobertura_total")]
        public double CoberturaTotal { get; set; }
    }
}