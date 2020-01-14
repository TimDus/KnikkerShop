using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LibraryKnikker.Core.DAL.Context.MSSQLContext
{
    public abstract class BaseMSSQLContext
    {
        private readonly string connectionString;
        public BaseMSSQLContext(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }


        public DataSet ExecuteSql(string sql, List<KeyValuePair<string, string>> parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();

                foreach (KeyValuePair<string, string> kvp in parameters)
                {
                    SqlParameter param = new SqlParameter
                    {
                        ParameterName = "@" + kvp.Key,
                        Value = kvp.Value
                    };
                    cmd.Parameters.Add(param);
                }

                cmd.CommandText = sql;
                da.SelectCommand = cmd;

                conn.Open();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long ExecuteInsert(string sql, List<KeyValuePair<string, string>> parameters)
        {
            long id = new long();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = conn.CreateCommand();

                foreach (KeyValuePair<string, string> kvp in parameters)
                {
                    SqlParameter param = new SqlParameter
                    {
                        ParameterName = "@" + kvp.Key,
                        Value = kvp.Value
                    };
                    cmd.Parameters.Add(param);
                }

                cmd.CommandText = sql;

                conn.Open();
                id = (long)cmd.ExecuteScalar();
                conn.Close();

                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataSet ExecuteStoredProcedure(string Procedurename)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(Procedurename)
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = conn,
                };
                da.SelectCommand = cmd;

                conn.Open();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
