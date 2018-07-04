using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public class TerritoriesDAO : DAO<Territories>
    {
        public override void Create(Territories t, string conStr)
        {
                Comand(conStr,
                "Insert into Territories (TerritoryID, TerritoryDescription, RegionID)VALUES ('"
                + t.TerritoryID + "','"
                + t.TerritoryDescription + "',"
                + t.RegionID + ")");
        }

        public override List<Territories> GetList(string conStr)
        {
            List<Territories> regs = null;

            OpenConection(conStr);

            cmd.CommandText = "Select * from Territories";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                regs = new List<Territories>();
            while (dr.Read())
            {
                regs.Add(new Territories()
                {
                    TerritoryID = dr.GetString(0),
                    TerritoryDescription = dr.GetString(1),
                    RegionID = dr.GetInt32(2)
                });
            }

            conn.Close();

            return regs;
        }

        public override void Delete(Territories t, string conStr)
        {
            Comand(conStr,
                "DELETE FROM Territories " +
                "WHERE  TerritoryID = '" + t.TerritoryID + "'");
        }

        public override void Update(Territories t, string conStr)
        {
            Comand(conStr,
                "UPDATE Territories " +
                "SET TerritoryID = '"+ t.TerritoryID + "', " +
                   "TerritoryDescription = '" + t.TerritoryDescription + "', " +
                   "RegionID = "+ t.RegionID +
                " WHERE TerritoryID = '" + t.TerritoryID + "'");
        }
    }
}
