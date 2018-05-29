using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mediaframe.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 60 characters!")]
        [RegularExpression("[a-zA-Z]*", ErrorMessage = "Name can only contain alphabetical characters!")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(120, MinimumLength = 1, ErrorMessage = "Surname must be between 1 and 120 characters!")]
        [RegularExpression("[a-zA-Z]*", ErrorMessage = "Surname can only contain alphabetical characters!")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Avatar must be image url!")]
        [Display(Name = "Avatar URL")]
        public string Avatar { get; set; }

        public string AccountId { get; set; }
        public virtual ApplicationUser Account { get; set; }

        public virtual List<User> Following { get; set; }
        public virtual List<User> Followers { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<Post> Posts { get; set; }
        public virtual List<Post> LikedPosts { get; set; }
    }
}