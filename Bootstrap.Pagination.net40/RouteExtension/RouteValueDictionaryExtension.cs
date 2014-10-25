using System.Web.Routing;

namespace Bootstrap.Pagination
{
    /// <summary>
    ///     RouteValueDictionary的扩展，用于自定义路由
    /// </summary>
    public static class RouteValueDictionaryExtension
    {
        /// <summary>
        ///     是否controller
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static bool HasController(this RouteValueDictionary dictionary, string controller)
        {
            return (dictionary["controller"] as string).IsSameController(controller);
        }

        /// <summary>
        ///     是否有action
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool HasAction(this RouteValueDictionary dictionary, string action)
        {
            return (dictionary["action"] as string).Is(action);
        }

        /// <summary>
        ///     是否是controller下的action
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool HasAction(this RouteValueDictionary dictionary, string controller, string action)
        {
            return dictionary.HasController(controller) && dictionary.HasAction(action);
        }

        /// <summary>
        ///     添加controller
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="controller"></param>
        public static void AddController(this RouteValueDictionary dictionary, string controller)
        {
            dictionary.Add("controller", controller);
        }

        /// <summary>
        ///     添加action
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="controller"></param>
        public static void AddAction(this RouteValueDictionary dictionary, string controller)
        {
            dictionary.Add("action", controller);
        }
    }
}