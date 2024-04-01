namespace PIS.Service
{
    using PIS.Interface;
    using PIS.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public Task<List<City>> GetAllCity()
        {
            return _cityRepository.GetAllCity();
        }

        public Task<City> GetCityById(string id)
        {
            return _cityRepository.GetCityById(id);
        }

        public async Task<bool> AddCity(CityModel model)
        {
            await _cityRepository.AddCity(model.URL, model.CityName, model.CityDescription);
            return true;
        }

        public async Task<List<City>> GetAllCityByPartName(string partName)
        {
            return await _cityRepository.GetAllCityByName(partName);
        }

        public async Task DeleteCityByIdAsync(string id)
        {
            await _cityRepository.DeleteCityById(id);
        }

        public async Task<bool> UpdateCityAsync(CityModel model)
        {
            if (model.URL == null || model.CityName == null || model.CityDescription == null)
            {
                return false;
            }

            return await _cityRepository.UpdateCity(model);
        }
    }
}
