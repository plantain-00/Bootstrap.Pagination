using System.IO;
using System.Text;
using System.Web.Mvc;

namespace Bootstrap.Pagination
{
    /// <summary>
    ///     Controller扩展
    /// </summary>
    public static class ControllerExtension
    {
        /// <summary>
        ///     部分视图转string
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public static string PartialViewToString(this Controller controller, string viewName)
        {
            return controller.PartialViewToString(viewName, null);
        }
        /// <summary>
        ///     部分视图转string
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string PartialViewToString(this Controller controller, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.RouteData.GetRequiredString("action");
            }
            controller.ViewData.Model = model;
            using (var stringWriter = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, stringWriter);
                viewResult.View.Render(viewContext, stringWriter);
                return stringWriter.GetStringBuilder().ToString();
            }
        }
        /// <summary>
        ///     Controller.Json的替代
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ActionResult NewtonJson(this ControllerBase controller, object obj)
        {
            return NewtonJson(controller, null, null, JsonRequestBehavior.DenyGet, obj);
        }
        /// <summary>
        ///     Controller.Json的替代
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="encoding"></param>
        /// <param name="contentType"></param>
        /// <param name="jsonRequestBehavior"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ActionResult NewtonJson(this ControllerBase controller, Encoding encoding, string contentType, JsonRequestBehavior jsonRequestBehavior, object obj)
        {
            return new NewtonJsonResult
                   {
                       ContentEncoding = encoding,
                       ContentType = contentType,
                       JsonRequestBehavior = jsonRequestBehavior,
                       Data = obj
                   };
        }
        /// <summary>
        ///     Controller.Json的替代
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="obj"></param>
        /// <param name="jsonRequestBehavior"></param>
        /// <returns></returns>
        public static ActionResult NewtonJson(this ControllerBase controller, object obj, JsonRequestBehavior jsonRequestBehavior)
        {
            return NewtonJson(controller, null, null, jsonRequestBehavior, obj);
        }
        /// <summary>
        ///     Controller.Json的替代
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="obj"></param>
        /// <param name="encoding"></param>
        /// <param name="jsonRequestBehavior"></param>
        /// <returns></returns>
        public static ActionResult NewtonJson(this ControllerBase controller, object obj, Encoding encoding, JsonRequestBehavior jsonRequestBehavior)
        {
            return NewtonJson(controller, encoding, null, jsonRequestBehavior, obj);
        }
        /// <summary>
        ///     Controller.Json的替代
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="obj"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static ActionResult NewtonJson(this ControllerBase controller, object obj, string contentType)
        {
            return NewtonJson(controller, null, contentType, JsonRequestBehavior.DenyGet, obj);
        }
        /// <summary>
        ///     Controller.Json的替代
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="obj"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static ActionResult NewtonJson(this ControllerBase controller, object obj, Encoding encoding)
        {
            return NewtonJson(controller, encoding, null, JsonRequestBehavior.DenyGet, obj);
        }
        /// <summary>
        ///     Controller.Json的替代
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="obj"></param>
        /// <param name="encoding"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static ActionResult NewtonJson(this ControllerBase controller, object obj, Encoding encoding, string contentType)
        {
            return NewtonJson(controller, encoding, contentType, JsonRequestBehavior.DenyGet, obj);
        }
        /// <summary>
        ///     Controller.Json的替代
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="obj"></param>
        /// <param name="encoding"></param>
        /// <param name="contentType"></param>
        /// <param name="jsonRequestBehavior"></param>
        /// <returns></returns>
        public static ActionResult NewtonJson(this ControllerBase controller, object obj, Encoding encoding, string contentType, JsonRequestBehavior jsonRequestBehavior)
        {
            return NewtonJson(controller, encoding, contentType, jsonRequestBehavior, obj);
        }
    }
}