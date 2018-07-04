using System;
using Negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Presentacion
{
    public partial class ABMTerritories : System.Web.UI.Page
    {
        static string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["NorthwindEntities3"].ConnectionString;
        SolverTerritories solver = new SolverTerritories(connstr);

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            solver.CargarTerritories();

            listRegion.DataSource = solver.GetRegiones;
            listRegion.DataBind();

            Grid1.DataSource = solver.GetTeritories;
            Grid1.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void Grid1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            this.txtDescription.Text = this.Grid1.SelectedRow.Cells[2].Text.Trim();

            this.txtTerritoryId.Text = this.Grid1.SelectedRow.Cells[1].Text.Trim();
        }
    }
}