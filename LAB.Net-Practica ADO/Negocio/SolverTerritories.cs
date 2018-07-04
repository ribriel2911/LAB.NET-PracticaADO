﻿using System;
using System.Collections.Generic;
using System.Data;
using Datos;

namespace Negocio
{
    public class SolverTerritories
    {
        private DataTable territories;
        private TerritoriesDAO dao;
        private string connstr;
        SolverRegion solRegions;

        public SolverTerritories(string connstr)
        {
            this.connstr = connstr;
            dao = new TerritoriesDAO();
            solRegions = new SolverRegion(connstr);

            CargarTerritories();
        }


        public void CargarTerritories()
        {
            territories = new DataTable("Territories");
            territories.Columns.Add(new DataColumn("TerritoryID", typeof(string)));
            territories.Columns.Add(new DataColumn("TerritoryDescription", typeof(string)));
            territories.Columns.Add(new DataColumn("RegionID", typeof(int)));
            territories.Columns.Add(new DataColumn("RegionDescription", typeof(string)));

            foreach (Territories t in dao.GetList(connstr))
            {
                DataRow row = territories.NewRow();
                row["TerritoryID"] = t.TerritoryID;
                row["TerritoryDescription"] = t.TerritoryDescription;
                row["RegionID"] = t.RegionID;
                row["RegionDescription"] = BuscarRegion(t.RegionID).RegionDescription;

                territories.Rows.Add(row);
            }
        }

        public void CrearTerritory(String id, String description, String region){

            Region r = BuscarRegion(region);

            Territories t = new Territories
            {
                TerritoryID = id,
                TerritoryDescription = description,
                RegionID = r.RegionID,

                Region = r
            };

            r.Territories.Add(t);

            dao.Create(t,connstr);
            CargarTerritories();
        }

        private Region BuscarRegion(string region)
        {

            Region ret = solRegions.BuscarDescripcion(region);

            return ret;
        }

        private Region BuscarRegion(int region)
        {
            Region ret = solRegions.BuscarId(region);

            return ret;
        }

        public DataTable GetTeritories => territories;
        public List<string> GetRegiones => solRegions.Descripciones();
    }
}
