using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorSample.Interfaces;
using RazorSample.ViewModels;

namespace RazorSample.Services
{
    public class OrderIndexVmService : IOrderIndexVmService
    {
        private int pageSize = 6;
        private readonly IOrderService _service;

        public OrderIndexVmService(IOrderService orderService)
        {
            _service = orderService;
        }
        public int getIDod()
        {
            return _service.getIDod();
        }
        public OrderIndexVm GetOrderListVm(string userName, int pageIndex)
        {
            var order = _service.GetOrders(userName);
            var user = _service.GetUsers();

            return new OrderIndexVm
            {
                GetUsername = new SelectList(user),
                Orders = PaginatedList<OrderDto>.Create(order, pageIndex, pageSize)
            };
        }
    }
}