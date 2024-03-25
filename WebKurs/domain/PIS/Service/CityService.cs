namespace PIS.Service
{
    using PIS.Interface;
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

        public void AddCity(string Url, string name, string descriprion)
        {
            _cityRepository.AddCity(Url,name,descriprion);
        }

        public List<City> GetAllCityByPartName(string partName)
        {
            return _cityRepository.GetAllCityByName(partName);
        }

        public void DeleteCityById(int id)
        {
            _cityRepository.DeleteCityById(id);
        }
    }
}
