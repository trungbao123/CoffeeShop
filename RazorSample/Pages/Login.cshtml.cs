using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorSample.Interfaces;
using RazorSample.ViewModels;
using Microsoft.AspNetCore.Http;

namespace RazorSample.Pages
{

    public class LoginModel : PageModel
    {
        private readonly IUserIndexVmService _userService;

        public LoginModel(IUserIndexVmService userService)
        {
            _userService = userService;
        }
        [BindProperty(SupportsGet = true)]
        public string userName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string passWord { get; set; }
        public bool check { get; set; }
        public string session { get; set; }
        public UserIndexVm UserIndexVM { get; set; }

        public void OnGet(string userName, string passWord)
        {
            check = _userService.checkLoginVm(userName, passWord);
            if (check)
            {
                Response.Redirect("http://localhost:5000");
                HttpContext.Session.SetString("IDUser", userName);
                session = HttpContext.Session.GetString("IDUser");
            }
        }
    }
}