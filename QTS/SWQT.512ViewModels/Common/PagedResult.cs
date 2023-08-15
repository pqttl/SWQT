using System.Collections.Generic;

namespace SWQT._512ViewModels.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> LstTItems { set; get; } = new List<T>();

        public T TOneItem { set; get; }
    }
}
