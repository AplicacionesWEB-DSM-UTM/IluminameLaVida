using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iluminame_La_Vida.Models.Request
{
    public class EtiquetumRequest
    {
       public int Id_Etiqueta { get; set; }
       public string Nombre { get; set; }
       public string Desc_Eti { get; set; }
       public string Foto_Eti { get; set; }
    }
}
