using System.Linq;
using Challenge.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge.Tests.ValueObjects
{
    [TestClass]
    public class CepTests
    {
        private Cep _cepValido;
        private Cep _cepInvalido;

        public CepTests()
        {
            _cepValido = new Cep("13185-352");
            _cepInvalido = new Cep("13185352");
        }

        [TestMethod]
        public void NaoDeveRetornarNotificacaoQuandoCepEstaValido()
        {
            Assert.AreEqual(false, _cepValido.Invalid);
            Assert.AreEqual(false, _cepValido.Notifications.Any());
        }

        [TestMethod]
        public void DeveRetornarNotificacaoQuandoCepEstaInvalido()
        {
            Assert.AreEqual(true, _cepInvalido.Invalid);
            Assert.AreEqual(true, _cepInvalido.Notifications.Any());
        }
    }
}