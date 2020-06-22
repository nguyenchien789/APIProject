using BLL.Models.UserModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUserLogic
    {
        public User GetUserById(int id);
        public bool UpdateUser(User user);

    }
}
