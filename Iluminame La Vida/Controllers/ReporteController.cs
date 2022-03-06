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
            Respuesta<List<ReporteRequest>> oRespuesta = new Respuesta<List<ReporteRequest>>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    var list = db.Reportes.Join(db.Usuarios, Reporte => Reporte.IdUsuario, Registro => Registro.IdUsuario, (Reporte, Registro) => new ReporteRequest
                    {
                        Id_Reporte = Reporte.IdReporte,
                        Id_Etiqueta = Reporte.IdEtiqueta,
                        Id_Usuario = Reporte.IdUsuario,
                        Usuario = Registro.Correo,
                        Foto = Reporte.Foto,
                        Descripcion = Reporte.Descripcion,
                        Latitud = Reporte.Latitud,
                        Longitud = Reporte.Longitud,
                        Fecha = Reporte.Fecha
                    }).Join(db.Etiqueta, Etiqueta => Etiqueta.Id_Etiqueta, Reporte => Reporte.IdEtiqueta, (Reporte, Etiqueta) => new ReporteRequest
                    {
                        Id_Reporte = Reporte.Id_Reporte,
                        Id_Etiqueta = Reporte.Id_Etiqueta,
                        Id_Usuario = Reporte.Id_Usuario,
                        Etiqueta = Etiqueta.Nombre,
                        Usuario = Reporte.Usuario,
                        Foto = Reporte.Foto,
                        Descripcion = Reporte.Descripcion,
                        Latitud = Reporte.Latitud,
                        Longitud = Reporte.Longitud,
                        Fecha = Reporte.Fecha
                    }).ToList();
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Respuesta<ReporteRequest> oRespuesta = new Respuesta<ReporteRequest>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    var list = db.Reportes.Join(db.Usuarios, Reporte => Reporte.IdUsuario, Registro => Registro.IdUsuario, (Reporte, Registro) => new ReporteRequest
                    {
                        Id_Reporte = Reporte.IdReporte,
                        Id_Etiqueta = Reporte.IdEtiqueta,
                        Id_Usuario = Reporte.IdUsuario,
                        Usuario = Registro.Correo,
                        Foto = Reporte.Foto,
                        Descripcion = Reporte.Descripcion,
                        Latitud = Reporte.Latitud,
                        Longitud = Reporte.Longitud,
                        Fecha = Reporte.Fecha
                    }).Join(db.Etiqueta, Etiqueta => Etiqueta.Id_Etiqueta, Reporte => Reporte.IdEtiqueta,(Reporte, Etiqueta) => new ReporteRequest
                    {
                        Id_Reporte = Reporte.Id_Reporte,
                        Id_Etiqueta = Reporte.Id_Etiqueta,
                        Id_Usuario = Reporte.Id_Usuario,
                        Etiqueta = Etiqueta.Nombre,
                        Usuario = Reporte.Usuario,
                        Foto = Reporte.Foto,
                        Descripcion = Reporte.Descripcion,
                        Latitud = Reporte.Latitud,
                        Longitud = Reporte.Longitud,
                        Fecha = Reporte.Fecha
                    }).FirstOrDefault(x => x.Id_Reporte == id);
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
        //con esto vamos a agregar reportes
        public IActionResult Add(ReporteRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    Reporte oPro = new Reporte();
                    oPro.IdUsuario = model.Id_Usuario;
                    oPro.IdEtiqueta = model.Id_Etiqueta;
                    oPro.Fecha = DateTime.Now;
                    oPro.Descripcion = model.Descripcion;
                    oPro.Latitud = model.Latitud;
                    oPro.Longitud = model.Longitud;
                    oPro.Foto = model.Foto;
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
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    Reporte oPro = db.Reportes.Find(model.Id_Reporte);
                    oPro.Descripcion = model.Descripcion;
                    oPro.Foto = model.Foto;
                    oPro.IdEtiqueta = model.Id_Etiqueta;
                    oPro.IdUsuario = model.Id_Usuario;
                    oPro.Latitud = model.Latitud;
                    oPro.Longitud = model.Longitud;
                    oPro.Fecha = model.Fecha;
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
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
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
    }
}
/* se puede usar el siguiente json para probar el metodo post
{
    "id_Usuario": 1,
    "id_Etiqueta": 1,
    "fecha": "2021-02-17T00:00:00",
    "descripcion": "Asquerosamente oscuro",
    "coordenadas": "0987654321",
    "foto": "98ikjhb.jpg"
}
se puede usar el siguiente json para probar el metodo put
{
    "id_Reporte": 16,
    "id_Usuario": 2,
    "id_Etiqueta": 2,
    "fecha": "2021-02-17T00:00:00",
    "descripcion": "Asquerosamente oscuro",
    "coordenadas": "0987654321",
    "foto": "98ikjhb.jpg"
}
 */


