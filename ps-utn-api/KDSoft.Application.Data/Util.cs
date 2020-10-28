using KDSoft.Application.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace KDSoft.Application.Data
{
    class Util
    {
        public static bool IsPersistent(PropertyInfo propertyInfo)
        {
            Type t = propertyInfo.PropertyType;

            if (!propertyInfo.CanWrite)
                return true;
            //validar
            var genArgs = t.GetGenericArguments();
            if (genArgs.Length == 1 && typeof(List<>).MakeGenericType(genArgs).IsAssignableFrom(t))
                return true;

            return false;
        }

        public static bool IsNullable(Type t)
        {
            var genArgs = t.GetGenericArguments();

            if (genArgs.Length == 1 && typeof(Nullable<>).MakeGenericType(genArgs).IsAssignableFrom(t))
                return true;

            return t.BaseType != null && IsNullable(t.BaseType);
        }

        public static Type GetNullableType(Type t)
        {
            var genArgs = t.GetGenericArguments();

            if (genArgs.Length == 1 && typeof(Nullable<>).MakeGenericType(genArgs).IsAssignableFrom(t))
                return genArgs[0];

            if (t.BaseType != null)
                return GetNullableType(t.BaseType);

            return null;
        }

        public static bool IsNullOrDefault<T>(T argument)
        {
            // deal with normal scenarios
            if (argument == null) return true;
            if (object.Equals(argument, default(T))) return true;

            // deal with non-null nullables
            Type methodType = typeof(T);
            if (Nullable.GetUnderlyingType(methodType) != null) return false;

            // deal with boxed value types
            Type argumentType = argument.GetType();
            if (argumentType.IsValueType && argumentType != methodType)
            {
                object obj = Activator.CreateInstance(argument.GetType());
                return obj.Equals(argument);
            }

            return false;
        }

        public static object GetPropertyValue(object entity, PropertyInfo property, Type propertyType = null)
        {
            //Verifica si la propiedad se debe ignorar
            if (property.DbIgnore()) return null;

            var culture = GetGlobalizationCulture();

            var value = property.GetValue(entity, null);
            var type = propertyType ?? GetNullableType(property.PropertyType) ?? property.PropertyType;

            object objValue = DBNull.Value;

            if (value != null)
            {
                if (type == typeof(DateTime))
                {
                    objValue = (DateTime)value;
                }
                if (type == typeof(bool))
                {
                    objValue = ((bool?)value).GetValueOrDefault();
                }
                else if (type == typeof(float))
                {
                    objValue = double.Parse(value.ToString()).ToString("0.00", culture);
                }
                else if (type == typeof(double))
                {
                    objValue = float.Parse(value.ToString()).ToString("0.00", culture);
                }
                else if (type.IsEnum)
                {
                    objValue = (int)value;
                }
                //else if(property.DbReference() && type.BaseType == typeof(BaseEntity))
                //{
                //    objValue = ((BaseEntity) value).Id;
                //}
                else
                {
                    objValue = value.ToString();
                }
            }

            return objValue;
        }

        public static CultureInfo GetGlobalizationCulture()
        {
            var cultureKey = "es";
            CultureInfo cInfo = null;

            switch (cultureKey)
            {
                case "es":
                    cInfo = new CultureInfo("es-ES")
                    {
                        DateTimeFormat = {
                            ShortDatePattern = "dd/MM/yyyy",
                            LongTimePattern = "HH:mm:ss",
                            DateSeparator = "/"
                        },
                        NumberFormat = { NumberDecimalSeparator = "." }
                    };
                    break;

                case "en":
                    cInfo = new CultureInfo("en-US")
                    {
                        DateTimeFormat = {
                            ShortDatePattern = "MM/dd/yyyy",
                            LongTimePattern = "HH:mm:ss",
                            DateSeparator = "/"
                        },
                        NumberFormat = { NumberDecimalSeparator = "." }
                    };
                    break;
            }

            return cInfo;
        }
    }
}
