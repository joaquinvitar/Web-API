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
    [Route("api/Países")]
    public class PaísesController : ControllerBase
    {
        private readonly dataContext context;

        public PaísesController(dataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<País>> Get()
        {
            return context.Países.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<País> Get(int id)
        {
            var país = context.Países.Where(x => x.ID == id).FirstOrDefault();
            if(país == null)
            {
                return NotFound($"No existe el país con ID igual a {id}.");
            }
            return país;
        }

        [HttpPost]
        public ActionResult<País> Post(País país)
        {
            try
            {
                context.Países.Add(país);
                context.SaveChanges();
                return país;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] País país)
        {
            if(id != país.ID)
            {
                return BadRequest("Datos incorrectos.");
            }
            var paísOther = context.Países.Where(x => x.ID == id).FirstOrDefault();

            if(paísOther == null)
            {
                return NotFound("No existe ese país.");
            }

            paísOther.PaísCódigo = país.PaísCódigo;
            paísOther.PaísNombre = país.PaísNombre;

            try
            {
                context.Países.Add(paísOther);
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
            var país = context.Países.Where(x => x.ID == id).FirstOrDefault();
            if (país == null)
            {
                return NotFound($"No existe el país con ID igual a {id}.");
            }

            try
            {
                context.Países.Remove(país);
                context.SaveChanges();
                return Ok($"El país {país.PaísNombre} ha sido eliminado.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
