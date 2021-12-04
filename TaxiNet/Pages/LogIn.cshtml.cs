using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiNet.DataLayer.DataModels;
using TaxiNet.Services.UserService;

namespace TaxiNet.Pages
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public AuthenticateRequest authenticateRequest { get; set; } = new AuthenticateRequest();

        private IUserService _userService;

        public LogInModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            AuthenticateResponse response = _userService.Authenticate(authenticateRequest);

            if (response == null)
            {
                return Redirect("./Index");
            }
            else
            {
                Response.Cookies.Append("X-Access-Token", response.Token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
                //Response.Cookies.Delete("X-Access-Token");
                return RedirectToPage("./Admin/GalleryController");
            }
        }
    }
}
