using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IMenuService
    {
        MenuDto GetMenu(int menuId);
        IEnumerable<MenuDto> GetMenus(string searchString, string genre);
        IEnumerable<string> GetGenres();
        void CreateMenu(SaveMenuDto menuDto);
        void UpdateMenu(SaveMenuDto menuDto);
        void DeleteMenu(int menuId);
        int getIDod();
    }
}