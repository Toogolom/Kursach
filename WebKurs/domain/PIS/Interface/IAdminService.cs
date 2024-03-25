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
        public bool UpdateUser(UserModel model);

        public void DeleteUser(int userId);

        public bool AddCity(CityModel model);

        public bool UpdateCity(CityModel model);

        public void DeleteCity(int cityId);

        public bool AddAttraction(AttractionModel model);
    }
}
