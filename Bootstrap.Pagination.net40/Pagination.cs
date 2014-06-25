namespace Bootstrap.Pagination
{
    /// <summary>
    ///     对应Bootstrap pagination
    /// </summary>
    public class Pagination
    {
        private readonly int _groupCount;
        private readonly int _itemsPerPage;
        private readonly int _pageCount;
        private readonly int _pagesPerGroup;
        /// <summary>
        ///     由总条数、当前页、当前组、每组的页数、每页的条数构造Pagination对象
        /// </summary>
        /// <param name="totalItems"></param>
        /// <param name="page"></param>
        /// <param name="group"></param>
        /// <param name="pagesPerGroup"></param>
        /// <param name="itemsPerPage"></param>
        public Pagination(int totalItems, int page, int group, int pagesPerGroup, int itemsPerPage)
        {
            _pagesPerGroup = pagesPerGroup;
            _itemsPerPage = itemsPerPage;
            PagesPerGroup = pagesPerGroup;
            Page = page;
            Group = group;
            if (totalItems == 0)
            {
                _pageCount = 1;
                _groupCount = 1;
            }
            else
            {
                _groupCount = (totalItems - 1) / (itemsPerPage * pagesPerGroup) + 1;
                var tmp = totalItems - (_groupCount - 1) * itemsPerPage * pagesPerGroup;
                _pageCount = (tmp - 1) / itemsPerPage + 1;
            }
        }
        /// <summary>
        ///     当前页，从1开始
        /// </summary>
        public int Page { get; private set; }
        /// <summary>
        ///     每组的页数
        /// </summary>
        public int PagesPerGroup { get; private set; }
        /// <summary>
        ///     当前组，从1开始
        /// </summary>
        public int Group { get; private set; }
        /// <summary>
        ///     是否是第一组
        /// </summary>
        /// <returns></returns>
        public bool IsFirstGroup()
        {
            return Group == 1;
        }
        /// <summary>
        ///     是否是最后一组
        /// </summary>
        /// <returns></returns>
        public bool IsLastGroup()
        {
            return Group == _groupCount;
        }
        /// <summary>
        ///     由当前组中页从0开始的索引，获得实际表示的页
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public int GetPageIndex(int page)
        {
            return page + PagesPerGroup * (Group - 1) + 1;
        }
        /// <summary>
        ///     由当前页中条从0开始的索引，获得实际表示的条
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int GetItemIndex(int item)
        {
            return item + 1 + _itemsPerPage * (Page - 1 + _pagesPerGroup * (Group - 1));
        }
        /// <summary>
        ///     当前组的页数
        /// </summary>
        /// <returns></returns>
        public int GetCurrentPageCount()
        {
            return IsLastGroup() ? _pageCount : PagesPerGroup;
        }
        /// <summary>
        ///     从0开始的页的索引是否是当前页
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public bool IsCurrentPage(int page)
        {
            return page + 1 == Page;
        }
        /// <summary>
        ///     由从0开始的条的索引,获得之前需要Skip的条数
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Skip(int item)
        {
            return item + _itemsPerPage * (Page - 1 + _pagesPerGroup * (Group - 1));
        }
    }
}