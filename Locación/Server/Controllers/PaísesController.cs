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
    [Route("api/Países")]
    public class PaísesController : ControllerBase
    {
        private readonly dataContext context;

        public PaísesController(dataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<País>>> Get()
        {
            return await context.Países.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<País>> Get(int id)
        {
            var país = await context.Países.Where(x => x.ID == id).Include(x => x.Provincias).FirstOrDefaultAsync();
            if(país == null)
            {
                return NotFound($"No existe el país con ID igual a {id}.");
            }
            return país;
        }

        [HttpPost]
        public async Task<ActionResult<País>> Post(País país)
        {
            try
            {
                context.Países.Add(país);
                await context.SaveChangesAsync();
                return país;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] País país)
        {
            if(id != país.ID)
            {
                return BadRequest("Datos incorrectos.");
            }
            var paísOther = await context.Países.Where(x => x.ID == id).FirstOrDefaultAsync();

            if(paísOther == null)
            {
                return NotFound("No existe ese país.");
            }

            paísOther.PaísCódigo = país.PaísCódigo;
            paísOther.PaísNombre = país.PaísNombre;

            try
            {
                context.Países.Update(paísOther);
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
            var país = await context.Países.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (país == null)
            {
                return NotFound($"No existe el país con ID igual a {id}.");
            }

            try
            {
                context.Países.Remove(país);
                await context.SaveChangesAsync();
                return Ok($"El país {país.PaísNombre} ha sido eliminado.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
