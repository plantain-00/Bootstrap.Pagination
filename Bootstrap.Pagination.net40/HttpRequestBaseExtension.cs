#if !NET35 && !NET30 && !NET20
using System;
using System.Linq;
#endif
using System.Web;

namespace Bootstrap.Pagination
{
    /// <summary>
    ///     定义了HttpRequestBase对象的扩展方法
    /// </summary>
    public static class HttpRequestBaseExtension
    {
#if !NET35 && !NET30 && !NET20
        /// <summary>
        ///     由key查询Guid
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Guid QueryGuid(this HttpRequestBase request, string key)
        {
            return Guid.Parse(request.QueryString[key]);
        }
        /// <summary>
        ///     由key查询Guid?
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Guid? QueryNullableGuid(this HttpRequestBase request, string key)
        {
            var id = request.QueryString[key];
            return string.IsNullOrEmpty(id) ? null as Guid? : Guid.Parse(id);
        }
#endif
        /// <summary>
        ///     由key查询string
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
#if NET35
        public static string QueryString(this HttpRequest request, string key)
#elif NET30 || NET20
        public static string QueryString(HttpRequest request, string key)
#else
        public static string QueryString(this HttpRequest request, string key)
        {
            return request.QueryString[key];
        }
        /// <summary>
        ///     由key查询string
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string QueryString(this HttpRequestBase request, string key)
#endif
        {
            return request.QueryString[key];
        }
        /// <summary>
        ///     由key查询int，如果为空，或者无效，返回指定的默认值，或者1
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
#if NET35
        public static int QueryInt32(this HttpRequest request, string key, int defaultValue = 1)
#elif NET30 || NET20
        public static int QueryInt32(HttpRequest request, string key, int defaultValue = 1)
#else
        public static int QueryInt32(this HttpRequest request, string key, int defaultValue = 1)
        {
            if (string.IsNullOrEmpty(key))
            {
                return defaultValue;
            }
            int result;
            return int.TryParse(request.QueryString[key], out result) ? result : defaultValue;
        }
        /// <summary>
        ///     由key查询int，如果为空，或者无效，返回指定的默认值，或者1
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int QueryInt32(this HttpRequestBase request, string key, int defaultValue = 1)
#endif
        {
            if (string.IsNullOrEmpty(key))
            {
                return defaultValue;
            }
            int result;
            return int.TryParse(request.QueryString[key], out result) ? result : defaultValue;
        }
#if !NET35 && !NET30 && !NET20
        /// <summary>
        ///     由key查询按divider字符分隔的Guid[]
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <param name="divider"></param>
        /// <returns></returns>
        public static Guid[] QueryGuidArray(this HttpRequestBase request, string key, char divider = ',')
        {
            return request.QueryString[key].TrimEnd(divider).Split(divider).Select(Guid.Parse).ToArray();
        }
#endif
    }
}