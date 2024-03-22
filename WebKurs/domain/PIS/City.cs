namespace PIS
{
    public class City
    {
        public int CityId {  get; }

        public string CityName { get; set; }

        public string CityDescription { get; set; }

        public string PhotoUrl { get; set; }

        public City(int cityId, string cityName, string cityDescription, string photoUrl)
        {
            CityId = cityId;
            CityName = cityName;
            CityDescription = cityDescription;
            PhotoUrl = photoUrl;
        }
    }
}
