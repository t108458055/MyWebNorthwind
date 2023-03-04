using System.Dynamic;
using System.Linq.Expressions;

public static class TreeViewHelpers
{
    private static string GetControllerName(Type controllerType)
    {
        var controllerName = controllerType.Name.EndsWith("Controller")
            ? controllerType.Name.Substring(0,
            controllerType.Name.Length - "Controller".Length)
            : controllerType.Name;
        return controllerName;
    }
    private static MethodCallExpression GetMethodCallExpression<TController>(Expression<Action<TController>> actionSelector)
    {
        var call = actionSelector.Body as MethodCallExpression;
        if (call == null)
        {
            throw new ArgumentException("You must call a method on " +
            typeof(TController).Name, "actionSelector");
        }
        return call;
    }
    // var methodCallExpression = GetMethodCallExpression(action);
    // var actionName = methodCallExpression.Method.Name;
    public static string Action<TController>(this IUrlHelper helper,Expression<Action<TController>> action)where TController : Controller
    {
        var controllerName = GetControllerName(typeof(TController));
        var methodCallExpression = GetMethodCallExpression(action);
        var actionName = methodCallExpression.Method.Name;
        var routes = RouteValueExtractor.GetRouteValues(methodCallExpression);
        var link = helper.Action(action: actionName, controller:
        controllerName, values: routes);
        return link;
    }
}

public class RouteValueExtractor
{
    public static object GetRouteValues(MethodCallExpression call)
    {
        var routes = new Dictionary<string, object>();
        var parameters = call.Method.GetParameters();
        var pairs = call.Arguments.Select((a, i) => new
        {
            Argument = a,
            ParamName = parameters[i].Name
        });
        foreach (var item in pairs)
        {
            string name = item.ParamName;
            object value = GetValue(item.Argument);
            if (value != null)
            {
                var valueType = value.GetType();
                if (valueType.IsValueType)
                {
                    routes.Add(name, value);
                }
                else
                {
                    throw new NotSupportedException("Unsupported parameter type {0}");
                }
            }
        }
        return DictionaryToObject(routes);
    }
    private static object GetValue(Expression expression)
    {
        if (expression.NodeType == ExpressionType.Constant)
        {
            return ((ConstantExpression)expression).Value;
        }
        throw new NotSupportedException("Unsupported parameter expression");
    }
    private static dynamic DictionaryToObject(IDictionary<string, object> dictionary)
    {
        var expandoObj = new ExpandoObject();
        var expandoObjCollection = (ICollection<KeyValuePair<string, object>>)expandoObj;
        foreach (var keyValuePair in dictionary)
        {
            expandoObjCollection.Add(keyValuePair);
        }
        dynamic eoDynamic = expandoObj;
        return eoDynamic;
    }
}