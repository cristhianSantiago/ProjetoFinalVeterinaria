using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veterinario.BO;

namespace Interface
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarGrid();
            }
        }

        private void CarregarGrid()
        {
            try
            {
                grdCliente.DataSource = new ClienteBO().Listar();
                grdCliente.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void lkbEditar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int id = int.Parse(e.CommandArgument.ToString());

                Response.Redirect("ClientesAlt.aspx?g_md=UP&id=" + id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}