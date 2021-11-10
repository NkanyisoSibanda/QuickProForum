using Microsoft.AspNetCore.Mvc;
using QuickPropForum.Data;
using QuickPropForum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using QuickPropForum.IService;

namespace QuickPropForum.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService = null;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }   
        

        public IActionResult Index()
        {
            var us = _userService.GetAll();   
            
            return View(us);
        }              
       

        [HttpGet]
        public IActionResult NewUser()
        {
            User UserModel = new();
            return View(UserModel);
        }

        [HttpPost]
        public IActionResult AddUser(User User, List<IFormFile> ProfilePic)
        {
            foreach (var item in ProfilePic)
            {
                if (item.Length > 0)
                {
                    using var ms = new MemoryStream();
                    item.CopyTo(ms);
                    User.ProfilePic = ms.ToArray();
                }
            }

            _userService.Save(User);        
            return RedirectToAction("Index", "Post");       
        }
    }
}
