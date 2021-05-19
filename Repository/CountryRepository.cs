using System.Linq;
using System.Threading.Tasks;
using Paises.Models;
using Paises.Paging;

namespace Paises.Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(CountriesContext RepositoryContext) : base(RepositoryContext)
        {
        }

        public void CreateContries(Country country)
        {
            Create(country);
        }

        public void DeleteContries(Country country)
        {
            Delete(country);
        }

        public Task<PagedList<Country>> GetContries(PagingParameters pagingParameters)
        {
            return Task.FromResult(PagedList<Country>.GetPagedList(FindAll()
                                    .OrderBy(x => x.Name),pagingParameters.PageNumber,pagingParameters.PageSize));
        }

        public Country GetCountry(int id)
        {
            return FindCondition(e => e.Id == id).FirstOrDefault();
        }

        public void UpdateContries(Country country)
        {
            Update(country);
        }
    }

}