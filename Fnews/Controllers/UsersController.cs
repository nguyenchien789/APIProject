using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models.UserModels;
using DAL.Models;
//using Fnews.Models;
//using Fnews.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fnews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UsersController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            User user = _userLogic.GetUserById(id);
            if (user != null)
            {
                return NotFound("This user is not exist");
            }
            return Ok(user);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserUpdateModel userUpdate)
        {
            User user = _userLogic.GetUserById(userUpdate.UserId);
            if(user != null)
            {
                return NoContent();
            }
            user.Email = userUpdate.Email;
            user.UserTag = userUpdate.UserTag;
            _userLogic.UpdateUser(user);
            return Ok("User updated");
        }



    }

}
