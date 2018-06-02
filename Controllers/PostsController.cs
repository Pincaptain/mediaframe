using Mediaframe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mediaframe.Controllers
{
    public class PostsController : Controller
    {
        public ApplicationDbContext Database { get; set; }

        public PostsController()
        {
            Database = new ApplicationDbContext();
        }

        public ActionResult NewComment(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return HttpNotFound();
            }

            var commentContent = Request.Params["comment"];

            if (string.IsNullOrEmpty(commentContent))
            {
                return HttpNotFound();
            }

            var userId = Database.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;
            var profile = Database.Profiles.FirstOrDefault(p => p.AccountId == userId);
            var post = Database.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return HttpNotFound();
            }

            var comment = new Comment()
            {
                UserId = profile.Id,
                User = profile,
                Content = commentContent,
                DateAdded = DateTime.Now,
                PostId = post.Id,
                Post = post
            };

            post.Comments.Add(comment);

            Database.SaveChanges();

            return Json(new { comments = post.Comments.Count, commentContent = comment.Content, commentUser = comment.User.Account.Email},
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult LikePost(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return HttpNotFound();
            }

            var userId = Database.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;
            var profile = Database.Profiles.FirstOrDefault(p => p.AccountId == userId);
            var post = Database.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return HttpNotFound();
            }

            if (post.Likes.Contains(profile))
            {
                return HttpNotFound();
            }

            post.Likes.Add(profile);

            Database.SaveChanges();

            return Json(new { likes = post.Likes.Count },
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult DislikePost(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return HttpNotFound();
            }

            var userId = Database.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;
            var profile = Database.Profiles.FirstOrDefault(p => p.AccountId == userId);
            var post = Database.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return HttpNotFound();
            }

            if (!post.Likes.Contains(profile))
            {
                return HttpNotFound();
            }

            post.Likes.Remove(profile);

            Database.SaveChanges();

            return Json(new { likes = post.Likes.Count },
                JsonRequestBehavior.AllowGet);
        }
    }
}