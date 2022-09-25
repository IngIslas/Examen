using Examen.Models;
using Examen.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;

namespace Examen.Controllers
{
    public class VideojuegoController : ApiController
    {

        [HttpGet]
        public IHttpActionResult GetVideojuegos()
        {
            try
            {
                var lista = VideojuegoService.Obtener().ToList();
                lista.ForEach(videojuego =>
                {
                    videojuego.Consolas = ConsolaService.ObtenerConsolas(videojuego.IdVideojuego).ToList();
                });
                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Insertar(Videojuego videojuego)
        {
            try
            {

                var result = VideojuegoService.Insertar(videojuego).ToList();
                return Ok("Exito");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult AsignarConsolas(Videojuego videojuego)
        {
            try
            {
                VideojuegoService.DesasignarConsolas(videojuego.IdVideojuego);
                videojuego.Consolas.ForEach(consola =>
                {
                    VideojuegoService.AsignarConsola(videojuego.IdVideojuego, consola);
                });
                return Ok("Exito");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Videojuego videojuego) {
            try
            {
                VideojuegoService.Actualizar(videojuego).ToList();
                AsignarConsolas(videojuego);
                return Ok("Exito");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Eliminar(Videojuego videojuego) {
            try
            {
                VideojuegoService.Eliminar(videojuego).ToList();
                return Ok("Exito");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
