using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorSample.Interfaces;
using RazorSample.ViewModels;

namespace RazorSample.Services
{
    public class DetailOrderIndexVmService : IDetailOrderIndexVmService
    {
        private int pageSize = 6;
        private readonly IDetailOrderService _service;

        public DetailOrderIndexVmService(IDetailOrderService detailorderService)
        {
            _service = detailorderService;
        }

        public DetailOrderIndexVm GetDetailOrderListVm(string MenuName, int pageIndex)
        {
            var detailorder = _service.GetDetailOrders(MenuName);
            var menu = _service.GetMenuNames();

            return new DetailOrderIndexVm
            {
                GetMenuNames = new SelectList(menu),
                DetailOrders = PaginatedList<DetailOrderDto>.Create(detailorder, pageIndex, pageSize)
            };
        }
    }
}