using Locación.Shared.Data;
using Locación.Shared.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locación.Server.Controllers
{
    [ApiController]
    [Route("api/Provincia")]
    public class ProvController : ControllerBase
    {
        private readonly dataContext context;

        public ProvController(dataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Provincia>>> Get()
        {
            return await context.Provincias.Include(x => x.País).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Provincia>> Get(int id)
        {
            var prov = await context.Provincias.Where(x => x.ID == id).Include(x => x.País).FirstOrDefaultAsync();
            if (prov == null)
            {
                return NotFound($"No existe el país con ID igual a {id}.");
            }
            return Ok(prov);
        }

        [HttpPost]
        public async Task<ActionResult<Provincia>> Post(Provincia prov)
        {
            try
            {
                context.Provincias.Add(prov);
                await context.SaveChangesAsync();
                return prov;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Provincia prov)
        {
            if (id != prov.ID)
            {
                return BadRequest("Datos incorrectos.");
            }
            var provOther = await context.Provincias.Where(x => x.ID == id).FirstOrDefaultAsync();

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
                await context.SaveChangesAsync();
                return Ok("Los datos han sido cambiados.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var prov = await context.Provincias.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (prov == null)
            {
                return NotFound($"No existe la provincia con ID igual a {id}.");
            }

            try
            {
                context.Provincias.Remove(prov);
                await context.SaveChangesAsync();
                return Ok($"La provincia {prov.ProvNombre} ha sido eliminada.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
