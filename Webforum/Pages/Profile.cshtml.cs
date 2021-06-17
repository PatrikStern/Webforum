using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webforum.Areas.Identity.Data;
using Webforum.Gateways;

namespace Webforum.Pages
{
    public class ProfileModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string UserID { get; set; }

        public WebforumUser UserProfile { get; set; }

        private readonly UserManager<WebforumUser> _userManager;
        private readonly SignInManager<WebforumUser> _signInManager;
        public DBGateway _DBGateway;
        

        public ProfileModel(DBGateway DBGateway, UserManager<WebforumUser> userManager, SignInManager<WebforumUser> signInManager)
        {
            _DBGateway = DBGateway;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task OnGetAsync()
        {
            if(UserID != null)
            {
                UserProfile = await _userManager.FindByIdAsync(UserID);
            }
            else
            {
                UserProfile = await _userManager.GetUserAsync(User);
            }
        }
    }
}
