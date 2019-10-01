using System.Collections.Generic;
using System.Linq;
using Challenge.Domain.Models;
using Challenge.Domain.Services;

namespace Challenge.Tests.Fakes
{
    public class FakeCoberturaService : ICoberturaService
    {
        public IEnumerable<Cobertura> ObterTodos()
        {
            return new List<Cobertura>
            {
                new Cobertura("01", "Morte Acidental", 100, 50000, 'S'),
                new Cobertura("02", "Quebra de Ossos", 30, 5000, 'N'),
                new Cobertura("03", "Internacao Hospitalar", 50, 10000, 'N'),
                new Cobertura("04", "Assistencia Funeraria", 10, 2500, 'N'),
                new Cobertura("05", "Invalidez Permanente", 130, 90000, 'S'),
                new Cobertura("06", "Assistencia Odontologia Emergencial", 10, 2500, 'N'),
                new Cobertura("07", "Diária Incapacidade Temporária", 30, 5000, 'N'),
                new Cobertura("08", "Invalidez Funcional", 80, 40000, 'S'),
                new Cobertura("09", "Doenças Graves", 100, 50000, 'N'),
                new Cobertura("10", "Diagnostico de Cancer", 50, 10000, 'N')
            };
        }

        public List<Cobertura> ObterPorIds(IEnumerable<string> ids)
        {
            return ObterTodos().Where(x => ids.Contains(x.Id)).ToList();
        }
    }
}