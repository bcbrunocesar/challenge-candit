using System;
using System.Net.Http;

namespace Challenge.Web.Services
{
    public class CotacaoApi
    {
        public HttpClient Inicializar()
        {
            var client = new HttpClient {BaseAddress = new Uri("http://localhost:65026")};
            return client;
        }   
    }
}