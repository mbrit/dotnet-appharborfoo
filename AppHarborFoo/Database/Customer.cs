using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace AppHarborFoo
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        private const string SelectCustomerStub = "select customerid, firstname, lastname, email from customers"; 

        public static IEnumerable<Customer> GetAll()
        {
            using (IDbConnection conn = DbHelper.GetConnection())
                return conn.Query<Customer>(SelectCustomerStub, null);
        }

        public static int GetNumCustomers()
        {
            using (IDbConnection conn = DbHelper.GetConnection())
                return conn.Query<int>("select count(*) from customers", null).First();
        }

        public static Customer CreateCustomer(string firstName, string lastName, string email)
        {
            using (IDbConnection conn = DbHelper.GetConnection())
            {
                int id = conn.Query<int>(@"insert into customers (firstname, lastname, email) values (@firstName, @lastName, @email);
                    select convert(int, scope_identity());", new { firstName, lastName, email }).First();

                // load...
                return GetById(id);
            }
        }

        public static Customer GetById(int id)
        {
            using (IDbConnection conn = DbHelper.GetConnection())
            {
                // "select *" just for brevity in example code...
                return conn.Query<Customer>(SelectCustomerStub + " where customerid=@id", new { id }).First();
            }
        }
    }
}
