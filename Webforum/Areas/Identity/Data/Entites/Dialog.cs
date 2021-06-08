using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webforum.Areas.Identity.Data.Entites
{
    public class Dialog
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("UserId")]
        public string WebforumUserId { get; set; }
        [ForeignKey("ChatId")]
        public string ChatId { get; set; }
        public string ConversationalPartner { get; set; }
        public List<Message> Messages { get; set; }

        public Dialog()
        {
            Id = Guid.NewGuid().ToString();
            Messages = new List<Message>();
        }
    }
}
