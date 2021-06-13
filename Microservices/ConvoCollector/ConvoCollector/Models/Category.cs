using System;
using System.Collections.Generic;

#nullable disable

namespace ConvoCollector.Models
{
    public partial class Category
    {
        public Category()
        {
            HeadLines = new HashSet<HeadLine>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<HeadLine> HeadLines { get; set; }
    }
}
