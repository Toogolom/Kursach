namespace PIS.Service
{
    using PIS.Interface;
    using PIS.Models;
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

        public List<Attraction> GetAllAtractionByPartName(string partName)
        {
            return _attractionRepository.GetAllAttractionsByName(partName);
        }

        public void AddAttraction(AttractionModel model)
        {
            _attractionRepository.AddAttraction(model.AttractionName, model.AttractionDescription, model.AttractionPhotoUrl, model.CityId);
        }

        public void DeleteAttrationById(int id)
        {
            _attractionRepository.DeleteAttractionById(id);
        }
    }
}
