using PIS.Repository;

namespace PIS.Memory
{
    public class AttractionRepository : IAttractionRepository
    {
        private readonly List<Attraction> attractions = new List<Attraction>
    {
        new Attraction(1, "Attraction 1", "Description 1", 1),
        new Attraction(2, "Attraction 2", "Description 2", 1),
        new Attraction(3, "Attraction 3", "Description 3", 2)
    };
        public List<Attraction> GetAllAttractions()
        {
            return attractions;
        }

        public List<Attraction> GetAllAttractionsByCityId(int cityId)
        {
            return attractions.Where(attr => attr.CityId.Equals(cityId))
                              .ToList();      
        }

        public List<Attraction> GetAllAttractionsByName(string namePart)
        {
            return attractions.Where(attr => attr.AttractionName.Contains(namePart))
                              .ToList();
        }
    }
}
