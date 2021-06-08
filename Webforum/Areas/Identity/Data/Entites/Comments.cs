using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webforum.Areas.Identity.Data.Entites
{
    public class Comments
    {
        [Key]
        public string Id { get; set; }
        public string Comment { get; set; }
        public bool ReportedComment { get; set; }
        public bool DeletedByAdmin { get; set; }
        public DateTime CreationDate { get; set; }
        [ForeignKey("UserId")]
        public string WebforumUserId { get; set; }
        public string PostsId { get; set; }

        public Comments()
        {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;
            Comment = String.Empty;
            DeletedByAdmin = false;
            ReportedComment = false;
        }

    }
}
