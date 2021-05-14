using HSPA_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSPA_WebApi.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCities();

       // Task<City> GetCityById(int cityId);

        void AddCity(City city);

        void DeleteCity(int cityId);

        Task<City> FindCity(int cityId);

    }
}
