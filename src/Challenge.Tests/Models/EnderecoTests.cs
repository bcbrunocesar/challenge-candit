using System.Linq;
using System.Threading.Tasks;
using Challenge.Domain.Models;
using Challenge.Domain.ValueObjects;
using Challenge.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge.Tests.Models
{
    [TestClass]
    public class EnderecoTests
    {
        private const string CidadeValida = "Campinas";
        private const string CidadeInvalida = "Hortolândia";
        
        private readonly Cep _cepValido;
        private readonly FakeCidadeService _fakeCidadeService;

        public EnderecoTests()
        {
            _cepValido = new Cep("13500-200");
            _fakeCidadeService = new FakeCidadeService();
        }

        [TestMethod]
        public async Task DeveRetornarErroQuandoCidadeNaoExisteNoServico()
        {
            var endereco = new Endereco("Av emancipação", "Jardim do bosque", _cepValido, CidadeInvalida);
            var cidadesAceitasPeloServico = (await _fakeCidadeService.ObterTodasAsync()).Select(x => x.Name);
            endereco.VerificaSeCidadeExiste(cidadesAceitasPeloServico);
            Assert.AreEqual(true, endereco.Invalid);
        }
    }
}