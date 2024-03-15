namespace PIS.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ITourService
    {
        public List<Tour> GetAllToursByAllId(List<int>tourIdList);

        public List<Tour> GetAllTours();

        public List<Attraction> GetAllAttractionForTour(int tourId);
    }
}
