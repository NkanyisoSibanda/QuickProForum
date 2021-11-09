using Microsoft.EntityFrameworkCore;
using QuickPropForum.Data;
using QuickPropForum.IService;
using QuickPropForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPropForum.Service
{
    public class PostService: IPostService
    {
        private readonly QuickPropForumDBContext _context;
        public PostService(QuickPropForumDBContext context)
        {
            _context = context;
        }

        public Post Save(Post oPost)
        {
            _context.Add(oPost);
            _context.SaveChanges();
            return oPost;
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        //Posts and Replies are stored in the same table
        public IEnumerable<Post> GetPostsByParentId(int postId)
        {
            return _context.Posts.Where(post => post.ParentId == postId)
                .Include(post => post.User)
                .ToList();
        }

        public Post GetPostById(int postId)
        {
            return _context.Posts.Where(post => post.Id == postId)
                .Include(post => post.User)
                .First();
        }
    }
}
