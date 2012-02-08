using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace AppHarborFoo
{
    public static class DbHelper
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

        public static void UpdateDatabase()
        {
            using(IDbConnection conn = GetConnection())
            {
                // if we don't have a table called Customers, create one...
                if (conn.Query<string>("select table_name from information_schema.tables where table_name='customers'", null).Count() == 0)
                {
                    // create...
                    conn.Execute(@"CREATE TABLE [dbo].[Customers](
	                    [CustomerId] [int] IDENTITY(1,1) NOT NULL,
	                    [FirstName] [nvarchar](64) NOT NULL,
	                    [LastName] [nvarchar](64) NOT NULL,
	                    [Email] [nvarchar](64) NOT NULL,
                     CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
                    (
	                    [CustomerId] ASC
                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                    ) ON [PRIMARY]", null);
                }
            }
        }
    }
}
