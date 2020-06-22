using BLL.Interfaces;
using BLL.Models.NewsTagModel;
using DAL.UnitOfWorks;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessLogics
{
    public class NewTagLogic : INewTagLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public NewTagLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CreateTagNews(NewsTagModel newsTagModel)
        {
            bool check = false;
            if (newsTagModel != null)
            {
                NewsTag newTag = new NewsTag()
                {
                    TagId = newsTagModel.TagId,
                    NewsId = newsTagModel.NewsId,
                };
                _unitOfWork.GetRepository<NewsTag>().Insert(newTag);
                _unitOfWork.Commit();
                check = true;

            }
            return check;
        }

        public bool DeleteTagNews(int tagId)
        {
            bool check = false;
            NewsTag newsTag = _unitOfWork.GetRepository<NewsTag>().FindById(tagId);
            if (newsTag != null)
            {

                _unitOfWork.GetRepository<NewsTag>().Delete(newsTag);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }
    }
}
