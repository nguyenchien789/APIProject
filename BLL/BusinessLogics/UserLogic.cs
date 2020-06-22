using BLL.Interfaces;
using BLL.Models.UserModels;
using DAL.UnitOfWorks;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessLogics
{
    public class UserLogic : IUserLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public User GetUserById(int id)
        {
            User user = _unitOfWork.GetRepository<User>().FindById(id);
            return user;
        }

        public bool UpdateUser(User user)
        {
            bool check = false;
            if(user != null)
            {
                _unitOfWork.GetRepository<User>().Update(user);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }
    }
}
