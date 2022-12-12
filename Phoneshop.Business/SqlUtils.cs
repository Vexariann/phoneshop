using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Data.SqlClient;

namespace Phoneshop.Business
{
    public class SqlUtils : ISqlUtils
    {
        public static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial " +
            "Catalog=Oldphoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
            "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public SqlUtils()
        {
        }

        private readonly List<Phone> _phones = new();

        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new();
            connection.ConnectionString = ConnectionString;
            connection.Open();
            return connection;
        }

        public List<Phone> GetPhones(string sql)
        {
            SqlConnection connection = OpenConnection();
            SqlCommand command = new(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            _phones.Clear();
            while (reader.Read())
            {
                _phones.Add(new Phone()
                {
                    ID = reader.GetInt32(reader.GetOrdinal("Id")),
                    //Brand = reader.GetString(reader.GetOrdinal("Brand")),
                    Type = reader.GetString(reader.GetOrdinal("Type")),
                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                    Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                });
            }
            connection.Dispose();
            return _phones;
        }

        public int GetBrandId(string sql)
        {
            SqlConnection connection = OpenConnection();
            SqlCommand command = new(sql, connection);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int ID = reader.GetInt32(reader.GetOrdinal("ID"));
                connection.Dispose();
                return ID;
            }
            else
            {
                connection.Dispose();
                return -1;
            }
        }

        public bool Exists(string sql)
        {
            SqlConnection connection = OpenConnection();
            SqlCommand command = new(sql, connection);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                connection.Dispose();
                return true;
            }
            else
            {
                connection.Dispose();
                return false;
            }
        }

        public void InsertOrDelete(string sql)
        {
            SqlConnection connection = OpenConnection();
            SqlCommand command = new(sql, connection);
            command.ExecuteNonQuery();
        }


    }
}
