using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class Baglanti
    {
        public static SqlConnection bgl = new SqlConnection("Data Source=ONURPC\\MSSQLSERVER01;Initial Catalog=dbPersonel;Integrated Security=True;");
        // static olması nesne türetmeden buraya ulaşabilmemizi sağlar.

    }
}
