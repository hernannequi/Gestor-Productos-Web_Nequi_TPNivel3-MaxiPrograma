using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using static Dominio.Usuario;
using System.Diagnostics.Eventing.Reader;

namespace Negocio
{
    public class UsuarioNegocio
    {
        //public int AgregarUsuario(Usuario usuario)
        //{
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        string consulta = "INSERT INTO USERS(email,pass,nombre,apellido,urlImagenPerfil) VALUES (@email,@pass,@nombre,@apellido,@urlimagen)";
        //        datos.setearConsulta(consulta);
        //        datos.setearParametros("@email", usuario.Email);
        //        datos.setearParametros("@pass", usuario.Contrasenia);
        //        datos.setearParametros("@nombre", usuario.Nombre);
        //        datos.setearParametros("@apellido", usuario.Apellido);
        //        datos.setearParametros("@urlimagen", usuario.Imagen);

        //        return datos.ejecutarAccion();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            string consulta = "Select Id, admin, pass, email From USERS Where email = @email And pass = @contrasenia";
            
            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametros("@email", usuario.Email);
                datos.setearParametros("@contrasenia", usuario.Contrasenia);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];

                    usuario.EsAdmin = (bool)(datos.Lector["admin"]);

                    if (usuario.EsAdmin)
                        usuario.TipoDeUsuario = TipoUsuario.Admin;
                    else if (usuario.EsAdmin == false)
                        usuario.TipoDeUsuario = TipoUsuario.Normal;
                    
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally { datos.cerrarConexion(); }
        }
    }
}
