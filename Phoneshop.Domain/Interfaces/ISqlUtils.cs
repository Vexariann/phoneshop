using Phoneshop.Domain.Models;
using System.Data.SqlClient;

namespace Phoneshop.Domain.Interfaces
{
    public interface ISqlUtils
    {
        bool Exists(string sql);
        int GetBrandId(string sql);
        List<Phone> GetPhones(string sql);
        void InsertOrDelete(string sql);
        SqlConnection OpenConnection();
    }
}
