using System;
using System.Collections.Generic;

#nullable disable

namespace Iluminame_La_Vida.Models
{
    public partial class Reporte
    {
        public int IdReporte { get; set; }
        public string Descrip { get; set; }
        public string Foto { get; set; }
        public string Etiquetas { get; set; }
        public string Colonia { get; set; }
        public int IdUsuario { get; set; }
        public string Coordenadas { get; set; }

        public virtual Registro IdUsuarioNavigation { get; set; }
    }
}
