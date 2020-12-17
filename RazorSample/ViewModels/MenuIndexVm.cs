using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorSample.ViewModels
{
    public class MenuIndexVm
    {
        public SelectList Genres { get; set; }
        public PaginatedList<MenuDto> Menus { get; set; }
    }
}