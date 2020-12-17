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

namespace RazorSample.Pages.Logout
{

    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("IDUser")))
            {
                Response.Redirect("http://localhost:5000/Login");
            }
            else
            {
                HttpContext.Session.Remove("IDUser");
            }
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("IDUser")))
            {
                Response.Redirect("http://localhost:5000/Login");
            }
        }
    }
}