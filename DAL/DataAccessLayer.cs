using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class DataAccessLayer
    {
        #region Global Variables
        public SqlConnection conn = null;
        public string connectionString;
        #endregion
        #region methods
        private void OpenConnection()
        {
            connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
            conn = new SqlConnection(connectionString);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        private SqlCommand CreateCommand(string procname, params object[] ob)
        {
            OpenConnection();
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = procname;
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            SqlParameter[] sqlpa = null;

            if (ob != null)
            {
                SqlCommandBuilder.DeriveParameters(command);
                command.Parameters.RemoveAt(0);
                sqlpa = new SqlParameter[command.Parameters.Count];
                command.Parameters.CopyTo(sqlpa, 0);

                for (int i = 0; i < sqlpa.Length; i++)
                {
                    sqlpa[i].Value = ob[i];
                }
            }

            return command;
        }
        #endregion

        public SqlDataReader SelectRecordsByDataReader(string procname, params object[] ob)
        {
            using (SqlCommand cmd = CreateCommand(procname, ob))
            {
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return sdr;
            }
        }

        public SqlDataReader SelectRecordsByDataReader(string procname)
        {
            using (SqlCommand cmd = CreateCommand(procname, null))
            {
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    return sdr;
                }
            }
        }

        public DataTable SelectRecordsByDataTable(string procname, params object[] ob)
        {
            using (SqlCommand command = CreateCommand(procname, ob))
            {
                using (SqlDataReader sdr = command.ExecuteReader())
                {
                    using (DataTable dt = new DataTable())
                    {
                        try
                        {
                            dt.Load(sdr);
                        }
                        catch (Exception)
                        {
                            return new DataTable();
                        }

                        return dt;
                    }
                }
            }
        }

        public DataTable SelectRecordsByDataTable(string procname)
        {
            using (SqlCommand command = CreateCommand(procname, null))
            {
                using (SqlDataReader sdr = command.ExecuteReader())
                {
                    using (DataTable dt = new DataTable())
                    {
                        try
                        {
                            dt.Load(sdr);
                        }
                        catch (Exception)
                        {
                            return new DataTable();
                        }

                        return dt;
                    }
                }
            }
        }

        public DataSet SelectRecordsByDataSet(string procname, params object[] ob)
        {
            using (SqlCommand cmd = CreateCommand(procname, ob))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    using (DataSet ds = new DataSet())
                    {
                        try
                        {
                            sda.SelectCommand = cmd;
                            sda.Fill(ds);
                        }
                        catch (Exception)
                        {
                            return new DataSet();
                        }

                        return ds;
                    }
                }
            }
        }

        public DataSet SelectRecordsByDataSet(string procname)
        {
            using (SqlCommand cmd = CreateCommand(procname, null))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    using (DataSet ds = new DataSet())
                    {
                        try
                        {
                            sda.SelectCommand = cmd;
                            sda.Fill(ds);
                        }
                        catch (Exception)
                        {
                            return new DataSet();
                        }

                        return ds;
                    }
                }
            }
        }

        public int ExecuteNonQuery(string procname, params object[] ob)
        {
            int i = 0;

            using (SqlCommand cmd = CreateCommand(procname, ob))
            {
                try
                {
                    i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    return 0;
                }
            }

            return i;
        }
    }
}
