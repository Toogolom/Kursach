namespace PIS.Interface
{
    public interface IAttractionRepository
    {
        public List<Attraction> GetAllAttractions();

        public List<Attraction> GetAllAttractionsByName(string namePart);

        public List<Attraction> GetAllAttractionsByCityId(int cityId);

        public Attraction GetAttractionById(int id);
    }
}
