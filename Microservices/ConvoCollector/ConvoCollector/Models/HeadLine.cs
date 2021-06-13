using System;
using System.Collections.Generic;

#nullable disable

namespace ConvoCollector.Models
{
    public partial class HeadLine
    {
        public HeadLine()
        {
            Threads = new HashSet<Thread>();
        }

        public string Id { get; set; }
        public string HeadLine1 { get; set; }
        public bool ReportedHeadline { get; set; }
        public bool DeletedByAdmin { get; set; }
        public DateTime CreationDate { get; set; }
        public string WebforumUserId { get; set; }
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Thread> Threads { get; set; }
    }
}
