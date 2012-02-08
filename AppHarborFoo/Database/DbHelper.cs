using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AppHarborFoo
{
    internal static class DbHelper
    {
        private static string _connectionString;

        // location in the configuration where AppHarbor will put our string...
        private const string ConnectionStringKey = "SQLSERVER_CONNECTION_STRING";

        internal static IDbConnection GetConnection()
        {
            // get...
            SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Format("Failed to connection to '{0}'.", ConnectionString), ex);
            }

            // return...
            return conn;
        }

        private static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.AppSettings[ConnectionStringKey];
                    if (string.IsNullOrEmpty(_connectionString))
                        throw new InvalidOperationException(string.Format("A connection string was not provided at '{0}'.", ConnectionStringKey));
                }

                // return...
                return _connectionString;
            }
        }
    }
}
