using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Data.Entities
{
    public class Comment
    {
        [ForeignKey(nameof(Comment))]
        [Required]
        public int ID { get; set; }
        public virtual Comment comment {get; set;}
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
        public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}
