namespace PIS.Repository
{
    public interface ICityRepository
    {
        public List<City> GetAllCity();

        public City GetCityById(int id);

        public List<City> GetAllCityByName(string namePart);
    }
}
