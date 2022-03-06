using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iluminame_La_Vida.Models.Request
{
    public class ReporteRequest
    {
        public int Id_Reporte { get; set; }
        public int? Id_Usuario { get; set; }
        public int? Id_Etiqueta { get; set; }
        public string Usuario { get; set; }
        public string Etiqueta { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public string Foto { get; set; }
    }
}

