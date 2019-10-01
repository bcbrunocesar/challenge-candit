using System.Collections.Generic;
using System.Threading.Tasks;
using Challenge.Domain.Commands.CotacaoCommands.Input;
using Challenge.Domain.Commands.CotacaoCommands.Output;
using Challenge.Domain.DTO;
using Challenge.Domain.Handlers;
using Challenge.Domain.Interfaces;
using Challenge.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Api.Controllers
{
    public class CotacaoController : Controller
    {
        private readonly ICidadeService _cidadeService;
        private readonly CotacaoHandler _cotacaoHandler;

        public CotacaoController(CotacaoHandler cotacaoHandler, ICidadeService cidadeService)
        {
            _cotacaoHandler = cotacaoHandler;
            _cidadeService = cidadeService;
        }

        [HttpGet]
        [Route("v1/cities")]
        public async Task<IEnumerable<City>> GetCities()
        {
            return await _cidadeService.ObterTodasAsync();
        }

        [HttpPost]
        [Route("v1/price")]
        public async Task<ICommandResult> Post([FromBody] RealizarCotacaoCommand command) 
        {
            var result = (CommandResult) await _cotacaoHandler.Handle(command);
            return result;
        }
    }
}