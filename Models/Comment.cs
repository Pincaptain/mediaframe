using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mediaframe.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(120, ErrorMessage = "Comments cannot be longer then 120 characters!")]
        public string Content { get; set; }

        public DateTime DateAdded { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}