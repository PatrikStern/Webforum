using System;
using System.Collections.Generic;

#nullable disable

namespace ConvoCollector.Models
{
    public partial class Chat
    {
        public Chat()
        {
            Dialogs = new HashSet<Dialog>();
        }

        public string Id { get; set; }
        public string WebforumUserId { get; set; }

        public virtual ICollection<Dialog> Dialogs { get; set; }
    }
}
