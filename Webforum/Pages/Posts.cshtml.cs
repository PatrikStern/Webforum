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
    public class PostsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ThreadID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Thread { get; set; }

        [BindProperty]
        public string UserID { get; set; }

        [BindProperty]
        public string newInput { get; set; }
        [BindProperty]
        public string reportedPost { get; set; }

        public List<Posts> Posts { get; set; }

        private readonly DBGateway _DBGateway;

        public PostsModel(DBGateway DBGateway)
        {
            _DBGateway = DBGateway;
        }

        public async Task OnGetAsync()
        {

            Posts = await _DBGateway.CollectPosts(ThreadID);
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if(reportedPost != null)
            {
                await _DBGateway.ReportPost(reportedPost);
            }
            else
            {

            var post = new Posts()
            {
                Post = newInput,
                WebforumUserId = UserID,
                PostThreadId = ThreadID
            };

            await _DBGateway.CreatePost(post);
            var user = await _DBGateway.FindUser(UserID);
            user.AmountOfPosts = user.AmountOfPosts + 1;
            await _DBGateway.UpdateUser(user);
            }

            return RedirectToPage("Posts", new { ThreadID = ThreadID });
        }
    }
}