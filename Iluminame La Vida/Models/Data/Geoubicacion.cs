using System;
using System.Collections.Generic;

#nullable disable

namespace Iluminame_La_Vida.Models.Data
{
    public partial class Geoubicacion
    {
        public Geoubicacion()
        {
            Reportes = new HashSet<Reporte>();
        }

        public int IdGeoubicacion { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
