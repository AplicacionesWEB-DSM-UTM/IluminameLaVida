using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iluminame_La_Vida.Models.Request
{
    public class ReporteRequest
    {
        public int Id_Reporte { get; set; }
        public string descrip { get; set; }
        public string foto { get; set; }
        public string etiquetas { get; set; }
        public string colonia { get; set; }
        public int Id_Usuario { get; set; }
        public string coordenadas { get; set; }
    }
}

