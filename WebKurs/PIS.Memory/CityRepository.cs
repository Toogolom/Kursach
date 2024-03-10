namespace PIS.Memory
{
    using PIS;
    using PIS.Interface;
    using System.Collections.Generic;

    public class CityRepository : ICityRepository
    {
        private readonly List<City> cities = new List<City>
        {
            new City(1, "Москва", "Столица России","https://sportishka.com/uploads/posts/2022-04/1650613027_1-sportishka-com-p-sovremennaya-moskva-krasivo-foto-1.jpg"),
            new City(2, "Саранск", "Столица Мордовии","https://24warez.ru/uploads/posts/2022-12/1671961550_02.jpg"),
            new City(3, "Санкт-Петербург", "Столица соли","https://travel-guide.su/wp-content/uploads/12-1-scaled.jpg")
        };

        public List<City> GetAllCity()
        {
            return cities;
        }

        public List<City> GetAllCityByName(string namePart)
        {
            return cities.Where(city => city.CityName.IndexOf(namePart, StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();
        }

        public City GetCityById(int id)
        {
            return (City)cities.Where(city => city.CityId.Equals(id));
        }
    }
}
