using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RegionDAO : DAO<Region>
    {
        public override void Create(Region r,string conStr)
        {
               Create(conStr,
               "Insert into Region (RegionID, RegionDescription)VALUES (" 
               + r.RegionID + ",'"
               + r.RegionDescription + "')");
        }

        public override void Delete(Region t, string conStr)
        {
            throw new NotImplementedException();
        }

        public override List<Region> GetList(string conStr)
        {
            List<Region> regs = null;

            OpenConection(conStr);

            cmd.CommandText = "Select * from Region ";
            SqlDataReader dr= cmd.ExecuteReader();
            if (dr.HasRows)
                regs = new List<Region>();
            while(dr.Read())
            {
                regs.Add(new Region()
                {
                    RegionID = dr.GetInt32(0),
                    RegionDescription = dr.GetString(1)
                });
            }

            conn.Close();

            return regs;
        }
    }
}
