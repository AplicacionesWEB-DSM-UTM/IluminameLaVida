﻿using Microsoft.AspNetCore.Http;
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
    public class RegistroController : ControllerBase
    {
        [HttpGet]
        //Consultar correos
        public IActionResult Get()
        {
            Respuesta<List<Usuario>> oRespuesta = new Respuesta<List<Usuario>>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    var list = db.Usuarios.ToList();
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
            Respuesta<Usuario> oRespuesta = new Respuesta<Usuario>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    var list = db.Usuarios.Find(id);
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
        //Agregar usuario
        public IActionResult Add(RegistroRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    Usuario oPro = new Usuario();
                    oPro.Correo = model.Correo;
                    oPro.Contraseña = model.Contraseña;
                    oPro.Nombre = model.Nombre;
                    oPro.Apellidos = model.Apellidos;
                    oPro.Foto = model.Foto;
                    db.Usuarios.Add(oPro);
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
        //Este metodo sirve para editar los correos

        public IActionResult Edit(RegistroRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    Usuario oPro = db.Usuarios.Find(model.IdUsuario);
                    oPro.Correo = model.Correo;
                    oPro.Contraseña = model.Contraseña;
                    oPro.Nombre = model.Nombre;
                    oPro.Apellidos = model.Apellidos;
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
        //Con este metodo vamos a eliminar cualquiera que querramos
        public IActionResult Del(int Id)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    Usuario oPro = db.Usuarios.Find(Id);
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
    "nombre": "Luis",
    "apellidos": "Pool",
    "correo": "luis@hotmail.com",
    "contraseña": "0987654321",
    "foto": "1234rtyj.jpg"
}
se puede usar el siguiente json para probar el metodo put
{
    "id_Usuario":9,
    "nombre": "Luis",
    "apellidos": "Pool",
    "correo": "luis@outlook.es",
    "contraseña": "0987654321",
    "foto": "ertyuio9.jpg"
}
*/
