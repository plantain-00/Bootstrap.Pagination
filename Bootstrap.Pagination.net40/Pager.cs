namespace Bootstrap.Pagination
{
    /// <summary>
    ///     对应Bootstrap pager
    /// </summary>
    public class Pager
    {
        private readonly int _itemsPerPage;
        private readonly int _pageCount;
        /// <summary>
        ///     由总条数、当前页、每页的条数构造Pager对象
        /// </summary>
        /// <param name="totalItems"></param>
        /// <param name="page"></param>
        /// <param name="itemsPerPage"></param>
        public Pager(int totalItems, int page, int itemsPerPage)
        {
            Page = page;
            _itemsPerPage = itemsPerPage;
            _pageCount = (totalItems - 1) / itemsPerPage + 1;
        }
        /// <summary>
        ///     当前页,从1开始
        /// </summary>
        public int Page { get; private set; }
        /// <summary>
        ///     是否是第1页
        /// </summary>
        /// <returns></returns>
        public bool IsFirstPage
        {
            get
            {
                return Page == 1;
            }
        }
        /// <summary>
        ///     是否是最后1页
        /// </summary>
        /// <returns></returns>
        public bool IsLastPage
        {
            get
            {
                return Page == _pageCount;
            }
        }
        /// <summary>
        ///     当前页中，由从0开始的条的索引
        /// </summary>
        /// <returns></returns>
        public int ItemIndex
        {
            get
            {
                return _itemsPerPage * (Page - 1);
            }
        }
    }
}