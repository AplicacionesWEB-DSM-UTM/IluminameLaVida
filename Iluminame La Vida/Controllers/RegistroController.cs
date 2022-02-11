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
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (IluminameLaVidaContext db = new IluminameLaVidaContext())
                {
                    var list = db.Registros.ToList();
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
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (IluminameLaVidaContext db = new IluminameLaVidaContext())
                {
                    Registro oPro = new Registro();
                    oPro.Mail = model.mail;
                    oPro.Pass = model.pass;
                    oPro.Nombre = model.nombre;
                    oPro.Apellidos = model.apellidos;
                    oPro.Colonia = model.colonia;
                    db.Registros.Add(oPro);
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
            "mail": "rafa@hotmail.com",
            "pass": "12345",
            "nombre": "rafa",
            "apellidos": "cauich",
            "colonia": "mecedes barrera"
        }*/
    }
}