using BLL.Models;
using BLL.Models.NewsModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    public interface INewsLogic
    {
        public IQueryable<News> GetAllNews();
        public News GetNewsById(int id);
        public List<NewsViewModel> SearchNewsByTitle(String title, PagingModel pagingModel);
        public bool CreateNews(NewsViewModel news);
        public bool UpdateNews(News news);
        public bool DeleteNews(int id);

    }
}
