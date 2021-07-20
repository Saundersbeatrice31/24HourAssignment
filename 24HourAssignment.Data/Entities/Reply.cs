using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Data.Entities
{
    public class Reply
    {
        [ForeignKey(nameof(Reply))]
        [Required]
        public int ReplyId { get; set; }
        public virtual Reply reply { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public Guid AuthorId { get; set; }
    }
}
