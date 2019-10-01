using System;
using System.Collections.Generic;
using System.Linq;
using Challenge.Domain.Models;
using Challenge.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge.Tests.Models
{
    [TestClass]
    public class CotacaoTests
    {
        private readonly Endereco _enderecoValido;
        private readonly Nome _nomeValido;
        private readonly DateTime _dataAniversarioValida;

        private readonly List<Cobertura> _maximoDeCoberturasValidas;
        private readonly List<Cobertura> _minimoDeCoberturasValidas;
        private readonly List<Cobertura> _maximoDeCoberturasInvalidas;
        private readonly List<Cobertura> _minimoDeCoberturasInvalidas;

        public CotacaoTests()
        {
            var cep = new Cep("13185-352");
            _enderecoValido = new Endereco("Rua nove", "Jardim Adelaide", cep, "Campinas");

            _dataAniversarioValida = new DateTime(1991, 1, 15);
            _nomeValido = new Nome("Bruno César Farias");

            _minimoDeCoberturasInvalidas = new List<Cobertura>();
            _minimoDeCoberturasValidas = new List<Cobertura>
            {
                new Cobertura("01", "Cob1", 100d, 50000d, 'S'),
            };

            _maximoDeCoberturasValidas = new List<Cobertura>
            {
                new Cobertura("01", "Cob1", 100d, 50000d, 'S'),
                new Cobertura("05", "Cob2", 130d, 90000d, 'S'),
                new Cobertura("08", "Cob3", 80d, 40000d, 'S'),
                new Cobertura("09", "Cob3", 100d, 50000d, 'S')
            };

            _maximoDeCoberturasInvalidas = new List<Cobertura>
            {
                new Cobertura("01", "Cob1", 100d, 50000d, 'S'),
                new Cobertura("05", "Cob2", 130d, 90000d, 'S'),
                new Cobertura("08", "Cob3", 80d, 40000d, 'S'),
                new Cobertura("09", "Cob3", 100d, 50000d, 'S'),
                new Cobertura("10", "Cob5", 50d, 10000d, 'N')
            };
        }

        [TestMethod]
        public void ContratanteNaoPodePossuirMenosQueDezoitoAnos()
        {
            var cotacao = new Cotacao(_nomeValido, new DateTime(2001, 12, 01), _enderecoValido, _maximoDeCoberturasValidas);
            Assert.IsTrue(cotacao.Notifications.Any());
        }

        [TestMethod]
        public void CotacaoNaoPodePossuirMaisDoQueQuatroCoberturas()
        {
            var cotacao = new Cotacao(_nomeValido, _dataAniversarioValida, _enderecoValido, _maximoDeCoberturasInvalidas);
            Assert.IsTrue(cotacao.Notifications.Any());
        }

        [TestMethod]
        public void CotacaoNaoPodePossuirMenosDoQueUmaCobertura()
        {
            var cotacao = new Cotacao(_nomeValido, _dataAniversarioValida, _enderecoValido, _minimoDeCoberturasInvalidas);
            Assert.IsTrue(cotacao.Invalid);
        }

        [TestMethod]
        public void DeveAplicarQuarentaPorcentoDeAcrescimoQuandoIdadeForVinteECinco()
        {
            var cotacao = new Cotacao(_nomeValido, new DateTime(1994, 09, 29), _enderecoValido, _maximoDeCoberturasValidas);
            var percentualAcrescimo = cotacao.PercentualAcrescimo();
            Assert.AreEqual(40d, percentualAcrescimo);
        }

        [TestMethod]
        public void DeveConcederDezesseisPorcentoDeDescontoQuandoIdadeForTrintaEOito()
        {
            var cotacao = new Cotacao(_nomeValido, new DateTime(1981, 09, 29), _enderecoValido, _maximoDeCoberturasValidas);
            var percentualDesconto = cotacao.PercentualDesconto();
            Assert.AreEqual(16d, percentualDesconto);
        }

        [TestMethod]
        public void DeveConcederTrintaPorcentoDeDescontoQuandoIdadeForMaiorQueQuarentECinto()
        {
            var cotacao = new Cotacao(_nomeValido, new DateTime(1969, 09, 29), _enderecoValido, _maximoDeCoberturasValidas);
            var percentualDesconto = cotacao.PercentualDesconto();
            Assert.AreEqual(30d, percentualDesconto);
        }

        [TestMethod]
        public void CotacaoDevePossuirDuasParcelasQuandoPremioForMaiorQueQuinhentos()
        {
            var cotacao = new Cotacao(_nomeValido, new DateTime(2001, 09, 01), _enderecoValido, _maximoDeCoberturasValidas);
            var quantidadeParcelas = cotacao.Parcelas();
            Assert.AreEqual(2, quantidadeParcelas);
        }

        [TestMethod]
        public void PrimeiroVencimentoDeveSerDiaSeteDeOutubroQuandoMesDaCotacaoForSetembroDeDoisMilEDezenove()
        {
            var cotacao = new Cotacao(_nomeValido, new DateTime(2001, 09, 01), _enderecoValido, _maximoDeCoberturasValidas);
            var primeiroVencimento = cotacao.PrimeiroVencimento();
            Assert.AreEqual(new DateTime(2019, 10, 7), primeiroVencimento);
        }
    }
}
 