using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public abstract class DAO <T>
    {
        protected SqlConnection conn;
        protected SqlCommand cmd;

        protected void OpenConection(String conStr)
        {
            conn = new SqlConnection();
            conn.ConnectionString = conStr;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        protected void Create(String conStr, String cmdStr)
        {
            OpenConection(conStr);

            cmd.CommandText = cmdStr;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public abstract void Create(T t, String conStr);
        public abstract List<T> GetList(string conStr);
        public abstract void Delete(T t, string conStr);

    }
}
