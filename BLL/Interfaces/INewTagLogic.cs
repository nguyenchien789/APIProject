using BLL.Models.NewsTagModel;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BLL.Interfaces
{
    public interface INewTagLogic
    {
        public bool DeleteTagNews(int tagId);
        public bool CreateTagNews(NewsTagModel newsTag);
    }
}
