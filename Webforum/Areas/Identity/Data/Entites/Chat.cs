using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webforum.Areas.Identity.Data.Entites
{
    public class Chat
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("UserId")]
        public string WebforumUserId { get; set; }
        public List<Dialog> Dialogs { get; set; }
        public Chat()
        {
            Id = Guid.NewGuid().ToString();
            Dialogs = new List<Dialog>();
        }
    }
}
