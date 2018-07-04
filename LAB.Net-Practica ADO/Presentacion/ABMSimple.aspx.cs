using Datos;
using System;

namespace Presentacion
{
    public partial class ABMSimple : System.Web.UI.Page
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["NorthwindEntities3"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CargarGrilla();

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
           
            Region reg = new Region
            {
                RegionID = Convert.ToInt32(this.txtRegionId.Text.Trim()),
                RegionDescription = this.txtDescription.Text.Trim()
            };

            
            RegionDAO regionDAO = new RegionDAO();
            regionDAO.Create(reg, connstr);

            this.CleanUp();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            

            this.CleanUp();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            

            this.CleanUp();
        }

        private void CargarGrilla()
        {
            RegionDAO regDao = new RegionDAO();
            
            this.Grid1.DataSource = regDao.GetList(connstr);

            this.Grid1.DataBind();
            
        }

        private void CleanUp()
        {
            this.CargarGrilla();

            this.LimpiarTexto();
        }

        protected void Grid1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            this.txtDescription.Text = this.Grid1.SelectedRow.Cells[2].Text.Trim();

            this.txtRegionId.Text = this.Grid1.SelectedRow.Cells[1].Text.Trim();
        }

        private void LimpiarTexto()
        {
            this.txtDescription.Text = String.Empty;

            this.txtRegionId.Text = String.Empty;
        }
    }
}