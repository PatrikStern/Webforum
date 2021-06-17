using System;
using System.Collections.Generic;

#nullable disable

namespace ConvoCollector.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public string Id { get; set; }
        public string Post1 { get; set; }
        public string ImageUrl { get; set; }
        public bool ReportedPost { get; set; }
        public bool DeletedByAdmin { get; set; }
        public DateTime CreationDate { get; set; }
        public string WebforumUserId { get; set; }
        public string UserName { get; set; }
        public string PostThreadId { get; set; }

        public virtual Thread PostThread { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
