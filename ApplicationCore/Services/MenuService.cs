using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MenuService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public int getIDod()
        {
            return _unitOfWork.Orders.getIDod();
        }
        public MenuDto GetMenu(int menuId)
        {
            var menu = _unitOfWork.Menus.GetBy(menuId);
            return _mapper.Map<Menu, MenuDto>(menu);
        }

        public IEnumerable<MenuDto> GetMenus(string searchString, string genre)
        {
            Expression<Func<Menu, bool>> predicate = m => true;

            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(genre))
            {
                predicate = m => m.Genre == genre && m.Name.Contains(searchString);
            }
            else if (!string.IsNullOrEmpty(searchString))
            {
                predicate = m => m.Name.Contains(searchString);
            }
            else if (!string.IsNullOrEmpty(genre))
            {
                predicate = m => m.Genre == genre;
            }

            var menus = _unitOfWork.Menus.Find(predicate);

            return _mapper.Map<IEnumerable<Menu>, IEnumerable<MenuDto>>(menus);
        }

        public IEnumerable<string> GetGenres()
        {
            return _unitOfWork.Menus.GetGenres();
        }

        public void CreateMenu(SaveMenuDto saveMenuDto)
        {
            var menu = _mapper.Map<SaveMenuDto, Menu>(saveMenuDto);
            _unitOfWork.Menus.Add(menu);

            _unitOfWork.Complete();
        }

        public void UpdateMenu(SaveMenuDto saveMenuDto)
        {
            var menu = _unitOfWork.Menus.GetBy(saveMenuDto.MenuId);
            if (menu == null) return;

            _mapper.Map<SaveMenuDto, Menu>(saveMenuDto, menu);

            _unitOfWork.Complete();
        }

        public void DeleteMenu(int menuId)
        {
            var menu = _unitOfWork.Menus.GetBy(menuId);
            if (menu != null)
            {
                _unitOfWork.Menus.Remove(menu);
                _unitOfWork.Complete();
            }
        }
    }
}