using Newtonsoft.Json;

namespace Bootstrap.Pagination
{
    /// <summary>
    ///     查询的结果模型
    /// </summary>
    public class QueryResult<T>
    {
        /// <summary>
        ///     构造查询的结果模型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isSuccess"></param>
        /// <param name="message"></param>
        /// <param name="exceptionMessage"></param>
        public QueryResult(T value, bool isSuccess = true, string message = null, string exceptionMessage = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            ExceptionMessage = exceptionMessage;
            Value = value;
        }

        /// <summary>
        ///     查询是否成功
        /// </summary>
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        /// <summary>
        ///     消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        ///     异常消息
        /// </summary>
        [JsonProperty("exceptionMessage")]
        public string ExceptionMessage { get; set; }

        /// <summary>
        ///     查询结果的值
        /// </summary>
        [JsonProperty("value")]
        public T Value { get; set; }
    }
}