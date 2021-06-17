using System;
using System.Collections.Generic;

#nullable disable

namespace ConvoCollector.Models
{
    public partial class Message
    {
        public string Id { get; set; }
        public string WebforumUserId { get; set; }
        public string DialogId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Post { get; set; }
        public string Sender { get; set; }
        public string Reciver { get; set; }

        public virtual Dialog Dialog { get; set; }
    }
}
