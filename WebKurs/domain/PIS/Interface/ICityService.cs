namespace PIS.Interface
{
    using PIS.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface ICityService
    {
        public Task<List<City>> GetAllCity();

        public Task<bool> AddCity(CityModel model);

        public Task<bool> UpdateCityAsync(CityModel model);

        public Task<List<City>> GetAllCityByPartName(string partName);

        public Task<City> GetCityById(string id);

        public Task DeleteCityByIdAsync(string id);
    }
}
