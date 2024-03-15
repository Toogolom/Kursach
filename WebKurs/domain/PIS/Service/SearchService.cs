namespace PIS.Service
{
    using PIS.Interface;
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

        public SearchViewModel SearchResult(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return new SearchViewModel
                {
                    Tours = _tourRepository.GetAllTours(),
                    Attractions = _attractionRepository.GetAllAttractions(),
                    Cities = _cityRepository.GetAllCity(),
                };
            }
            return new SearchViewModel
            {
                Tours = _tourRepository.GetAllByNameTours(query),
                Attractions = _attractionRepository.GetAllAttractionsByName(query),
                Cities = _cityRepository.GetAllCityByName(query),
            };
        }
    }
}
