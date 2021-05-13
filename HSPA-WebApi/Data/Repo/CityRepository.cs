using HSPA_WebApi.Interfaces;
using HSPA_WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSPA_WebApi.Data.Repo
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext _context;

        public CityRepository(DataContext context)
        {
            _context = context;
        }

        public void AddCity(City city)
        {
            _context.Cities.Add(city);
        }

        public void DeleteCity(int cityId)
        {
            var city = _context.Cities.Find(cityId);
            _context.Cities.Remove(city);
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _context.Cities.ToListAsync();
            
        }

        public async Task<City> GetCityById(int cityId)
        {
            return await _context.Cities.FindAsync(cityId);
        }
    }
}
