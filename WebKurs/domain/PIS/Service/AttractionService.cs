namespace PIS.Service
{
    using PIS.Interface;
    using System;
    public class AttractionService : IAttractionService
    {
        private readonly IAttractionRepository _attractionRepository;

        public AttractionService(IAttractionRepository attractionRepository)
        {
            _attractionRepository = attractionRepository;
        }

        public List<Attraction> GetAllAttractionsByCityId(int cityId)
        {
            return _attractionRepository.GetAllAttractionsByCityId(cityId);
        }
    }
}
