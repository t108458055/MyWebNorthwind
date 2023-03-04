using System.Data;

namespace MyWebNorthwind.Common
{
    public static class DataReaderExtensions
    { // https://www.codemag.com/Article/2207021/Simplifying-ADO.NET-Code-in-.NET-6-Part-1
        // https://refactoringguru.cn/design-patterns/template-method/csharp/example
        public static T GetData<T>(this IDataReader dataReader, string content, T returnValue = default)
        {
            var value = dataReader[content];
            if (!value.Equals(DBNull.Value))
            { 
                returnValue = (T) value;
            }
            return returnValue;
        }

    }
}
