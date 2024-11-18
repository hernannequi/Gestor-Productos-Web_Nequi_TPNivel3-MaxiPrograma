using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listadoMarcas() 
        {
			List<Marca> lista = new List<Marca>();
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearConsulta("SELECT Descripcion, Id FROM MARCAS");
				datos.ejecutarLectura();

				while(datos.Lector.Read())
				{
					Marca aux = new Marca();

					aux.Id = (int)datos.Lector["Id"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];

					lista.Add(aux);
				}
				
				return lista;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}


    }
}
