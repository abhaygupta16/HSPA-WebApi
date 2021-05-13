using HSPA_WebApi.Data;
using HSPA_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSPA_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly DataContext _context;
        public CitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCities()
        {
            var cities = _context.Cities.ToList();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            var city = _context.Cities.SingleOrDefault(c =>c.Id==id);
            return Ok(city);
        }

        [HttpPost]
        public IActionResult AddCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
            return Ok(city);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var city = _context.Cities.SingleOrDefault(c => c.Id == id);
            _context.Cities.Remove(city);
            _context.SaveChanges();
            return Ok(id);
        }
    }
}
