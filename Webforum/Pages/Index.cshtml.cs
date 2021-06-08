using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Webforum.Areas.Identity.Data.Entites;



namespace Webforum.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Gateways.DBGateway _gateway;
        public IndexModel(Gateways.DBGateway gateway)
        {
            _gateway = gateway;
        }

        public void  OnGet()
        {
         
        }

        public void OnPost()
        {
            
        }
    }
}
