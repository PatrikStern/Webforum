using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webforum.Areas.Identity.Data.Entites
{
    public class PostThread
    {
        public string Id { get; set; }
        public string Titel { get; set; }
        public string HeadLinesId { get; set; }
        [ForeignKey("UserId")]
        public string WebforumUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Posts> Posts { get; set; }

        public PostThread()
        {
            Id = Guid.NewGuid().ToString();
            Titel = String.Empty;
            CreationDate = DateTime.Now;
        }
    }
}
