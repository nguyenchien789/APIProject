using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class NewsTag
    {
        public int TagId { get; set; }
        public int NewsId { get; set; }

        public virtual News News { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
