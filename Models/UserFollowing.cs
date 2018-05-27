using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mediaframe.Models
{
    public class UserFollowing
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int FollowingId { get; set; }
        public User Following { get; set; }
    }
}