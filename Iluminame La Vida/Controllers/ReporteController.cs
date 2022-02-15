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
                    var list = db.Reportes.Join(db.Registros, Reporte => Reporte.IdUsuario, Registro => Registro.IdUsuario, (Reporte, Registro) => new{
                        Descripcion = Reporte.Descrip,
                        Foto = Reporte.Foto,
                        Etiqueta = Reporte.Etiquetas,
                        Colonia = Reporte.Colonia,
                        Usuario = Registro.Mail,
                        Coordenadas = Reporte.Coordenadas}).ToList();
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

        [HttpPut]

        //Este metodo sirve para editar los datos

        public IActionResult Edit(ReporteRequest model)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (IluminameLaVidaContext db = new IluminameLaVidaContext())
                {
                    Reporte oPro = db.Reportes.Find(model.Id_Reporte);
                    oPro.Descrip = model.descrip;
                    oPro.Foto = model.foto;
                    oPro.Etiquetas = model.etiquetas;
                    oPro.Colonia = model.colonia;
                    oPro.IdUsuario = model.Id_Usuario;
                    oPro.Coordenadas = model.coordenadas;
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
        //Con este metodo vamos a eliminar cualquiera que querramos
        public IActionResult Del(int Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (IluminameLaVidaContext db = new IluminameLaVidaContext())
                {
                    Reporte oPro = db.Reportes.Find(Id);
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
