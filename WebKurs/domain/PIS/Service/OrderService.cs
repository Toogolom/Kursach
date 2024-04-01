namespace PIS.Service
{
    using PIS.Interface;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;
    using WebKurs.Models;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly ITourRepository _tourRepository;

        private readonly IUserRepository _userRepository;

        private readonly ISessionService _sessionService;

        public OrderService(IOrderRepository orderRepository, ITourRepository tourRepository, IUserRepository userRepository, ISessionService sessionService)
        {
            _orderRepository = orderRepository;
            _tourRepository = tourRepository;
            _userRepository = userRepository;
            _sessionService = sessionService;
        }

        public void AddTourToOrder(string tourId)
        {
            List<string> tourIdList = _sessionService.Get<List<string>>("TourIdList");

            if (tourIdList == null)
            {
                tourIdList = new List<string>();
            }

            tourIdList.Add(tourId);

            _sessionService.Set("TourIdList", tourIdList);
        }

        public double CalculateTotalPrice(List<Tour> tours)
        {
            double totalPrice = 0;
            foreach(Tour tour in tours)
            {
                totalPrice += tour.TourPrice;
            }
            return totalPrice;
        }

        public async Task<OrderModel> CreateOrder()
        {
            var username = _sessionService.Get<string>("Username");
            var date = DateTime.Now;
            var tourIdList = _sessionService.Get<List<string>>("TourIdList");
            List<Tour> tourList = await _tourRepository.GetAllToursByAllId(tourIdList);
            var totalPrice = CalculateTotalPrice(tourList);
            return new OrderModel { 
                Username = username,
                TourList = tourList,
                TotalPrice = totalPrice,
                Date = date };
        }

        public async Task AddOrderAsync(OrderModel model)
        {
            var user = await _userRepository.GetUserByUsernameAsync(model.Username);
            var tourIdList = _sessionService.Get<List<string>>("TourIdList");
            await _orderRepository.AddOrder(user.UserId, tourIdList, model.Date);
            _sessionService.Remove("TourIdList");
        }

        public void RemoveTourFromOrder(string tourId)
        {
            List<string> tourIdList = _sessionService.Get<List<string>>("TourIdList");

            if (tourIdList != null)
            {
                tourIdList.Remove(tourId);
                _sessionService.Set("TourIdList", tourIdList);
            }
        }

        public async Task<List<OrderModel>> GetAllOrdersByUsername()
        {
            var username = _sessionService.Get<string>("Username");
            var user = await _userRepository.GetUserByUsernameAsync(username);
            List<OrderModel> orderModelList = new List<OrderModel>();
            var orders = await _orderRepository.GetAllByUserId(user.UserId);

            foreach (var order in orders)
            {
                List<Tour> tourList = await _tourRepository.GetAllToursByAllId(order.TourId);
                var totalPrice = CalculateTotalPrice(tourList);
                OrderModel orderModel = new OrderModel
                {
                    Username = username,
                    TourList = tourList,
                    TotalPrice = totalPrice,
                    Date = order.DateOrder
                };
                orderModelList.Add(orderModel);
            }

            return orderModelList;
        }
    }
}
