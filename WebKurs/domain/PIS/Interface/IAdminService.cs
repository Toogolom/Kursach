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
        public bool UpdateUser(RegModel model);

        public void DeleteUser(int userId);
    }
}
