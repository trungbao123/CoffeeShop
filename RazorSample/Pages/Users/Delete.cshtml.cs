using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSample.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly IUserService _service;

        public DeleteModel(IUserService service)
        {
            _service = service;
        }

        [BindProperty]
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

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _service.DeleteUser(id ?? default(int));

            return RedirectToPage("./Index");
        }
    }
}
