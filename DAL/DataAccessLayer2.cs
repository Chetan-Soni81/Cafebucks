using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessLayer2
    {
        #region Global Variables
        public SqlConnection conn = null;
        public string connectionString;
        #endregion
        #region methods
        private void OpenConnection()  
        {
            connectionString = ConfigurationSettings.AppSettings["ConnectionCafebucks"];
            conn = new SqlConnection(connectionString);

            if(conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        private SqlCommand CreateCommand(string procname, SqlParameter[] sqlParameters)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = procname;
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;

            if(sqlParameters != null)
            {
                command.Parameters.Clear();
                command.Parameters.AddRange(sqlParameters);
            }

            return command;
        }
        #endregion

        public SqlDataReader SelectRecordsByDataReader(string procname)
        {
            using (SqlCommand cmd = CreateCommand(procname, null))
            {
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return sdr;
            }
        }

        public SqlDataReader SelectRecordsByDataReader(string procname, SqlParameter[] sqlParameters)
        {
            using (SqlCommand cmd = CreateCommand(procname, sqlParameters))
            {
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return sdr;
            }
        }

        public DataTable SelectRecordsByDataTable(string procname, SqlParameter[] sqlParameter)
        {
            using (SqlCommand command = CreateCommand(procname, sqlParameter))
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

        public DataSet SelectRecordsByDataSet(string procname, SqlParameter[] sqlParameter)
        {
            using (SqlCommand cmd = CreateCommand(procname, sqlParameter))
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

        public int ExecuteNonQuery(string procname, SqlParameter[] sqlParameter)
        {
            int i = 0;

            using (SqlCommand cmd = CreateCommand(procname, sqlParameter))
            {
                try
                {
                    i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw;
                    return 0;
                }
            }

            return i;
        }

        public object ExecuteScalar(string procname, SqlParameter[] sqlParameters)
        {
            object o;
            using (SqlCommand cmd = CreateCommand(procname, sqlParameters))
            {
                try
                {
                    o = cmd.ExecuteScalar();
                }
                catch(Exception ex)
                {
                    return null;
                }
            }

            return o;
        }
    }
}
