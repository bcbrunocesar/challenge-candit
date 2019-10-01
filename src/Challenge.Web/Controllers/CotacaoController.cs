using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Challenge.Domain.Repository;
using Challenge.Web.Services;
using Challenge.Web.ViewModels.CommandResult;
using Challenge.Web.ViewModels.CotacaoViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Challenge.Web.Controllers
{
    [Route("cotacoes")]
    public class CotacaoController : Controller
    {
        private readonly CotacaoApi _cotacaoApi;
        private readonly ICoberturaRepository _coberturaRepository;

        public CotacaoController(CotacaoApi cotacaoApi, ICoberturaRepository coberturaRepository)
        {
            _cotacaoApi = cotacaoApi;
            _coberturaRepository = coberturaRepository;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Coberturas = new SelectList(_coberturaRepository.ObterTodos(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Index(RealizarCotacaoViewModel viewModel)
        {
            var jsonString = JsonConvert.SerializeObject(viewModel);

            try
            {
                RealizarCotacaoResultViewModel resultado;
                using (var httpCliente = _cotacaoApi.Inicializar())
                {
                    using (var resposta = await httpCliente.PostAsync("v1/price", new StringContent(jsonString, Encoding.UTF8, "application/json")))
                    {
                        if (!resposta.IsSuccessStatusCode) return BadRequest();
                        var respostaApi = await resposta.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<RealizarCotacaoResultViewModel>(respostaApi);
                    }
                }

                return resultado.Success 
                    ? PartialView("_ResultPartial", resultado)
                    : PartialView("_NotificationsPartial", resultado);
            }
            catch (Exception errno)
            {
                Console.WriteLine(errno.Message);
            }

            var retornoErro = new RealizarCotacaoResultViewModel
            {
                Success = false,
                Message = "Não foi possível acesar o serviço!",
                Result = null,
                Notifications = new List<NotificationViewModel>
                {
                    new NotificationViewModel {Property = "Service", Message = "Ocorreu um erro ao acessar o serviço."}
                }
            };

            return PartialView("_NotificationsPartial", retornoErro);
        }
    }
}