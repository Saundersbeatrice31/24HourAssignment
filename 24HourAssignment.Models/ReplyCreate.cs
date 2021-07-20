using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Models
{
    public class ReplyCreate
    {
        [Required]
        [MaxLength(10000)]
        public string Text { get; set; }
    }
}
