using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mediaframe.Models
{
    public class HomeViewModel
    {
        public User User { get; set; }
        public List<User> Suggested { get; set; }
        public List<Post> Posts { get; set; }
        public Post NewPost { get; set; }
    }
}