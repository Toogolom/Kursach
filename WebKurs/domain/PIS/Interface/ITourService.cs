namespace PIS.Interface
{
    using PIS.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ITourService
    {
        public Task<bool> AddTourAsync(TourModel model);

        public Task<Tour> GetTourByIdAsync(string id);

        public Task<List<Tour>> GetAllToursByAllIdAsync(List<string>tourIdList);

        public Task<List<Tour>> GetAllToursAsync();

        public Task<List<Attraction>> GetAllAttractionForTour(string tourId);

        public Task<Dictionary<Attraction, DateTime>> GetAttractionDateForTour(string id);

        public Task<List<Tour>> GetAllTourByPartNameAsync(string partName);

        public Task<bool> UpdateTourAsync(TourModel model);

        public Task DeleteTour(string tourId);
    }
}
