using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.UserModels
{
    public class UserUpdateModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserTag> UserTag { get; set; }
    }
}
