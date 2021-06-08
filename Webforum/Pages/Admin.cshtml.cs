using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webforum.Areas.Identity.Data.Entites;

namespace Webforum.Pages
{
    public class AdminModel : PageModel
    {
        [BindProperty]
        public Subject subject { get; set; }
        [BindProperty]
        public string postToDelete { get; set; }

        public List<Subject> subjects { get; set; }
        public List<Posts> ReportedPosts { get; set; }

        private readonly Gateways.DBGateway _gateway;

        public AdminModel(Gateways.DBGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task OnGetAsync()
        {

            subjects =  _gateway.CollectForumOverview();
            ReportedPosts = await _gateway.CollectReportedPosts();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Request.Form["SubjectId"].Count > 0)
            {
                Category category = new Category
                {
                    Name = Request.Form["CategoryName"],
                    SubjectId = Request.Form["SubjectId"]
                };
                await _gateway.CreateCategory(category);
            }
            else if(postToDelete != null)
            {
                await _gateway.DeletePost(postToDelete);
            }
            else
            {
                await _gateway.CreateSubject(subject);
            }

            return RedirectToPage("Admin");
        }
    }
}
