using BLL.Helpers;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.NewsModels;
using DAL.UnitOfWorks;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.BusinessLogics
{
    public class NewsLogic : INewsLogic
    {

        private readonly IUnitOfWork _unitOfWork;
        public NewsLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CreateNews(NewsViewModel newsModel)
        {
            bool check = false;
            if(newsModel != null)
            {
                News news = new News()
                {
                    NewsId = newsModel.NewsId,
                    NewsTitle = newsModel.NewsTitle,
                    NewsContent = newsModel.NewsContent,
                    DayOfPost = newsModel.DayOfPost,
                    ChannelId = newsModel.ChannelId,
                    LinkPicture = newsModel.LinkPicture
                };
                _unitOfWork.GetRepository<News>().Insert(news);
                _unitOfWork.Commit();
                check = true;

            }
            return check;
        }

        public bool DeleteNews(int id)
        {
            bool check = false;
            News news = _unitOfWork.GetRepository<News>().FindById(id);
            if (news != null)
            {
                news.IsActive = false;
                _unitOfWork.GetRepository<News>().Update(news);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public IQueryable<News> GetAllNews()
        {
            IQueryable<News> news = _unitOfWork.GetRepository<News>().GetAll();
            return news;
        }
        
        

        public News GetNewsById(int id)
        {
            News news = _unitOfWork.GetRepository<News>().FindById(id);
            return news;
        }

        public List<NewsViewModel> SearchNewsByTitle(string title, PagingModel pagingModel)
        {
            IEnumerable<NewsViewModel> newsModel = _unitOfWork
                .GetRepository<News>()
                .GetAll()
                .Where(a => a.NewsTitle.Contains(title))
                .Select(a => new NewsViewModel
                {
                    NewsId = a.NewsId,
                    NewsTitle = a.NewsTitle,
                    NewsContent = a.NewsContent
                });
            if(newsModel != null)
            {
                var paging = new Paging();
                if(title == null)
                {
                    title = "";
                }
                var searchTitle = title.ToLower();
                var result = new List<NewsViewModel>();
                result = newsModel
                    .Where(a => a.NewsTitle.ToLower().Contains(title))
                    .OrderBy(a => a.NewsTitle)
                    .Skip(paging.SkipItem(pagingModel.PageNumber, pagingModel.PageSize))
                    .Take(pagingModel.PageSize)
                    .ToList();
                if(result != null)
                {
                    return result;
                }


            }
            return null;

        }

        public bool UpdateNews(News news)
        {
            bool check = false;
            if(news != null)
            {
                _unitOfWork.GetRepository<News>().Update(news);
                _unitOfWork.Commit();
                check = true;
                
            }
            return check;

        }


   
    }
}
