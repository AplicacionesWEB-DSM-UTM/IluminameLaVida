using System;
using System.Collections.Generic;

#nullable disable

namespace Iluminame_La_Vida.Models.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
            Reportes = new HashSet<Reporte>();
        }

        public int IdUsuario { get; set; }
        public int? IdFoto { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
