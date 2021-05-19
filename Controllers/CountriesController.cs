using Microsoft.AspNetCore.Mvc;
using Paises.Repository;
using Paises.Models;
using Paises.Paging;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Paises.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries([FromQuery] PagingParameters pagingParameters)
        {
            return await _countryRepository.GetContries(pagingParameters);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Country> GetCountry(int id)
        {
            var country = _countryRepository.GetCountry(id);
            if(country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        public ActionResult<Country> Create([FromBody] Country country)
        {
            if(country == null)
            {
                return BadRequest("Country cant by a null");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest("Model not valid, try again!");
            }
            _countryRepository.CreateContries(country);
            return Ok(CreatedAtRoute("CountryId", new {id = country.Id}, country));
        }

        [HttpPut("{id}")]
        public ActionResult<Country> UpdateCountry(int id,[FromBody] Country country)
        {
            if(country == null)
            {
                return BadRequest("Country cant by a null");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest("Model not valid, try again!");
            }
            
            var dbcountry = _countryRepository.GetCountry(id);

            if(!dbcountry.Id.Equals(id))
            {
                return NotFound();
            }
            _countryRepository.UpdateContries(country);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var dbcountry = _countryRepository.GetCountry(id);
            if(!dbcountry.Id.Equals(id))
            {
                return NotFound();
            }
            _countryRepository.DeleteContries(dbcountry);
            return NoContent();
        }

    }
    
}