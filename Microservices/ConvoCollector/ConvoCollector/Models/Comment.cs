using System;
using System.Collections.Generic;

#nullable disable

namespace ConvoCollector.Models
{
    public partial class Comment
    {
        public string Id { get; set; }
        public string Comment1 { get; set; }
        public bool ReportedComment { get; set; }
        public bool DeletedByAdmin { get; set; }
        public DateTime CreationDate { get; set; }
        public string WebforumUserId { get; set; }
        public string PostsId { get; set; }

        public virtual Posts Posts { get; set; }
    }
}
