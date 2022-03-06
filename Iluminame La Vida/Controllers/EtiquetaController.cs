using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Iluminame_La_Vida.Models.Response;
using Iluminame_La_Vida.Models;
using Iluminame_La_Vida.Models.Request;

namespace Iluminame_La_Vida.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtiquetaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Etiqueta>> oRespuesta = new Respuesta<List<Etiqueta>>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    var list = db.Etiqueta.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = list;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(EtiquetaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    Etiqueta oPro = new Etiqueta();
                    oPro.Nombre = model.Nombre;
                    oPro.Descripcion = model.Descripcion;
                    oPro.Foto = model.Foto;
                    db.Etiqueta.Add(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpPut]
        public IActionResult Edit(EtiquetaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    Etiqueta oPro = db.Etiqueta.Find(model.Id_Etiqueta);
                    oPro.Nombre = model.Nombre;
                    oPro.Descripcion = model.Descripcion;
                    oPro.Foto = model.Foto;
                    db.Entry(oPro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Del(int Id)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    Etiqueta oPro = db.Etiqueta.Find(Id);
                    db.Remove(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
/* se puede usar el siguiente json para probar el metodo post
{
    "nombre": "Rota",
    "descripcion": "La bombilla esta rota",
    "foto": "Rota.jpg"
}
se puede usar el siguiente json para probar el metodo put
{
    "id_Etiqueta": 4,
    "nombre": "Bombilla rota",
    "descripcion": "La bombilla esta rota",
    "foto": "Bombilla_rota.jpg"
}
*/