using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Data.Entities
{
    class Comment
    {
        [ForeignKey(nameof(Comment))]
        [Required]
        public int ID { get; set; }
        public virtual Comment comment { get; set; }
        public string Text { get; set; }
        public Guid AuthorID { get; set; }
    }
}
