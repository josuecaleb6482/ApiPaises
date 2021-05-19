using System.Threading.Tasks;
using Paises.Models;
using Paises.Paging;

namespace Paises.Repository
{
    public interface ICountryRepository : IRepositoryBase<Country>
    {
        Task<PagedList<Country>> GetContries(PagingParameters pagingParameters);
        Country GetCountry(int id);
        void CreateContries(Country country);
        void UpdateContries(Country country);
        void DeleteContries(Country country);
        
    }
}