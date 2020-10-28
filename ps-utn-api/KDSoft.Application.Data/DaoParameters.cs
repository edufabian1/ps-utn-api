using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace KDSoft.Application.Data
{
    public class DaoParameters
    {
        private IList<SqlParameter> Parameters { get; set; }

        public DaoParameters()
        {
            Parameters = new List<SqlParameter>();
        }

        public SqlParameter[] ToArray()
        {
            return Parameters.ToArray();
        }

        #region Input

        public DaoParameters Add(String name, object value)
        {
            Parameters.Add(new SqlParameter
            {
                ParameterName = name,
                Value = value ?? DBNull.Value
            });
            return this;
        }

        public DaoParameters AddInt(String name, int? value)
        {
            Parameters.Add(new SqlParameter
            {
                ParameterName = name,
                SqlDbType = SqlDbType.Int,
                Value = (object)value ?? DBNull.Value
            });
            return this;
        }

        public DaoParameters AddString(String name, string value)
        {
            Parameters.Add(new SqlParameter
            {
                ParameterName = name,
                SqlDbType = SqlDbType.NChar,
                Size = value != null ? value.Length : 0,
                Value = string.IsNullOrEmpty(value) ? (object)DBNull.Value : value
            });
            return this;
        }

        public DaoParameters AddBoolean(string name, bool value)
        {
            Parameters.Add(new SqlParameter
            {
                ParameterName = name,
                SqlDbType = SqlDbType.Bit,
                Value = value ? 1 : 0
            });
            return this;
        }

        public DaoParameters AddLong(string name, long? value)
        {
            Parameters.Add(new SqlParameter
            {
                ParameterName = name,
                SqlDbType = SqlDbType.BigInt,
                Value = (object)value ?? DBNull.Value
            });
            return this;
        }

        public DaoParameters AddFloat(string name, float? value)
        {
            Parameters.Add(new SqlParameter
            {
                ParameterName = name,
                SqlDbType = SqlDbType.Float,
                Value = (object)value ?? DBNull.Value
            });
            return this;
        }

        public DaoParameters AddDecimal(string name, decimal value)
        {
            Parameters.Add(new SqlParameter
            {
                ParameterName = name,
                SqlDbType = SqlDbType.Decimal,
                Value = (object)value ?? DBNull.Value
            });
            return this;
        }
        #endregion
    }
}
