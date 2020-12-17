using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorSample.Pages.Menus
{
    public class EditModel : PageModel
    {
        private readonly IMenuService _service;
        private readonly IMapper _mapper;

        public EditModel(IMenuService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [BindProperty]
        public SaveMenuDto Menu { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = _service.GetMenu(id ?? default(int));

            if (menu == null)
            {
                return NotFound();
            }

            Menu = _mapper.Map<MenuDto, SaveMenuDto>(menu);

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                _service.UpdateMenu(Menu);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(Menu.MenuId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
        }
        private bool MenuExists(int id)
        {
            return _service.GetMenu(id) != null;
        }

    }
}
