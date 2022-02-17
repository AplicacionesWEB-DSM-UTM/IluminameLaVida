using System;
using System.Collections.Generic;

#nullable disable

namespace Iluminame_La_Vida.Models
{
    public partial class Etiquetum
    {
        public Etiquetum()
        {
            Reportes = new HashSet<Reporte>();
        }

        public int IdEtiqueta { get; set; }
        public string Nombre { get; set; }
        public byte[] DescEti { get; set; }
        public string FotoEti { get; set; }

        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
