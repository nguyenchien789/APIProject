using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.CommentModels
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int UserId { get; set; }
        public string Comment1 { get; set; }
    }
}
