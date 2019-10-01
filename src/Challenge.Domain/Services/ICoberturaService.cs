using System.Collections.Generic;
using Challenge.Domain.Models;

namespace Challenge.Domain.Services
{
    public interface ICoberturaService
    {
        IEnumerable<Cobertura> ObterTodos();
        List<Cobertura> ObterPorIds(IEnumerable<string> ids);
    }
}