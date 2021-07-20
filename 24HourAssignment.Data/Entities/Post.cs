using _24HourAssignment.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public Guid AuthorId { get; set; }

        

        

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    }
}
