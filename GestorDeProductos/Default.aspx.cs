using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace GestorDeProductos
{
    public partial class Home : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();

            if(!IsPostBack)
            {
                repetidorDefault.DataSource = listaArticulos;
                repetidorDefault.DataBind();
            }

        }

        protected void btnEX_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}