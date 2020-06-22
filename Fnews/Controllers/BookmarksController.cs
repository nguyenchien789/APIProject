using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models.BookMarkModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fnews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private readonly IBookMarkLogic _bookmarkLogic;

        public BookmarksController(IBookMarkLogic bookmarkLogic)
        {
            _bookmarkLogic = bookmarkLogic;
        }

        [HttpPost]
        public IActionResult CreateBookmark(BookMarkModel bookmarkModel)
        {
            if (bookmarkModel == null)
            {
                return BadRequest("null");
            }
            bool check = _bookmarkLogic.CreateNewBookMark(bookmarkModel);
            if (!check)
            {
                return BadRequest("Cannot create a new bookmark");
            }
            return Ok("Success");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookmark(int id)
        {
            var check = _bookmarkLogic.DeleteBookMark(id);
            if (!check)
            {
                return BadRequest("Error: Remove fail");
            }
            return Ok("Delete Successfully");
        }

    }
}
