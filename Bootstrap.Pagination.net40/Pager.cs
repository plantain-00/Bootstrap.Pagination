using System;

namespace Bootstrap.Pagination
{
    /// <summary>
    ///     对应Bootstrap pager
    /// </summary>
    public class Pager
    {
        /// <summary>
        ///     由总条数、当前页、每页的条数构造Pager对象
        /// </summary>
        /// <param name="totalItems">总条数</param>
        /// <param name="page">当前页</param>
        /// <param name="itemsPerPage">每页的条数</param>
        public Pager(int totalItems, int page, int itemsPerPage = 10)
        {
            Page = page;
            ItemsPerPage = itemsPerPage;
            TotalPages = (totalItems - 1) / itemsPerPage + 1;
        }

        /// <summary>
        ///     每页的条数
        /// </summary>
        public int ItemsPerPage { get; private set; }

        /// <summary>
        ///     总页数
        /// </summary>
        public int TotalPages { get; private set; }

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
                return Page == TotalPages;
            }
        }
        /// <summary>
        ///     当前页中，由从0开始的条的索引，应该Skip这些数目条数据
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public int Skipped
        {
            get
            {
                return ItemsPerPage * (Page - 1);
            }
        }

        /// <summary>
        ///     当前页中，由从0开始的条的索引，应该Skip这些数目条数据
        /// </summary>
        /// <returns></returns>
        public static int GetSkipped(int page, int itemsPerPage = 10)
        {
            return (page - 1) * itemsPerPage;
        }
    }
}