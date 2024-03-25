namespace PIS.Interface
{
    public interface ICityRepository
    {
        public List<City> GetAllCity();

        public City GetCityById(int id);

        public void AddCity(string Url, string name, string descriprion);

        public List<City> GetAllCityByName(string namePart);

        public void DeleteCityById(int id);
    }
}
