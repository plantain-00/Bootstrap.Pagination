using System;

using Newtonsoft.Json.Linq;

namespace Bootstrap.Pagination
{
    /// <summary>
    ///     JObject扩展
    /// </summary>
    public static class JObjectExtension
    {
        /// <summary>
        ///     取属性值
        /// </summary>
        /// <param name="jObject"></param>
        /// <param name="propertyName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>(this JObject jObject, string propertyName)
        {
            try
            {
                return jObject[propertyName].ToObject<T>();
            }
            catch (Exception exception)
            {
                throw new JsonDeserializationException(propertyName, typeof (T).Name, "Error when get a property's value.", exception);
            }
        }
    }
}