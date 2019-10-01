using System;
using Challenge.Domain.Interfaces;

namespace Challenge.Domain.Commands.CotacaoCommands.Output
{
    public class RealizarCotacaoCommandResult : ICommandResult
    {
        public RealizarCotacaoCommandResult(double premio, int parcelas, double valorParcelas, DateTime primeiroVencimento, double coberturaTotal)
        {
            Premio = premio;
            Parcelas = parcelas;
            Valor_parcelas = valorParcelas;
            Primeiro_vencimento = primeiroVencimento;
            Cobertura_total = coberturaTotal;
        }

        public double Premio { get; private set; }
        public int Parcelas { get; private set; }
        public double Valor_parcelas { get; private set; }
        public DateTime Primeiro_vencimento { get; private set; }
        public double Cobertura_total { get; private set; }
    }
}