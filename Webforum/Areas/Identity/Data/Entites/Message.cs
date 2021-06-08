using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webforum.Areas.Identity.Data.Entites
{
    public class Message
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("UserId")]
        public string WebforumUserId { get; set; }
        [ForeignKey("DialogId")]
        public string DialogId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Post { get; set; }
        public string Sender { get; set; }
        public string Reciver { get; set; }

        public Message()
        {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;
        }
    }
}
