using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iluminame_La_Vida.Models.Request
{
    public class UsuarioRequest
    {
        public int IdUsuario { get; set; }
        public int? IdFoto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public FotoRequest FotoRequest { get; set; }
    }
}
