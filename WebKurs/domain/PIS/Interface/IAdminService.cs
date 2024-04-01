using PIS.Models;
using PIS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKurs.Models;

namespace PIS.Interface
{
    public interface IAdminService
    {
        public Task DeleteUser(string userId);

        public Task DeleteCity(string cityId);

        public Task DeleteAttractionAsync(string  attractionId);

        public Task DeleteTour(string tourId);
    }
}
