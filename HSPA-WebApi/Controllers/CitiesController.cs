
using AutoMapper;
using HSPA_WebApi.Data.Repo;
using HSPA_WebApi.Dtos;
using HSPA_WebApi.Interfaces;
using HSPA_WebApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HSPA_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CitiesController(IUnitOfWork uow,IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            //var cities = _context.Cities.ToList();
            var cities =await _uow.CityRepository.GetAllCities();

            var cityDto = _mapper.Map<IEnumerable<CityDto>>(cities);
            
            return Ok(cityDto);
        }

       /* [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var city = await _uow.CityRepository.GetCityById(id);
            var cityDto = _mapper.Map<CityDto>(city);

            return Ok(cityDto);
        }
       */


        [HttpPost]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            city.LastUpdatedOn = DateTime.Now;
            city.LastUpdatedBy = 1;

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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id,CityDto cityDto)
        {
            var cityFromDb =await _uow.CityRepository.FindCity(id);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;

            _mapper.Map(cityDto,cityFromDb);
            await _uow.SaveAsync();
            //return Ok(city);
            return StatusCode(200);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUpdateCity(int id, JsonPatchDocument<City> cityPatchDoc)
        {
            var cityFromDb = await _uow.CityRepository.FindCity(id);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;

            cityPatchDoc.ApplyTo(cityFromDb,ModelState);
            await _uow.SaveAsync();
            //return Ok(city);
            return StatusCode(200);
        }


    }
}
