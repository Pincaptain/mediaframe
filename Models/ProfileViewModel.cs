using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mediaframe.Models
{
    public class ProfileViewModel
    {
        public ApplicationUser User { get; set; }
        public User Profile { get; set; }
        public IndexViewModel Details { get; set; }
    }
}