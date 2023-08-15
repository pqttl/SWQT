namespace SWQT._512ViewModels.Common
{
    public class PagingRequestBase
    {
        public int IntPageIndex { get; set; }

        public int IntPageSize { get; set; }

        /// <summary>
        /// Gồm mobile, pc, tablet, ... mặc định là mobile
        /// </summary>
        public string StrTypeDevice { get; set; }

    }
}
