using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge.Domain.DTO;
using Challenge.Domain.Models;
using Challenge.Domain.Services;

namespace Challenge.Tests.Fakes
{
    public class FakeCidadeService : ICidadeService
    {
        public Task<IEnumerable<City>> ObterTodasAsync()
        {
            var cities = new List<City>
            {
                new City{Name = "Campinas"},
                new City{Name = "Cajamar"},
                new City{Name = "Ilhabela"},
                new City{Name = "São Paulo"}
            };

            return Task.FromResult(cities.AsEnumerable());
        }
    }
}