using Locación.Shared.Data;
using Locación.Shared.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locación.Server.Controllers
{
    [ApiController]
    [Route("api/Provincias")]
    public class ProvController : ControllerBase
    {
        private readonly dataContext context;

        public ProvController(dataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<Provincia>> Get()
        {
            return context.Provincias.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Provincia> Get(int id)
        {
            var prov = context.Provincias.Where(x => x.ID == id).FirstOrDefault();
            if (prov == null)
            {
                return NotFound($"No existe el país con ID igual a {id}.");
            }
            return Ok(prov);
        }

        [HttpPost]
        public ActionResult<Provincia> Post(Provincia prov)
        {
            try
            {
                context.Provincias.Add(prov);
                context.SaveChanges();
                return prov;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Provincia prov)
        {
            if (id != prov.ID)
            {
                return BadRequest("Datos incorrectos.");
            }
            var provOther = context.Provincias.Where(x => x.ID == id).FirstOrDefault();

            if (provOther == null)
            {
                return NotFound("No existe esa provincia.");
            }

            provOther.ProvCódigo = prov.ProvCódigo;
            provOther.ProvNombre = prov.ProvNombre;
            provOther.PaísID     = prov.PaísID;

            try
            {
                context.Provincias.Update(provOther);
                context.SaveChanges();
                return Ok("Los datos han sido cambiados.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var prov = context.Provincias.Where(x => x.ID == id).FirstOrDefault();
            if (prov == null)
            {
                return NotFound($"No existe la provincia con ID igual a {id}.");
            }

            try
            {
                context.Provincias.Remove(prov);
                context.SaveChanges();
                return Ok($"La provincia {prov.ProvNombre} ha sido eliminada.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
