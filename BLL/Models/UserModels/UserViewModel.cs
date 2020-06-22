using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models.UserModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserTag> UserTag { get; set; }

    }
}
