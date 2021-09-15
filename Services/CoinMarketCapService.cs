using System.Threading.Tasks;
using System.Net.Http;

namespace Services
{
    public interface ICoinMarketCapService
    {
        Task<string> Get(string symbol);
    }
    
    public class CoinMarketCapService : ICoinMarketCapService
    {
        private readonly HttpClient _httpClient;

        public CoinMarketCapService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Get(string symbol)
        {
            var URL = $"?symbol={symbol}";
            var response = await _httpClient.GetAsync(URL);
            return await response.Content.ReadAsStringAsync();
        }
    }
}