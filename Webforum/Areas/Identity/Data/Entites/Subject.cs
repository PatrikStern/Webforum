using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webforum.Areas.Identity.Data.Entites
{
    public class Subject
    {
        [Key]
        public string Id { get; set; }
        public string SubjectName { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual List<Category> Categories { get; set; }

        public Subject()
        {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;
            SubjectName = String.Empty;
            Categories = new List<Category>();
        }
    }
}
