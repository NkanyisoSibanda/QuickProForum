using QuickPropForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPropForum.IService
{
    public interface IPostService
    {
       IEnumerable<Post> GetAll();
        Post GetPostById(int postId);
        IEnumerable<Post> GetPostsByParentId(int postId);
        Post Save(Post oPost);      
    }
}
