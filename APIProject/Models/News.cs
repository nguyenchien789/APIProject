using System;
using System.Collections.Generic;

namespace APIProject.Models
{
    public partial class News
    {
        public News()
        {
            Bookmark = new HashSet<Bookmark>();
            Comment = new HashSet<Comment>();
            NewsTag = new HashSet<NewsTag>();
        }

        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public DateTime? DayOfPost { get; set; }
        public int? ChannelId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Channel Channel { get; set; }
        public virtual ICollection<Bookmark> Bookmark { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<NewsTag> NewsTag { get; set; }
    }
}
