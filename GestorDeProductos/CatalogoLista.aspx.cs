using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestorDeProductos
{
    public partial class CatalogoLista : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = chkBxFiltroAvanzado.Checked;

            if (!IsPostBack || !chkBxFiltroAvanzado.Checked)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaDeArticulos", negocio.listar());
                dgvArticulos.DataSource = Session["listaDeArticulos"];
                dgvArticulos.DataBind();
            }
        }


        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();

            Response.Redirect($"FormularioArticulo.aspx?id={id}");
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioArticulo.aspx");
        }

        protected void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaArticulos = (List<Articulo>)Session["listaDeArticulos"];
            List<Articulo> listaFiltrada = listaArticulos.FindAll(articulo => articulo.Nombre.ToLower().Contains(txtFiltrar.Text.ToLower()));

            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void chkBxFiltro_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkBxFiltroAvanzado.Checked;
            txtFiltrar.Enabled = !FiltroAvanzado;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
            dgvArticulos.DataBind();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();

            string ddlCampoSeleccionado = ddlCampo.SelectedItem.ToString();

            switch (ddlCampoSeleccionado)
            {
                case "Nombre":
                    ddlCriterio.Items.Add("Contiene:");
                    ddlCriterio.Items.Add("Comienza con:");
                    ddlCriterio.Items.Add("Termina con:");
                    break;
                case "Precio":
                    ddlCriterio.Items.Add("Mayor a:");
                    ddlCriterio.Items.Add("Menor a:");
                    ddlCriterio.Items.Add("Igual a");
                    break;
                case "Marca":
                    ddlCriterio.Items.Add("Motorola");
                    ddlCriterio.Items.Add("Samsung");
                    ddlCriterio.Items.Add("Apple");
                    ddlCriterio.Items.Add("Sony");
                    ddlCriterio.Items.Add("Huawei");
                    break;
                case "Categoria":
                    ddlCriterio.Items.Add("Celulares");
                    ddlCriterio.Items.Add("Televisores");
                    ddlCriterio.Items.Add("Media");
                    ddlCriterio.Items.Add("Audio");
                    break;
            }
        }
    }
}