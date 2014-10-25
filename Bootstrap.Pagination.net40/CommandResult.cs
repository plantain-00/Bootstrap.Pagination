using Newtonsoft.Json;

namespace Bootstrap.Pagination
{
    /// <summary>
    ///     命令的结果模型
    /// </summary>
    public class CommandResult
    {
        /// <summary>
        ///     构造命令的结果模型
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="message"></param>
        /// <param name="exceptionMessage"></param>
        public CommandResult(bool isSuccess, string message = null, string exceptionMessage = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            ExceptionMessage = exceptionMessage;
        }

        /// <summary>
        ///     是否执行成功
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
    }
}