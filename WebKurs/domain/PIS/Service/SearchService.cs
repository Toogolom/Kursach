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

        public async Task<SearchViewModel> SearchResultAsync(string query, string searchType)
        {
            if (string.IsNullOrEmpty(query))
            {
                return new SearchViewModel
                {
                    Tours = await _tourRepository.GetAllTours(),
                    Attractions =  await _attractionRepository.GetAllAttractions(),
                    Cities = await _cityRepository.GetAllCity(),
                };
            }
            return new SearchViewModel
            {
                Tours = await _tourRepository.GetAllByNameTours(query),
                Attractions = await _attractionRepository.GetAllAttractionsByName(query),
                Cities = await _cityRepository.GetAllCityByName(query),
            };
        }
    }
}
