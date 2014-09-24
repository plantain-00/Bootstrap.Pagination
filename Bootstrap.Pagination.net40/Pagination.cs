using System;

namespace Bootstrap.Pagination
{
    /// <summary>
    ///     对应Bootstrap pagination
    /// </summary>
    public class Pagination
    {
        /// <summary>
        ///     由总条数、当前页、当前组、每组的页数、每页的条数构造Pagination对象
        /// </summary>
        /// <param name="totalItems">总条数</param>
        /// <param name="page">当前页，从1开始</param>
        /// <param name="pagesPerGroup">每组的页数</param>
        /// <param name="itemsPerPage">每页的条数</param>
#pragma warning disable 612
        public Pagination(int totalItems, int page, int pagesPerGroup = 5, int itemsPerPage = 10) : this(totalItems, page - (page - 1) / pagesPerGroup * pagesPerGroup, (page - 1) / pagesPerGroup + 1, pagesPerGroup, itemsPerPage)
#pragma warning restore 612
        {
        }

        /// <summary>
        ///     由总条数、当前页、当前组、每组的页数、每页的条数构造Pagination对象
        /// </summary>
        /// <param name="totalItems">总条数</param>
        /// <param name="page">当前页，从1开始</param>
        /// <param name="group">当前组，从1开始</param>
        /// <param name="pagesPerGroup">每组的页数</param>
        /// <param name="itemsPerPage">每页的条数</param>
        [Obsolete]
        public Pagination(int totalItems, int page, int group, int pagesPerGroup = 5, int itemsPerPage = 10)
        {
            TotalItems = totalItems;
            ItemsPerPage = itemsPerPage;
            PagesPerGroup = pagesPerGroup;
            Page = page;
            Group = group;
            if (totalItems == 0)
            {
                PagesOfLastGroup = 1;
                TotalGroups = 1;
                TotalPages = 1;
            }
            else
            {
                TotalGroups = (totalItems - 1) / (itemsPerPage * pagesPerGroup) + 1;
                //最后一组的条数
                var tmp = totalItems - (TotalGroups - 1) * itemsPerPage * pagesPerGroup;
                PagesOfLastGroup = (tmp - 1) / itemsPerPage + 1;
                TotalPages = (totalItems - 1) / itemsPerPage + 1;
            }
        }

        /// <summary>
        ///     总页数
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        ///     总条数
        /// </summary>
        public int TotalItems { get; private set; }

        /// <summary>
        ///     总组数
        /// </summary>
        public int TotalGroups { get; private set; }

        /// <summary>
        ///     每页的条数
        /// </summary>
        public int ItemsPerPage { get; private set; }

        /// <summary>
        ///     最后一组的页数
        /// </summary>
        public int PagesOfLastGroup { get; private set; }

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
        ///     当前页中，由从0开始的条的索引，应该Skip这些数目条数据
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public int Skipped
        {
            get
            {
                return ItemsPerPage * (Page - 1 + PagesPerGroup * (Group - 1));
            }
        }

        /// <summary>
        ///     是否是第一组
        /// </summary>
        /// <returns></returns>
        public bool IsFirstGroup
        {
            get
            {
                return Group == 1;
            }
        }
        /// <summary>
        ///     是否是最后一组
        /// </summary>
        /// <returns></returns>
        public bool IsLastGroup
        {
            get
            {
                return Group == TotalGroups;
            }
        }
        /// <summary>
        ///     当前组的页数
        /// </summary>
        /// <returns></returns>
        public int CurrentPageCount
        {
            get
            {
                return IsLastGroup ? PagesOfLastGroup : PagesPerGroup;
            }
        }

        /// <summary>
        ///     当前页
        /// </summary>
        /// <returns></returns>
        public int CurrentPage
        {
            get
            {
                return Page + PagesPerGroup * (Group - 1);
            }
        }
        /// <summary>
        ///     上一组所在页
        /// </summary>
        public int LastGroup
        {
            get
            {
                return PagesPerGroup + PagesPerGroup * (Group - 1 - 1);
            }
        }
        /// <summary>
        ///     下一组所在页
        /// </summary>
        public int NextGroup
        {
            get
            {
                return 1 + PagesPerGroup * (Group + 1 - 1);
            }
        }

        /// <summary>
        ///     当前页中，由从0开始的条的索引，应该Skip这些数目条数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="itemsPerPage"></param>
        /// <returns></returns>
        public static int GetSkipped(int page, int itemsPerPage = 10)
        {
            return (page - 1) * itemsPerPage;
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
            return item + 1 + ItemsPerPage * (Page - 1 + PagesPerGroup * (Group - 1));
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
    }
}