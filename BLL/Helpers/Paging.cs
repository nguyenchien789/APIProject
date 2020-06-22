using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers
{
    public class Paging
    {
        public int SkipItem(int pageNuber, int pageSize)
        {
            int result;

            if (pageNuber < 1 || pageSize < 1)
            {
                return -1;
            }
            result = (pageNuber - 1) * pageSize;
            return result;
        }

        public int GetPageTotal(int pageNumber, int pageSize)
        {
            if (pageSize < 1)
            {
                return -1;
            }

            int numOfPage = pageNumber / pageSize;
            int itemLeft = pageNumber % pageSize;

            if (itemLeft != 0)
            {
                numOfPage++;
            }
            return numOfPage;
        }

    }
}
