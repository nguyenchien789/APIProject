using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.NewsModels
{
    public class NewsViewModel
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public DateTime DayOfPost { get; set; }
        public int ChannelId { get; set; }
        public byte[] LinkPicture { get; set; }
    }
}
