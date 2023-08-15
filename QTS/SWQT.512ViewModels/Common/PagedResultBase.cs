using System;

namespace SWQT._512ViewModels.Common
{
    public class PagedResultBase : PagingRequestBase
    {

        //public int IntPageIndex { get; set; }

        //public int IntPageSize { get; set; }

        public int IntTotalRecords { get; set; }

        public int IntSumPage
        {
            get
            {
                var pageCount = (double)IntTotalRecords / IntPageSize;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}
