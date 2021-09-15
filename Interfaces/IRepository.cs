using System.Linq;

namespace RepoWebAPI.Interfaces
{
    public interface IRepository<T>
    {
        void FetchFromApi();
        IQueryable<T> Get();
        T Get(long id);
        // void AddToDb(); -> private method in Repository implementation

    }
}