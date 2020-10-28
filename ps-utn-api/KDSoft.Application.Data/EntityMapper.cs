using KDSoft.Application.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Data;

namespace KDSoft.Application.Data
{
    public class EntityMapper
    {
        public static IList<TEntity> MapList<TEntity>(DataTable table)
        {
            var result = new List<TEntity>();

            foreach (DataRow row in table.Rows)
                result.Add(Map<TEntity>(row));

            return result;
        }

        public static TEntity Map<TEntity>(DataRow row)
        {
            var entity = Activator.CreateInstance<TEntity>();
            var entityType = typeof(TEntity);
            var properties = entityType.GetProperties();

            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.DbIgnore()) continue;

                var type = Util.GetNullableType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                var column = propertyInfo.FieldFormat();

                if (row.Table.Columns.Contains(column))
                {
                    var value = row[column];
                    if (value != DBNull.Value)
                    {
                        if (type.IsEnum)
                        {
                            var valueEnum = Enum.ToObject(type, int.Parse(value.ToString()));
                            propertyInfo.SetValue(entity, valueEnum, null);
                        }
                        else if (propertyInfo.PropertyType == typeof(DateTime) || propertyInfo.PropertyType == typeof(DateTime))
                        {
                            propertyInfo.SetValue(entity, Convert.ChangeType(value, type, Util.GetGlobalizationCulture()), null);
                        }
                        else if (type == typeof(bool))
                        {
                            propertyInfo.SetValue(entity, value.BooleanToAppFormat());
                        }
                        else
                            propertyInfo.SetValue(entity, Convert.ChangeType(value, type), null);
                    }
                }
            }
            return entity;
        }
    }
}