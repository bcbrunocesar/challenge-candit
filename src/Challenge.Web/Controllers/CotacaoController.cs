using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Challenge.Web.Services;
using Challenge.Web.ViewModels.CotacaoViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Challenge.Web.Controllers
{
    [Route("cotacoes")]
    public class CotacaoController : Controller
    {
        private readonly CotacaoApi _cotacaoApi;

        public CotacaoController(CotacaoApi cotacaoApi)
        {
            _cotacaoApi = cotacaoApi;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Index(RealizarCotacaoViewModel viewModel)
        {
            viewModel.Coberturas = new List<string> {"01", "03", "05"};

            RealizarCotacaoResultViewModel resultado;
            var jsonString = JsonConvert.SerializeObject(viewModel);

            try
            {
                using (var httpCliente = _cotacaoApi.Inicializar())
                {
                    using (var resposta = await httpCliente.PostAsync("v1/price", new StringContent(jsonString, Encoding.UTF8, "application/json")))
                    {
                        if (!resposta.IsSuccessStatusCode) return BadRequest();
                        var respostaApi = await resposta.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<RealizarCotacaoResultViewModel>(respostaApi);
                    }
                }

                return PartialView("_ResultPartial", resultado);
            }
            catch (Exception errno)
            {
                Console.WriteLine(errno.Message);
            }

            return RedirectToAction("Index");
        }
    }
}