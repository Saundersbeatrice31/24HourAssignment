using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Data.Entities
{
    public class Like
    {
        [ForeignKey(nameof(Like))]
        [Required]
        public int Id { get; set; }
        public virtual Like like { get; set; }
        public Guid OwnerId { get; set; }
    }
}
