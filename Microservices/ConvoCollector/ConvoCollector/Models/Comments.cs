using System;
using System.Collections.Generic;

#nullable disable

namespace ConvoCollector.Models
{
    public partial class Comments
    {
        public string Id { get; set; }
        public string Comment { get; set; }
        public bool ReportedComment { get; set; }
        public bool DeletedByAdmin { get; set; }
        public DateTime CreationDate { get; set; }
        public string WebforumUserId { get; set; }
        public string PostsId { get; set; }

       
    }
}
