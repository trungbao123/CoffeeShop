using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorSample.ViewModels
{
    public class OrderIndexVm
    {
        public SelectList GetUsername { get; set; }
        public PaginatedList<OrderDto> Orders { get; set; }
    }
}