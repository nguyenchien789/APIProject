using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Tag
    {
        public Tag()
        {
            NewsTag = new HashSet<NewsTag>();
            UserTag = new HashSet<UserTag>();
        }

        public int TagId { get; set; }
        public string TagName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<NewsTag> NewsTag { get; set; }
        public virtual ICollection<UserTag> UserTag { get; set; }
    }
}
