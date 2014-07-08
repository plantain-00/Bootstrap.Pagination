using System;
using System.Web.Mvc;

using Newtonsoft.Json;

namespace Bootstrap.Pagination
{
    /// <summary>
    ///     JsonResult的扩展，用NewtonJson来序列化
    /// </summary>
    public class NewtonJsonResult : JsonResult
    {
        /// <summary>
        ///     构造NewtonJsonResult
        /// </summary>
        public NewtonJsonResult()
        {
            JsonRequestBehavior = JsonRequestBehavior.DenyGet;
        }
        /// <summary>
        ///     构造NewtonJsonResult
        /// </summary>
        /// <param name="obj"></param>
        public NewtonJsonResult(object obj)
        {
            JsonRequestBehavior = JsonRequestBehavior.DenyGet;
            Data = obj;
        }
        /// <summary>
        ///     构造NewtonJsonResult
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="jsonSerializerSettings"></param>
        public NewtonJsonResult(object obj, JsonSerializerSettings jsonSerializerSettings)
        {
            JsonRequestBehavior = JsonRequestBehavior.DenyGet;
            Data = obj;
            JsonSerializerSettings = jsonSerializerSettings;
        }
        /// <summary>
        ///     JsonConvert.SerializeObject的第二个参数
        /// </summary>
        public JsonSerializerSettings JsonSerializerSettings { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if ((JsonRequestBehavior == JsonRequestBehavior.DenyGet)
                && (string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("改方法当前不允许使用Get");
            }
            var response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data != null)
            {
                var strJson = JsonConvert.SerializeObject(Data, JsonSerializerSettings);
                response.Write(strJson);
                response.End();
            }
        }
    }
}