using BLL.Models.BookMarkModels;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IBookMarkLogic
    {
        public bool CreateNewBookMark(BookMarkModel bookMark);
        public bool DeleteBookMark(int id);

    }
}
