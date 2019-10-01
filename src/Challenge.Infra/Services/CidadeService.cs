using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Challenge.Domain.DTO;
using Challenge.Domain.Services;
using Newtonsoft.Json;

namespace Challenge.Infra.Services
{
    public class CidadeService : ICidadeService
    {
        public async Task<IEnumerable<City>> ObterTodasAsync()
        {
            var cidades = new RootObject();
            using (var httpCliente = new HttpClient())
            {
                using (var resposta = await httpCliente.GetAsync("https://www.redesocialdecidades.org.br/cities"))
                {
                    if (!resposta.IsSuccessStatusCode) return cidades.Cities;
                    var respostaApi = await resposta.Content.ReadAsStringAsync();
                    cidades = JsonConvert.DeserializeObject<RootObject>(respostaApi);
                }
            }

            return cidades.Cities;
        }
    }
}