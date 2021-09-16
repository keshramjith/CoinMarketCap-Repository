using System.Linq;
using System.Threading.Tasks;
using RepoWebAPI.Entities;

namespace RepoWebAPI.Interfaces
{
    public interface ICoinMarketCapQuoteRepository
    {
        Task<string>  FetchFromApi(string symbol, string convert);
        IQueryable<CoinMarketCapQuote> GetAll();
        IQueryable<CoinMarketCapQuote> Get(string symbol);
    }
}
