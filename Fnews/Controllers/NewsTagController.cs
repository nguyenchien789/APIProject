using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models.NewsTagModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fnews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsTagController : ControllerBase
    {
        private readonly INewTagLogic _newsTagLogic;

        public NewsTagController(INewTagLogic newsTagLogic)
        {
            _newsTagLogic = newsTagLogic;
        }
        [HttpPost]
        public IActionResult CreateNewsTag(NewsTagModel newsTagModel)
        {
            if (newsTagModel == null)
            {
                return BadRequest("null");
            }
            bool check = _newsTagLogic.CreateTagNews(newsTagModel);
            if (!check)
            {
                return BadRequest("Cannot create a new tag of news");
            }
            return Ok("Success");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNewsTag(int id)
        {
            var check = _newsTagLogic.DeleteTagNews(id);
            if (!check)
            {
                return BadRequest("Error: Remove fail");
            }
            return Ok("Delete Successfully");
        }

    }
}
