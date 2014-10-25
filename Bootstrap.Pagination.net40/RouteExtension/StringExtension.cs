using System;

namespace Bootstrap.Pagination
{
    /// <summary>
    ///     string的扩展，用于自定义路由
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        ///     是否是同一个Controller
        /// </summary>
        /// <param name="controller1"></param>
        /// <param name="controller2"></param>
        /// <returns></returns>
        public static bool IsSameController(this string controller1, string controller2)
        {
            if (string.Equals(controller1, controller2, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            if (string.Equals(controller1 + "Controller", controller2, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            if (string.Equals(controller1, controller2 + "Controller", StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     是否不区分大小写相等
        /// </summary>
        /// <param name="string1"></param>
        /// <param name="string2"></param>
        /// <returns></returns>
        public static bool Is(this string string1, string string2)
        {
            return string.Equals(string1, string2, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}