using System;
using System.Collections.Generic;

#nullable disable

namespace ConvoCollector.Models
{
    public partial class Thread
    {
        public Thread()
        {
            Posts = new HashSet<Posts>();
        }

        public string Id { get; set; }
        public string Titel { get; set; }
        public string HeadLinesId { get; set; }
        public string WebforumUserId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual HeadLine HeadLines { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
