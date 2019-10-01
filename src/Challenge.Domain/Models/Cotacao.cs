using System;
using System.Collections.Generic;
using System.Linq;
using Challenge.Domain.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace Challenge.Domain.Models
{
    public sealed class Cotacao : Notifiable
    {
        private readonly List<Cobertura> _coberturas;

        public Cotacao(Nome nome, DateTime dataNascimento, Endereco endereco, List<Cobertura> coberturas)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            _coberturas = coberturas ?? new List<Cobertura>();

            AddNotifications(new Contract()
                .IsLowerOrEqualsThan(18, Idade(), "DataNascimento", "Não é permitido contratante menor de 18 anos.")

                .AreEquals(true, Coberturas.Any(), "Coberturas", "É necessário que exista ao menos uma cobertura para realizar a cotação.")
                .AreEquals(false, ValidarCobertura(), "Coberturas", "Não é permitido inserir a mesma cobertura mais de uma vez na mesma cotação.")
                .IsGreaterThan(5, Coberturas.Count, "Coberturas", "Pode existir no máximo 04 coberturas na cotação.")
            );
        }

        public Nome Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Endereco Endereco { get; private set; }
        public IReadOnlyCollection<Cobertura> Coberturas => _coberturas;

        #region VALIDAÇÃO

        private int Idade()
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - DataNascimento.Year;
            if (hoje.Month < DataNascimento.Month || hoje.Month == DataNascimento.Month && hoje.Day < DataNascimento.Day)
                idade--;

            return idade;
        }

        private bool ValidarCobertura()
        {
            return Coberturas.GroupBy(g => g.Id).Any(x => x.Count() > 1);
        }

        #endregion

        #region MÉTODOS

        public double TotalCobertura() => Coberturas.Any() ? Coberturas.Sum(x => x.Valor) : 0d;

        public double SubTotal() => Coberturas.Any() ? Coberturas.Sum(x => x.Premio) : 0d;

        public double PercentualAcrescimo()
        {
            var idade = Idade();
            return idade >= 18 && idade < 31
                ? (30 - idade) * 8
                : 0d;
        }

        public double PercentualDesconto()
        {
            var idade = Idade();
            if (idade > 45) return (45 - 30) * 2;
            return idade > 30
                ? (idade - 30) * 2
                : 0d;
        }

        public double Premio()
        {
            var idade = Idade();
            var subtotal = SubTotal();

            if (idade >= 18 && idade < 31) return subtotal + (subtotal * PercentualAcrescimo() / 100);
            if (idade > 30) return subtotal - (subtotal * PercentualDesconto() / 100);

            return 0d;
        }

        public int Parcelas()
        {
            var valorPremio = Premio();
            int quantidadeParcelas;

            if (valorPremio < 501) quantidadeParcelas = 1;
            else if (valorPremio >= 501 && valorPremio < 1001) quantidadeParcelas = 2;
            else if (valorPremio >= 1001 && valorPremio <= 2000) quantidadeParcelas = 3;
            else quantidadeParcelas = 4;

            return quantidadeParcelas;
        }

        public double ValorParcelas() => Premio() / Parcelas();

        public DateTime PrimeiroVencimento()
        {
            var dataAtual = DateTime.UtcNow;
            var dataPrimeiroVencimento = new DateTime(dataAtual.Year, dataAtual.Month, DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month));
            var diaUtil = 0;

            do
            {
                dataPrimeiroVencimento = dataPrimeiroVencimento.AddDays(1);

                if (dataPrimeiroVencimento.DayOfWeek != DayOfWeek.Saturday && dataPrimeiroVencimento.DayOfWeek != DayOfWeek.Sunday)
                    diaUtil++;
                
            } while (diaUtil != 5);

            return dataPrimeiroVencimento;
        }

        public override string ToString()
        {
            return Nome.ToString();
        }

        #endregion
    }
}