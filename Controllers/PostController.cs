using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using QuickPropForum.Data;
using QuickPropForum.IService;
using QuickPropForum.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPropForum.Controllers
{
    public class PostController : Controller
    {
        //private readonly ILogger<PostController> _logger;
        private IPostService _postService = null;
        private IUserService _userService = null;

        //ILogger<PostController> logger, 
        public PostController(IPostService postService, IUserService  userService)
        {
         //   _logger = logger;
            _postService = postService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var posts = _postService.GetAll();
            return View(posts);            
        }

        [HttpGet]
        public IActionResult NewPost(int Id)
        {
            //Build PostListingModel
            PostListingsModel postListingsModel = new();
            var Users = _userService.GetAll();
            postListingsModel.LstUsers = Users.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            //Build NewPostModel
            var post = _postService.GetPostById(Id);
            var postReplies = _postService.GetPostsByParentId(post.Id);
            var model = new NewPostModel
            {
                Id = post.Id,
                ParentId = post.ParentId,
                PostContent = post.PostContent,
                AuthorId = post.User.Id,
                AuthorName = post.User.Name,
                AuthorProfilePic = post.User.ProfilePic,
                DatePosted = post.DatePosted,
                PostReplies = postReplies,
                PostListingsModel = postListingsModel
            };
            return View(model);
        }


        public IActionResult NewTopic()
        {
            //Build PostListingModel
            PostListingsModel postListingsModel = new();
            var Users = _userService.GetAll();
            postListingsModel.LstUsers = Users.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(postListingsModel);
        }

        [HttpPost]  
        public IActionResult AddPost(PostListingsModel postListingModel)    
        {
            var model = new Post
            {
                //Id = newPostModel.Post.Id,
                ParentId = postListingModel.ParentId,
                UserId = postListingModel.UserId,
                PostContent = postListingModel.PostContent,
                DatePosted = DateTime.Now             
            };
           var JustSavePost = _postService.Save(model);
            //Redirect to the current Post
            if (JustSavePost.ParentId > 0)
            {
                return RedirectToAction("NewPost", "Post", new { Id = JustSavePost.ParentId });
            }
            return RedirectToAction("Index", "Post");
        }
       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}





