using System.Collections.Generic;
using Challenge.Domain.Models;

namespace Challenge.Domain.Repository
{
    public interface ICoberturaRepository
    {
        IEnumerable<Cobertura> ObterTodos();
        List<Cobertura> ObterPorIds(IEnumerable<string> ids);
    }
}