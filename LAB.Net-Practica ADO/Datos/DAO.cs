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

        protected void Comand(String conStr, String cmdStr)
        {
            try{
                OpenConection(conStr);

                cmd.CommandText = cmdStr;
                cmd.ExecuteNonQuery();

                conn.Close();
            }

            catch(Exception e)
            {
            }
        }

        public abstract void Create(T t, String conStr);
        public abstract List<T> GetList(string conStr);
        public abstract void Delete(T t, string conStr);
        public abstract void Update(T t, string conStr);
    }
}
