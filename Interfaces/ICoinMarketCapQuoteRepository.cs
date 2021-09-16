using System.Linq;
using System.Threading.Tasks;
using RepoWebAPI.Entities;
using RepoWebAPI.Objects;

namespace RepoWebAPI.Interfaces
{
    public interface ICoinMarketCapQuoteRepository
    {
        Task<string>  FetchFromApi(string symbol, string convert);
        Task<IQueryable<CoinMarketCapQuote>> GetAll();
        Task<CoinMarketCapQuote> Get(long id);
    }
}
