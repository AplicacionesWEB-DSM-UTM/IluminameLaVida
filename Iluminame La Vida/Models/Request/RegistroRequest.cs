using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iluminame_La_Vida.Models.Request
{
    public class RegistroRequest
    {
        public int Id_Usuario { get; set; }
        public string mail { get; set; }
        public string pass { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string colonia { get; set; }
       

    }
}
