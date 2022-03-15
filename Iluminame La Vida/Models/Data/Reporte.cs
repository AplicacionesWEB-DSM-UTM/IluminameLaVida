using System;
using System.Collections.Generic;

#nullable disable

namespace Iluminame_La_Vida.Models.Data
{
    public partial class Reporte
    {
        public int IdReporte { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEtiqueta { get; set; }
        public int? IdFoto { get; set; }
        public int? IdGeoubicacion { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Etiqueta IdEtiquetaNavigation { get; set; }
        public virtual Foto IdFotoNavigation { get; set; }
        public virtual Geoubicacion IdGeoubicacionNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
