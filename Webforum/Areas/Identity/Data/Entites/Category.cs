using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webforum.Areas.Identity.Data.Entites
{
    public class Category
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string SubjectId { get; set; }
        //[ForeignKey("SubjectId")]
        //public virtual Subject Subject { get; set; }
        public virtual List<HeadLines> HeadLines { get; set; }

        public Category()
        {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;
            Name = String.Empty;
            HeadLines = new List<HeadLines>();
        }
    }
}
