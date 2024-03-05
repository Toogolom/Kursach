namespace PIS
{
    public class City
    {
        public string CityId {  get; }

        public string CityName { get; }

        public string CityDescription { get; }

        public City(string cityId, string cityName, string cityDescription)
        {
            CityId = cityId;
            CityName = cityName;
            CityDescription = cityDescription;
        }
    }
}
