using System;
using System.Collections.Generic;

namespace APIProject.Models
{
    public partial class User
    {
        public User()
        {
            Bookmark = new HashSet<Bookmark>();
            Comment = new HashSet<Comment>();
            Subscribe = new HashSet<Subscribe>();
            UserTag = new HashSet<UserTag>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public bool? IsAdmin { get; set; }
        public int? GroupId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<Bookmark> Bookmark { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Subscribe> Subscribe { get; set; }
        public virtual ICollection<UserTag> UserTag { get; set; }
    }
}
