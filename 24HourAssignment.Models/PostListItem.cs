using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Models
{
   public class PostListItem
    {
        public int Id { get; set; }

        [Display(Name= "Created")]
        public string Title { get; set; }

        public string Text { get; set; }
    }
}
