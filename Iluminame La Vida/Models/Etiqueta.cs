using System;
using System.Collections.Generic;

#nullable disable

namespace Iluminame_La_Vida.Models
{
    public partial class Etiqueta
    {
        public Etiqueta()
        {
            Reportes = new HashSet<Reporte>();
        }

        public int IdEtiqueta { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Foto { get; set; }

        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
