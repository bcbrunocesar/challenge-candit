using System.Collections.Generic;
using System.Linq;

namespace Challenge.Domain.Models
{
    public sealed class Cobertura
    {
        public Cobertura(string id, string nome, double premio, double valor, char principal)
        {
            Id = id;
            Nome = nome;
            Premio = premio;
            Valor = valor;
            Principal = principal;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public double Premio { get; private set; }
        public double Valor { get; private set; }
        public char Principal { get; private set; }

        private static IEnumerable<Cobertura> ObterCoberturas()
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

        public static List<Cobertura> ObterCoberturasPorId(IEnumerable<string> ids)
        {
            var coberturas = ObterCoberturas();
            return coberturas.Where(x => ids.Contains(x.Id)).ToList();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}