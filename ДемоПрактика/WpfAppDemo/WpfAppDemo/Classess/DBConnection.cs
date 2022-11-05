using System.Data;
using System.Data.SqlClient;

namespace WpfAppDemo.Classess
{
    public class DBConnection
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-4BK5QIUE\SQLEXPRESS;Initial Catalog=DBDEMO;Integrated Security=True");

        public void oppenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
                sqlConnection.Close();
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }

    }
}

