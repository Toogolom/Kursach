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
        public List<City> GetAllCity();

        public bool AddCity(CityModel model);

        public bool UpdateCity(CityModel model);

        public List<City> GetAllCityByPartName(string partName);

        public City GetCityById(int id);

        public void DeleteCityById(int id);
    }
}
