using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webforum.Areas.Identity.Data.Entites
{
    public class HeadLines
    {
        [Key]
        public string Id { get; set; }
        public string HeadLine { get; set; }
        public bool ReportedHeadline { get; set; }
        public bool deletedByAdmin { get; set; }
        public DateTime CreationDate { get; set; }
        [ForeignKey("UserId")]
        public string WebforumUserId { get; set; }
        public string CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        //public virtual Category Category { get; set; }
        public virtual List<PostThread> Threads { get; set; }

        public HeadLines()
        {
            Id = Guid.NewGuid().ToString();
            HeadLine = String.Empty;
            CreationDate = DateTime.Now;
            Threads = new List<PostThread>();
            deletedByAdmin = false;
            ReportedHeadline = false;
        }
    }
}
