using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iluminame_La_Vida.Models.Request
{
    public class ReporteRequest
    {
        public int IdReporte { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEtiqueta { get; set; }
        public int? IdFoto { get; set; }
        public int? IdGeoubicacion { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public UsuarioRequest UsuarioRequest { get; set; }
        public EtiquetaRequest EtiquetaRequest { get; set; }
        public FotoRequest FotoRequest { get; set; }
        public GeoubicacionRequest GeoubicacionRequest { get; set; }
    }
}
