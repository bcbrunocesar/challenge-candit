using System.Collections.Generic;
using System.Threading.Tasks;
using Challenge.Domain.DTO;

namespace Challenge.Domain.Services
{
    public interface ICidadeService
    {
        Task<IEnumerable<City>> ObterTodasAsync();
    }
}