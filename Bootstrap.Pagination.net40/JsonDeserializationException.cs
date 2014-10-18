using System;

namespace Bootstrap.Pagination
{
    /// <summary>
    ///     Json反序列化异常
    /// </summary>
    public class JsonDeserializationException : Exception
    {
        /// <summary>
        ///     构造JsonDeserializationException对象
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="typeName"></param>
        public JsonDeserializationException(string propertyName, string typeName)
        {
            PropertyName = propertyName;
            TypeName = typeName;
        }

        /// <summary>
        ///     构造JsonDeserializationException对象
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="typeName"></param>
        /// <param name="message"></param>
        public JsonDeserializationException(string propertyName, string typeName, string message) : base(message)
        {
            PropertyName = propertyName;
            TypeName = typeName;
        }

        /// <summary>
        ///     构造JsonDeserializationException对象
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="typeName"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public JsonDeserializationException(string propertyName, string typeName, string message, Exception innerException) : base(message, innerException)
        {
            PropertyName = propertyName;
            TypeName = typeName;
        }

        /// <summary>
        ///     属性名
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        ///     转换目标类型名
        /// </summary>
        public string TypeName { get; set; }
    }
}