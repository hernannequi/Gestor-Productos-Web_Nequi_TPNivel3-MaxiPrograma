using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestorDeProductos
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> listaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
        //    string id = Request.QueryString["id"];

        //    if (string.IsNullOrEmpty(id))
        //    {
        //        Articulo nuevoFav = new Articulo();
        //        ArticuloNegocio negocioArtFav = new ArticuloNegocio();

                
        //    }
        }

        protected void btnEliminarFav_Click(object sender, EventArgs e)
        {

        }
    }
}