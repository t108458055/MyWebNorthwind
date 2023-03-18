using Microsoft.AspNetCore.Mvc.Filters;

namespace MyWebNorthwind.Attributes
{
    public class LogInSecurityAttribute: ActionFilterAttribute // 繼承 一個安全屬性
    {
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext) 
        {
            OnActionExecuting(actionExecutingContext);
            HttpContext httpContext = actionExecutingContext.HttpContext; 
            HttpRequest httpRequest= httpContext.Request;// 取出封裝前端所有的資訊Request的物件
            QueryString queryString= httpRequest.QueryString;  //取出Cookie 內容
            string credValue = httpRequest.Cookies[".cred"]; //取出Cookie 內容 值 .cred
            if (String.IsNullOrEmpty(credValue))
            {
                //建構一個新的HttpResponse物件,換掉原先配對的Response
                actionExecutingContext.Result = new UnauthorizedObjectResult("沒有通行憑證");
            }
            else
            {
                // 合法 TODO
            }
        }

    }
}
