using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestorDeProductos
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                MarcaNegocio marca = new MarcaNegocio();
                List<Marca> listaMarcas = marca.listadoMarcas();

                CategoriaNegocio categoria = new CategoriaNegocio();
                List<Categoria> listaCategorias = categoria.listadoCategorias();

                ddlMarca.DataSource = listaMarcas;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataBind();

                ddlCategoria.DataSource = listaCategorias;
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();
            }

            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

            if(id != "" && !IsPostBack)
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                Articulo seleccionado = (articuloNegocio.listar(id))[0];

                txtId.ReadOnly = true;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtDescripcion.ReadOnly = true;
                txtPrecio.ReadOnly = true;
                txtImagenUrl.ReadOnly = true;
                ddlMarca.Enabled = false;
                ddlCategoria.Enabled = false;


                txtId.Text = id;
                txtCodigo.Text = seleccionado.Codigo;
                txtNombre.Text = seleccionado.Nombre;
                txtDescripcion.Text = seleccionado.Descripcion;
                txtImagenUrl.Text = seleccionado.ImagenUrl;
                txtPrecio.Text = ((decimal)seleccionado.Precio).ToString("#,0.00", System.Globalization.CultureInfo.GetCultureInfo("es-ES"));
                
                ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                txtImagenUrl_TextChanged(sender, e);
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }
    }
}