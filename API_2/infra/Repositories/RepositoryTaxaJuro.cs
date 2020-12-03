using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace infra.Repositories
{
    public class RepositoryTaxaJuros: IRepositoryTaxaJuros
    {
        public async Task<decimal> RetornarTaxaJurosAsync()
        {
            string json = await Get("https://localhost:44385/taxaJuros");
            decimal retorno = JsonConvert.DeserializeObject<decimal>(json); 
            return retorno;
        }

        private async Task<string> Get(string caminho)
        {
            try
            {
                HttpClient requisicao = new HttpClient();
                HttpResponseMessage resposta = requisicao.GetAsync(caminho).GetAwaiter().GetResult();
                if (resposta.StatusCode == HttpStatusCode.OK)
                {
                    var conteudo = await resposta.Content.ReadAsStringAsync();
                    return conteudo;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
