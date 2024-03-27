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
        public bool AddTour(TourModel model);

        public Tour GetTourById(int id);

        public List<Tour> GetAllToursByAllId(List<int>tourIdList);

        public List<Tour> GetAllTours();

        public List<Attraction> GetAllAttractionForTour(int tourId);

        public Dictionary<Attraction, DateTime> GetAttractionDateForTour(int id);

        public List<Tour> GetAllTourByPartName(string partName);

        public bool UpdateTour(TourModel model);

        public void DeleteTour(int tourId);
    }
}
