using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webforum.Areas.Identity.Data.Entites;
using Webforum.Gateways;

namespace Webforum.Pages
{
    public class TopicOverviewModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string HeadLineID { get; set; }
        [BindProperty]
        public string UserID { get; set; }
        public string HeadLineName { get; set; }
        public List<PostThread> Threads { get; set; }

        private DBGateway _DBGateway; 

        public TopicOverviewModel(DBGateway DBGateway)
        {
            _DBGateway = DBGateway;
        }

        public async Task OnGetAsync()
        {
            HeadLineName = await _DBGateway.FindHeadLineTitel(HeadLineID);
            Threads = await _DBGateway.CollectThreadTopicsOverview(HeadLineID);
        }

        public async Task<ActionResult> OnPostAsync()
        {
            var thread = new PostThread()
            {
                Titel = Request.Form["newInput"],
                HeadLinesId = HeadLineID,
                WebforumUserId = UserID
            };

            await _DBGateway.CreatePostThread(thread);

            return RedirectToPage("TopicOverview", new { HeadLineID = HeadLineID });
        }
    }
}
