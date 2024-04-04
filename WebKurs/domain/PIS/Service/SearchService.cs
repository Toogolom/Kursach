namespace PIS.Service
{
    using PIS.Interface;
    using System.Threading.Tasks;
    using WebKurs.Models;

    public class SearchService : ISearchService
    {
        private readonly ITourRepository _tourRepository;

        private readonly IAttractionRepository _attractionRepository;

        private readonly ICityRepository _cityRepository;

        public SearchService(ITourRepository tourRepository, IAttractionRepository attractionRepository, ICityRepository cityRepository)
        {
            _tourRepository = tourRepository;
            _attractionRepository = attractionRepository;
            _cityRepository = cityRepository;
        }

        public async Task<SearchModel> SearchResultAsync(SearchModel model)
        {
            if (string.IsNullOrEmpty(model.Query))
            {
                model.Tours = await _tourRepository.GetAllTours();
                model.Attractions = await _attractionRepository.GetAllAttractions();
                model.Cities = await _cityRepository.GetAllCity();
                return model;
            }
            model.Tours = await _tourRepository.GetAllByNameTours(model.Query);
            model.Attractions = await _attractionRepository.GetAllAttractionsByName(model.Query);
            model.Cities = await _cityRepository.GetAllCityByName(model.Query);

            return model;
        }
    }
}
