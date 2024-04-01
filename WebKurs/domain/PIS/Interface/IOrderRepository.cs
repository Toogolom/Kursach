namespace PIS.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IOrderRepository
    {
       public Task<List<Order>> GetAllByUserId(string id);
       
       public Task<List<string>> GetAllTourByUserId(string id);

        public Task AddOrder(string userId, List<string> tourId, DateTime data);
    }
}
