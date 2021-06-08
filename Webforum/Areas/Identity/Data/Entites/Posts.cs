using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webforum.Areas.Identity.Data.Entites
{
    public class Posts
    {
        [Key]
        public string Id { get; set; }
        public string Post { get; set; }
        public string ImageUrl { get; set; }
        public bool ReportedPost { get; set; }
        public bool deletedByAdmin { get; set; }
        public DateTime CreationDate { get; set; }
        [ForeignKey("UserId")]
        public string WebforumUserId { get; set; } 
        public string PostThreadId { get; set; }
        public virtual List<Comments> Comments { get; set; }

        public Posts()
        {
            Id = Guid.NewGuid().ToString();
            Post = String.Empty;
            CreationDate = DateTime.Now;
            deletedByAdmin = false;
            Comments = new List<Comments>();
            ReportedPost = false;
        }
    }
}
