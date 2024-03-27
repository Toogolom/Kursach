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
        public void DeleteUser(int userId);

        public void DeleteCity(int cityId);

        public void DeleteAttraction(int  attractionId);

        public void DeleteTour(int tourId);
    }
}
