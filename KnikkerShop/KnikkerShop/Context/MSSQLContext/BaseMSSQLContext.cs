﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace KnikkerShop.Context.MSSQLContext
{
    public abstract class BaseMSSQLContext
    {
        private readonly string connectionString;
        public BaseMSSQLContext(IConfiguration config)
        {
            connectionString = config.GetConnectionString("Development");
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
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@" + kvp.Key;
                    param.Value = kvp.Value;
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

        public DataSet ExecuteStoredProcedure(string Procedurename, long id = 0)
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
                if (id != 0)
                {
                    cmd.Parameters.Add("@GebruikerId", SqlDbType.VarChar).Value = id;
                }
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
