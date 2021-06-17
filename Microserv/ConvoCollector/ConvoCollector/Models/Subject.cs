using System;
using System.Collections.Generic;

#nullable disable

namespace ConvoCollector.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Categories = new HashSet<Category>();
        }

        public string Id { get; set; }
        public string SubjectName { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
