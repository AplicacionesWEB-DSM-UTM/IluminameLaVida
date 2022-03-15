using System;
using System.Collections.Generic;

#nullable disable

namespace Iluminame_La_Vida.Models.Data
{
    public partial class Foto
    {
        public Foto()
        {
            Reportes = new HashSet<Reporte>();
        }

        public int IdFoto { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
