using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Channel
    {
        public Channel()
        {
            News = new HashSet<News>();
            Subscribe = new HashSet<Subscribe>();
        }

        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
        public int? GroupId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Subscribe> Subscribe { get; set; }
    }
}
