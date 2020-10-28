using KDSoft.Application.Base.Data;
using System.Reflection;

namespace KDSoft.Application.Data.Helpers
{
    public static class PropertyHelper
    {
        #region Property Format 

        public static string FieldFormat(this PropertyInfo property)
        {
            string column = DbColumnName(property);

            if (string.IsNullOrEmpty(column))
                column = property.Name;

            return column;
        }

        #endregion

        #region Value Format
        
        public static bool BooleanToAppFormat(this object value)
        {
            return value != null && ((string)value).BooleanToAppFormat();
        }

        public static bool BooleanToAppFormat(this string value)
        {
            return value != null && (!value.Equals("N"));
        }

        #endregion

        #region Attributes

        public static string DbColumnName(this PropertyInfo property)
        {
            var attr = property.GetCustomAttribute<DbColumnAttribute>();
            return attr?.Name;
        }

        public static bool DbIgnore(this PropertyInfo property)
        {
            var attr = property.GetCustomAttribute<DbIgnoreAttribute>();
            return attr != null;
        }

        #endregion
    }
}
