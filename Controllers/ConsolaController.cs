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
                return Ok("Exito");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: Consola/Create
        public IHttpActionResult Create()
        {
            return Ok();
        }



    }
}
