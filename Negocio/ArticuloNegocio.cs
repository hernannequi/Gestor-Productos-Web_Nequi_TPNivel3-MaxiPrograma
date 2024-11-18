using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Dominio;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.IO.Pipes;
using System.Collections;
using Datos;
using System.Diagnostics.Eventing.Reader;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar (string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Id,A.Codigo, A.Nombre , A.Descripcion, A.ImagenUrl, A.Precio, M.Descripcion Marca, A.IdMarca, C.Descripcion Categoria, A.IdCategoria FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];

                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    
                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    
                    
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            finally { datos.cerrarConexion(); }
        }

        public void AgregarArticulo (Articulo nuevoArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo,Nombre,Descripcion, ImagenUrl, Precio, IdMarca, IdCategoria) VALUES (@Codigo, @Nombre, @Descripcion, @ImagenUrl, @Precio, @IdMarca, @IdCategoria)");
                datos.setearParametros("@Codigo", nuevoArticulo.Codigo.ToString());
                datos.setearParametros("@Nombre", nuevoArticulo.Nombre.ToString());
                datos.setearParametros("@Descripcion", nuevoArticulo.Descripcion.ToString());
                datos.setearParametros("@IdMarca", nuevoArticulo.Marca.Id);
                datos.setearParametros("@IdCategoria", nuevoArticulo.Categoria.Id);
                datos.setearParametros("@ImagenUrl", nuevoArticulo.ImagenUrl.ToString());
                datos.setearParametros("@Precio", nuevoArticulo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void ModificarArticulo (Articulo articuloModificado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update Articulos set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, ImagenUrl = @imagenUrl, Precio = @precio, IdMarca = @idMarca, IdCategoria = @idCategoria WHERE Id = @id");

                datos.setearParametros("@codigo", articuloModificado.Codigo);
                datos.setearParametros("@nombre", articuloModificado.Nombre);
                datos.setearParametros("@descripcion", articuloModificado.Descripcion);
                datos.setearParametros("@imagenUrl", articuloModificado.ImagenUrl);
                datos.setearParametros("@precio", articuloModificado.Precio);
                datos.setearParametros("@idMarca", articuloModificado.Marca.Id);
                datos.setearParametros("@idCategoria", articuloModificado.Categoria.Id);
                datos.setearParametros("@id", articuloModificado.Id);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }

        public void EliminarFisico (int id)
        {
            
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("Delete from dbo.ARTICULOS where id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }   
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = @"SELECT A.Id,A.Nombre, A.ImagenUrl, A.Codigo, A.IdCategoria,A.IdMarca, A.Descripcion, A.Precio, M.Descripcion Marca, M.Id, C.Descripcion Categoria, C.Id 
                                    FROM ARTICULOS A
                                    inner join MARCAS M on M.Id = A.IdMarca
                                    inner join CATEGORIAS C on C.Id = A.IdCategoria
                                    WHERE ";

                if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Contiene:":
                            consulta += "A.Nombre like '%" + filtro + "%'";
                            break;
                        case "Comienza con:":
                            consulta += "A.Nombre like '" + filtro + "%'";

                            break;
                        case "Termina con:":
                            consulta += "A.Nombre like '%" + filtro + "'";
                            break;
                    }
                }
                else if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a:":
                            consulta += "A.Precio > " + filtro;
                            break;
                        case "Menor a:":
                            consulta += "A.Precio < " + filtro;
                            break;
                        case "Igual a:":
                            consulta += "A.Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Categoria")
                {
                    if(!string.IsNullOrEmpty(criterio))
                        consulta += $"C.Descripcion = '{criterio}' And A.Nombre like '%{filtro}%'";
                } 
                else if (campo == "Marca")
                {
                    if (!string.IsNullOrEmpty(criterio))
                        consulta += $"M.Descripcion = '{criterio}' And A.Nombre like '%{filtro}%'";
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];

                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];


                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
