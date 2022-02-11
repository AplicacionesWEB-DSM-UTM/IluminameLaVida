using System;
using System.Collections.Generic;

#nullable disable

namespace Iluminame_La_Vida.Models
{
    public partial class Registro
    {
        public Registro()
        {
            Reportes = new HashSet<Reporte>();
        }

        public int IdUsuario { get; set; }
        public string Mail { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Colonia { get; set; }

        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
