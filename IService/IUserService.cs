using QuickPropForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPropForum.IService
{
    public interface IUserService
    {
        User Save(User oUser);
        User GetSavedUser();
        IEnumerable<User> GetAll();
    }
}
