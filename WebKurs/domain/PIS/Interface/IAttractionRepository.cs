namespace PIS.Interface
{
    public interface IAttractionRepository
    {
        public List<Attraction> GetAllAttractions();

        public List<Attraction> GetAllAttractionsByName(string namePart);

        public List<Attraction> GetAllAttractionsByCityId(int cityId);

        public Attraction GetAttractionById(int id);

        public void AddAttraction(string name, string description, string URL, int cityId);

        public void DeleteAttractionById(int id);
    }
}
