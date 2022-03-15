using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iluminame_La_Vida.Models.Request
{
    public class EtiquetaRequest
    {
        public int IdEtiqueta { get; set; }
        public int? IdFoto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public FotoRequest FotoRequest { get; set; }
    }
}
