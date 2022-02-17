using System;
using System.Collections.Generic;

#nullable disable

namespace Iluminame_La_Vida.Models
{
    public partial class Reporte
    {
        public int IdReporte { get; set; }
        public int IdUsuario { get; set; }
        public int IdEtiqueta { get; set; }
        public DateTime FechaDen { get; set; }
        public string DescripLugar { get; set; }
        public string Coords { get; set; }
        public string FotoReporte { get; set; }

        public virtual Etiquetum IdEtiquetaNavigation { get; set; }
        public virtual Registro IdUsuarioNavigation { get; set; }
    }
}
