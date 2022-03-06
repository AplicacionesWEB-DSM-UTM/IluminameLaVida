using System;
using System.Collections.Generic;

#nullable disable

namespace Iluminame_La_Vida.Models
{
    public partial class Reporte
    {
        public int IdReporte { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEtiqueta { get; set; }
        public string Foto { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual Etiqueta IdEtiquetaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
