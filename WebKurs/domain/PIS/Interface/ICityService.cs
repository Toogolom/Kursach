namespace PIS.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface ICityService
    {
        public List<City> GetAllCity();

        public void AddCity(string Url, string name, string descriprion);

        public List<City> GetAllCityByPartName(string partName);

        public City GetCityById(int id);

        public void DeleteCityById(int id);
    }
}
