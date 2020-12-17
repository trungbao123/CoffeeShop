using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorSample.ViewModels
{
    public class DetailOrderIndexVm
    {
        public SelectList GetMenuNames { get; set; }
        public PaginatedList<DetailOrderDto> DetailOrders { get; set; }
    }
}