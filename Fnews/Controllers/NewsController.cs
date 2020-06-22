using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models.NewsModels;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fnews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsLogic _newsLogic;

        public NewsController(INewsLogic newsLogic)
        {
            _newsLogic = newsLogic;
        }
        [HttpGet("{id}")]
        public IActionResult GetNews(int id)
        {
            News news = _newsLogic.GetNewsById(id);
            if (news == null)
            {
                return NotFound("News is not found");
            }
            return Ok(news);
        }

        [HttpGet]
        public IActionResult GetAllNews()
        {
            List<News> news = _newsLogic.GetAllNews().ToList();
            if (news == null)
            {
                return BadRequest("Error");
            }
            if (news.Count == 0)
            {
                return NotFound();
            }
            return Ok(news);
        }


        [HttpPost]
        public IActionResult CreateNews(NewsViewModel newsCreate)
        {
            if (newsCreate == null)
            {
                return BadRequest("null");
            }
            bool check = _newsLogic.CreateNews(newsCreate);
            if (!check)
            {
                return BadRequest("Cannot create a new news");
            }
            return Ok("Success");
        }

        [HttpPut]
        public IActionResult UpdateNews([FromBody] News news)
        {
            News news1 = _newsLogic.GetNewsById(news.NewsId);
            if (news1 != null)
            {
                return NoContent();

            }
            news1.NewsTitle = news.NewsTitle;
            news1.NewsContent = news.NewsContent;
            news1.LinkPicture = news.LinkPicture;
            news1.DayOfPost = news.DayOfPost;
            news1.ChannelId = news.ChannelId;
            return Ok("Update Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNews(int id)
        {
            var check = _newsLogic.DeleteNews(id);
            if (!check)
            {
                return BadRequest("Error: Remove fail");
            }
            return Ok("Delete Successfully");
        }


    }
}
