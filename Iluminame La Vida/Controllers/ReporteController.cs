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
    public class ReporteController : ControllerBase
    {
        [HttpGet]
        //consultar reportes
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (IluminameLaVidaContext db = new IluminameLaVidaContext())
                {
                    var list = db.Reportes.ToList();
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
        //Crear reportes
        public IActionResult Add(ReporteRequest model)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (IluminameLaVidaContext db = new IluminameLaVidaContext())
                {
                    Reporte oPro = new Reporte();
                    oPro.Descrip = model.descrip;
                    oPro.Foto = model.foto;
                    oPro.Etiquetas = model.etiquetas;
                    oPro.Colonia = model.colonia;
                    oPro.IdUsuario = model.Id_Usuario;
                    oPro.Coordenadas = model.coordenadas;
                    db.Reportes.Add(oPro);
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
        
        /* se puede usar el siguiente json para probar el metodo post
        {
            "descrip": "ta feo",
            "foto": "photo2.png",
            "etiquetas": "huele mal",
            "colonia": "mercedes barrera",
            "Id_Usuario": 11,
            "coordenadas": "123456"
        }*/
    }
}
