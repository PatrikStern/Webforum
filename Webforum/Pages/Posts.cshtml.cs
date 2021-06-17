using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        [BindProperty(SupportsGet = true)]
        public string HeadLineID { get; set; }

        [BindProperty]
        public string UserID { get; set; }

        [BindProperty]
        public string newInput { get; set; }
        [BindProperty]
        public string reportedPost { get; set; }
        [BindProperty]
        public IFormFile PostImageUrl { get; set; }
        [BindProperty]
        public string Comment { get; set; }
        [BindProperty]
        public string PostID { get; set; }
        [BindProperty]
        public string likedPost { get; set; }
        public List<PostThread> Threads { get; set; }
        public List<Posts> Posts { get; set; }

        private readonly DBGateway _DBGateway;
        private readonly APIGateway _APIGateway;

        public PostsModel(DBGateway DBGateway, APIGateway APIGateway)
        {
            _DBGateway = DBGateway;
            _APIGateway = APIGateway;
        }

        public async Task OnGetAsync()
        {
            Threads = await _DBGateway.CollectThreadTopicsOverview(HeadLineID);
            Posts = await _APIGateway.GetPostsAPI(ThreadID);
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if(likedPost != null)
            {
                await _DBGateway.LikePost(likedPost);
            }
            if(Comment != null)
            {
                Comment = InternalFunctions.FaultWordChecker(Comment);

                var comment = new Comments()
                {
                    WebforumUserId = UserID,
                    Comment = Comment,
                    PostsId = PostID
                };

                await _DBGateway.CreateComment(comment);
            }

            if (reportedPost != null)
            {
                await _DBGateway.ReportPost(reportedPost);
            }

            else if (newInput != null)
            {
                newInput = InternalFunctions.FaultWordChecker(newInput);

                if (PostImageUrl != null)
                {
                    var file = "./wwwroot/img/" + PostImageUrl.FileName;
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await PostImageUrl.CopyToAsync(fileStream);
                    }
                }
                var post = new Posts()
                {
                    Post = newInput,
                    WebforumUserId = UserID,
                    UserName = _DBGateway.FindUser(UserID).Result.UserName,
                    ImageUrl = PostImageUrl != null ? PostImageUrl.FileName : "",
                    PostThreadId = ThreadID
                };

                await _DBGateway.CreatePost(post);
                var user = await _DBGateway.FindUser(UserID);
                user.AmountOfPosts = user.AmountOfPosts + 1;
                await _DBGateway.UpdateUser(user);
            }

            return RedirectToPage("Posts", new { ThreadID = ThreadID, Thread = Thread, HeadLineID = HeadLineID });
        }
    }
}
