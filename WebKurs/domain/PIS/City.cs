namespace PIS
{
    public class City
    {
        public int CityId {  get; }

        public string CityName { get; }

        public string CityDescription { get; }

        public string PhotoUrl { get; }

        public City(int cityId, string cityName, string cityDescription, string photoUrl)
        {
            CityId = cityId;
            CityName = cityName;
            CityDescription = cityDescription;
            PhotoUrl = photoUrl;
        }
    }
}
