using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Bookmark
    {
        public int UserId { get; set; }
        public int NewsId { get; set; }

        public virtual News News { get; set; }
        public virtual User User { get; set; }
    }
}
