using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanVien.Utils
{
    public class Provider
    {
        string ConnectionString = @"Data Source=DESKTOP-9DCUPJF\SQLEXPRESS;Initial Catalog=qlnv;Integrated Security=True";

        SqlConnection? Connection { get; set; }
        public void Connect()
        {
            try
            {
                if (Connection == null)
                    Connection = new SqlConnection(ConnectionString);
                if (Connection.State != ConnectionState.Closed)
                    Connection.Close();
                Connection.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void Disconnect()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
                Connection.Close();
        }
        public int ExcuteNonQuery(CommandType cmdType, string strSql, params SqlParameter[] parameters)
        {
            try
            {
                Connect();
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = strSql;
                command.CommandType = cmdType;
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);
                int nRow = command.ExecuteNonQuery();
                return nRow;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }

        }

        public DataTable? Select(CommandType cmdType, string strSql)
        {
            try
            {
                Connect();
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = strSql;
                command.CommandType = cmdType;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}