using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorSample.Interfaces;
using RazorSample.ViewModels;

namespace RazorSample.Services
{
    public class MenuIndexVmService : IMenuIndexVmService
    {
        private int pageSize = 6;
        private readonly IMenuService _service;

        public MenuIndexVmService(IMenuService menuService)
        {
            _service = menuService;
        }
        public int getIDod()
        {
            return _service.getIDod();
        }
        public MenuIndexVm GetMenuListVm(string searchString, string genre, int pageIndex)
        {
            var menus = _service.GetMenus(searchString, genre);
            var genres = _service.GetGenres();

            return new MenuIndexVm
            {
                Genres = new SelectList(genres),
                Menus = PaginatedList<MenuDto>.Create(menus, pageIndex, pageSize)
            };
        }
    }
}