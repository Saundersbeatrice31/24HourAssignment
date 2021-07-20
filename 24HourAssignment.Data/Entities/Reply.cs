using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Data
{
    public class Reply
    {
        [Key]
        [Required]
        public int Id { get; set; }
       
        [Required]
        public string Text { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(Comment))]
        public int ComId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
