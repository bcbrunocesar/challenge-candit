using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Challenge.Domain.Commands.CotacaoCommands.Input;
using Challenge.Domain.Handlers;
using Challenge.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge.Tests.Handlers
{
    [TestClass]
    public class CotacaoHandlerTests
    {
        [TestMethod]
        public async Task DeveRealizarCotacaoQuandoComandoForValido()
        {
            var command = new RealizarCotacaoCommand
            {
                Nome = "Bruno Farias",
                Nascimento = new DateTime(1991, 01, 15),
                Endereco = new EnderecoCommand
                {
                    Bairro = "Centro",
                    Cep = "13155-359",
                    Cidade = "Campinas",
                    Logradouro = "Av Moraes Sales, 1559"
                },
                Coberturas = new List<string>
                {
                    "01",
                    "05",
                    "08",
                    "09"
                }
            };

            var cotacaoHandler = new CotacaoHandler(new FakeCidadeService());
            var resultado = await cotacaoHandler.Handle(command);

            Assert.AreNotEqual(null, resultado);
            Assert.AreEqual(true, cotacaoHandler.Valid);
        }
    }
}