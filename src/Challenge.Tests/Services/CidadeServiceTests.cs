using System.Linq;
using System.Threading.Tasks;
using Challenge.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge.Tests.Services
{
    [TestClass]
    public class CidadeServiceTests
    {
        [TestMethod]
        public async Task DeveRetornarUmaListaDeCidades()
        {
            var cidadeService = new FakeCidadeService();
            var cidades = await cidadeService.ObterTodasAsync();

            Assert.IsTrue(cidades.Any());
        }
    }
}