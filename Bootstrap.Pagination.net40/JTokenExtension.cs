using System;

using Newtonsoft.Json.Linq;

namespace Bootstrap.Pagination
{
    /// <summary>
    ///     JToken扩展
    /// </summary>
    public static class JTokenExtension
    {
        /// <summary>
        ///     取属性值
        /// </summary>
        /// <param name="jToken"></param>
        /// <param name="propertyName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>(this JToken jToken, string propertyName)
        {
            try
            {
                return jToken[propertyName].ToObject<T>();
            }
            catch (Exception exception)
            {
                throw new JsonDeserializationException(propertyName, typeof (T).Name, "Error when get a property's value.", exception);
            }
        }

        /// <summary>
        ///     取字符串属性值
        /// </summary>
        /// <param name="jToken"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string Get(this JToken jToken, string propertyName)
        {
            return jToken.Get<string>(propertyName);
        }

        /// <summary>
        ///     是否有此Key
        /// </summary>
        /// <param name="jToken"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool HasKey(this JToken jToken, string propertyName)
        {
            return jToken[propertyName] != null;
        }

        /// <summary>
        ///     是否有为null
        /// </summary>
        /// <param name="jToken"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool IsNotNull(this JToken jToken, string propertyName)
        {
            return jToken.HasKey(propertyName) && jToken.Get(propertyName) != null;
        }
    }
}