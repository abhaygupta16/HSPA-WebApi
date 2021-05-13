
using HSPA_WebApi.Data.Repo;
using HSPA_WebApi.Interfaces;
using HSPA_WebApi.Models;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace HSPA_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public CitiesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            //var cities = _context.Cities.ToList();
            var cities =await _uow.CityRepository.GetAllCities();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var city = await _uow.CityRepository.GetCityById(id);
            return Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(City city)
        {
            _uow.CityRepository.AddCity(city);
            await _uow.SaveAsync();
            //return Ok(city);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            _uow.CityRepository.DeleteCity(id);
            await _uow.SaveAsync();
            return NoContent();
        }
    }
}
