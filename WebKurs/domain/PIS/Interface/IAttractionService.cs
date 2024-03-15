namespace PIS.Interface
{
    public interface IAttractionService
    {
        public List<Attraction> GetAllAttractionsByCityId(int cityId);
    }
}
