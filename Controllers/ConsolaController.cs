using Examen.Models;
using Examen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Examen.Controllers
{
    public class ConsolaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetConsolas()
        {
            try
            {
                var result = ConsolaService.ObtenerConsolas().ToList();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Insertar(Consola consola)
        {
            try
            {
                var result = ConsolaService.InsertarConsola(consola);
                if (result)
                    return Ok("Exito");
                else
                    return BadRequest("Error al insertar");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Consola consola)
        {
            try
            {
                var result = ConsolaService.Actualizar(consola);
                if (result)
                    return Ok("Exito");
                else
                    return BadRequest("Error al acualizar");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Eliminar(Consola consola)
        {
            try
            {
                var result = ConsolaService.Eliminar(consola);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
