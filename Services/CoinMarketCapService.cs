using System.Threading.Tasks;
using System.Net.Http;

namespace Services
{
    public interface ICoinMarketCapService
    {
        Task<string> Get(string symbol, string convert);
    }
    
    public class CoinMarketCapService : ICoinMarketCapService
    {
        private readonly HttpClient _httpClient;

        public CoinMarketCapService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Get(string symbol, string convert)
        {
            var URL = $"?symbol={symbol}&convert={convert}";
            var response = await _httpClient.GetAsync(URL);
            return await response.Content.ReadAsStringAsync();
        }
    }
}