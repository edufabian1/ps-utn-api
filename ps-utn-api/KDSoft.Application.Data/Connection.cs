using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace KDSoft.Application.Data
{
    public static class Connection
    {
        private static SqlConnection CreateConnection(string cnnStr)
        {
            return new SqlConnection(cnnStr);
        }

        public static async Task<T> GetOne<T>(string cnnStr, string procedure, params SqlParameter[] parameters)
        {
            DataTable table;

            table = await ExecuteGetQuery(cnnStr, procedure, parameters);

            if (table != null && table.Rows.Count > 0)
                return EntityMapper.Map<T>(table.Rows[0]);

            return default;
        }

        public static async Task<DataTable> GetAll(string cnnStr, string procedure, params SqlParameter[] parameters)
        {
            var result = await ExecuteGetQuery(cnnStr, procedure, parameters);
            return result;
        }

        public static async Task<DataTable> ExecuteGetQuery(string cnnStr, string procedure, params SqlParameter[] parameters)
        {
            var table = new DataTable();
            var errorMessages = new StringBuilder();
            try
            {
                using (var cnn = CreateConnection(cnnStr))
                {
                    cnn.Open();

                    var cmd = new SqlCommand
                    {
                        CommandText = procedure,
                        CommandType = CommandType.StoredProcedure,
                        Connection = cnn,
                    };

                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    var reader = await cmd.ExecuteReaderAsync();

                    table.Load(reader);
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("#" + i + 
                        " Message: " + ex.Errors[i].Message + 
                        " LineNumber: " + ex.Errors[i].LineNumber + 
                        " Source: " + ex.Errors[i].Source + 
                        " Procedure: " + ex.Errors[i].Procedure);
                }
            }

            return table;
        }

        public static async Task<int> ExecuteNonQuerySync(string cnnStr, string procedure, params SqlParameter[] parameters)
        {
            var errorMessages = new StringBuilder();

            try
            {
                using (var cnn = CreateConnection(cnnStr))
                {
                    cnn.Open();

                    var cmd = new SqlCommand
                    {
                        CommandText = procedure,
                        CommandType = CommandType.StoredProcedure,
                        Connection = cnn
                    };

                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("#" + i +
                        " Message: " + ex.Errors[i].Message +
                        " LineNumber: " + ex.Errors[i].LineNumber +
                        " Source: " + ex.Errors[i].Source +
                        " Procedure: " + ex.Errors[i].Procedure);
                }
            }
            return -1;
        } 
    }
}