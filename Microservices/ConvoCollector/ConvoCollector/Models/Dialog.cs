using System;
using System.Collections.Generic;

#nullable disable

namespace ConvoCollector.Models
{
    public partial class Dialog
    {
        public Dialog()
        {
            Messages = new HashSet<Message>();
        }

        public string Id { get; set; }
        public string WebforumUserId { get; set; }
        public string ChatId { get; set; }
        public string ConversationalPartner { get; set; }

        public virtual Chat Chat { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
