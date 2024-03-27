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

        public List<City> GetAllCity()
        {
            return _cityRepository.GetAllCity();
        }

        public City GetCityById(int id)
        {
            return _cityRepository.GetCityById(id);
        }

        public bool AddCity(CityModel model)
        {
            _cityRepository.AddCity(model.URL,model.CityName,model.CityDescription);
            return true;
        }

        public List<City> GetAllCityByPartName(string partName)
        {
            return _cityRepository.GetAllCityByName(partName);
        }

        public void DeleteCityById(int id)
        {
            _cityRepository.DeleteCityById(id);
        }

        public bool UpdateCity(CityModel model)
        {
            if (model.URL == null || model.CityName == null || model.CityDescription == null)
            {
                return false;
            }

            City city = _cityRepository.GetCityById(model.CityId);

            city.PhotoUrl = model.URL;
            city.CityName = model.CityName;
            city.CityDescription = model.CityDescription;

            return true;
        }
    }
}
