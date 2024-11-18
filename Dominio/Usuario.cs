using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {

        public Usuario() {}

        public enum TipoUsuario
        {
            Normal = 1,
            Admin = 2
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string Imagen { get; set; }
        public bool EsAdmin { get; set; }

        public TipoUsuario TipoDeUsuario { get; set; }

        public Usuario(string usuario, string contrasenia, bool esAdmin)
        {
            Email = usuario;
            Contrasenia = contrasenia;
            TipoDeUsuario = esAdmin ? TipoUsuario.Admin : TipoUsuario.Normal;

        }

    }
}
