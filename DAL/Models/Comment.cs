using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int? NewsId { get; set; }
        public int? UserId { get; set; }
        public string Comment1 { get; set; }
        public int? MasterCommentId { get; set; }

        public virtual News News { get; set; }
        public virtual User User { get; set; }
    }
}
