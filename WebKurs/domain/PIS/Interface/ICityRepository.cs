using PIS.Models;

namespace PIS.Interface
{
    public interface ICityRepository
    {
        public Task<List<City>> GetAllCity();

        public Task<City> GetCityById(string id);

        public Task AddCity(string Url, string name, string descriprion);

        public Task<bool> UpdateCity(CityModel model);

        public Task<List<City>> GetAllCityByName(string namePart);

        public Task DeleteCityById(string id);
    }
}
