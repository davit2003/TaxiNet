using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiNet.DataLayer;
using TaxiNet.Services;

namespace TaxiNet.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Email email { get; set; } = new Email();

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                MailService.SendMail(email);
            }
            return RedirectToPage("./Index");
        }
    }
}
