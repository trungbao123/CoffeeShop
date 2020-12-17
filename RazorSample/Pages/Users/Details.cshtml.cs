using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSample.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly IUserService _service;

        public DetailsModel(IUserService service)
        {
            _service = service;
        }

        public UserDto User { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = _service.GetUser(id ?? default(int));

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
