using QuickPropForum.Data;
using QuickPropForum.IService;
using QuickPropForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPropForum.Service
{
    public class UserService : IUserService
    {
        private readonly QuickPropForumDBContext _context;

       
        public UserService(QuickPropForumDBContext context)
        {
            _context = context;
        }

        public User Save(User oUser)
        {
            _context.Add(oUser);
            _context.SaveChanges();
            return oUser;
        }

        public User GetSavedUser()
        {
            return _context.Users.FirstOrDefault();
        }

       

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

       
    }
}
