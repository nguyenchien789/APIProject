using BLL.Interfaces;
using BLL.Models.BookMarkModels;
using DAL.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace BLL.BusinessLogics
{
    public class BookMarkLogic : IBookMarkLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookMarkLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CreateNewBookMark(BookMarkModel bookMark)
        {
            bool check = false;
            if (bookMark != null)
            {
                Bookmark bookmark = new Bookmark()
                {
                    UserId = bookMark.UserId,
                    NewsId = bookMark.NewsId,
                };
                _unitOfWork.GetRepository<Bookmark>().Insert(bookmark);
                _unitOfWork.Commit();
                check = true;

            }
            return check;
        }

        public bool DeleteBookMark(int id)
        {
            bool check = false;
            Bookmark bookmark = _unitOfWork.GetRepository<Bookmark>().FindById(id);
            if (bookmark != null)
            {
 
                _unitOfWork.GetRepository<Bookmark>().Delete(bookmark);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }
    }
}
