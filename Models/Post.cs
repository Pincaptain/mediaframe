using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mediaframe.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Image URL is required!")]
        [StringLength(600, ErrorMessage = "Image URL cannot be longer then 600 characters!")]
        public string ImageUrl { get; set; }

        [StringLength(240, ErrorMessage = "Description cannot be longer then 240 characters!")]
        public string Description { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public virtual List<Comment> Comments { get; set; }
        
        public virtual List<User> Likes { get; set; }
    }
}