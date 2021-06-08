using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webforum.Areas.Identity.Data;
using Webforum.Areas.Identity.Data.Entites;
using Webforum.Gateways;

namespace Webforum.Pages
{
    public class CategoryOverviewModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string CategoryID { get; set; }
        [BindProperty]
        public string userID { get; set; }
        public List<HeadLines> Topics { get; set; }
        public string CatagoryName { get; set; }
        private  DBGateway _DBGateway { get; set; }
        

        public CategoryOverviewModel(DBGateway DBGateway)
        {
            _DBGateway = DBGateway;
        }

        public async Task OnGetAsync()
        {
           CatagoryName = await _DBGateway.FindCatagory(CategoryID);
           Topics = await _DBGateway.CollectCategoryOverview(CategoryID);
        }

        public async Task<ActionResult> OnPostAsync()
        {
            var headline = new HeadLines()
            {
                HeadLine = Request.Form["newInput"],
                CategoryId = CategoryID,
                WebforumUserId = userID
            };

             await _DBGateway.CreateHeadLine(headline);

            return RedirectToPage("CategoryOverview", new { CategoryID = CategoryID });
        }
    }
}
