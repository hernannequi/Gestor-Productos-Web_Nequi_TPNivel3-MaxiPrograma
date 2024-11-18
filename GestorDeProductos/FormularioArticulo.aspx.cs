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
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool ConfirmarEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
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

                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                    Articulo seleccionado = (articuloNegocio.listar(id))[0];

                    txtId.ReadOnly = true;
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
            catch (Exception loadFormularioArticuloEx)
            {

                Session.Add("Error al cargar el Formulario: ", loadFormularioArticuloEx.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.ImagenUrl = txtImagenUrl.Text;

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.ModificarArticulo(nuevo);
                }
                else
                {
                    negocio.AgregarArticulo(nuevo);
                }

                Response.Redirect("CatalogoLista.aspx", false);
            }
            catch (Exception btnAceptarClickEx)
            {
                Session.Add("Error al realizar click en el boton aceptar:", btnAceptarClickEx.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if(chkBxConfirmarEliminacion.Checked)
                {
                    int id = int.Parse(txtId.Text);

                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.EliminarFisico(id);

                    Response.Redirect("CatalogoLista.aspx");
                }
            }
            catch (System.Threading.ThreadAbortException threadAbortEx) { }
            catch (Exception btnConfirmarEliminarEx)
            {
                Session.Add("Error.apsx", btnConfirmarEliminarEx.ToString());
                Response.Redirect("Error.apsx");
            }
        }
    }
}