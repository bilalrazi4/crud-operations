using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using officeapi.Models;

namespace officeapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly officeContext db;

        public EmployeController(officeContext context)
        {
            db = context;
        }

        // GET: api/Employe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employe>>> GetEmployes()
        {
          if (db.Employes == null)
          {
              return NotFound();
          }
            return await db.Employes.ToListAsync();
        }

        // GET: api/Employe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employe>> GetEmploye(int id)
        {
          if (db.Employes == null)
          {
              return NotFound();
          }
            var employe = await db.Employes.FindAsync(id);

            if (employe == null)
            {
                return NotFound();
            }

            return employe;
        }

        // PUT: api/Employe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploye(int id, Employe employe)
        {
            if (id != employe.Id)
            {
                return BadRequest();
            }

            db.Entry(employe).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employe>> PostEmploye(Employe employe)
        {
          if (db.Employes == null)
          {
              return Problem("Entity set 'officeContext.Employes'  is null.");
          }
            db.Employes.Add(employe);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetEmploye", new { id = employe.Id }, employe);
        }

        // DELETE: api/Employe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploye(int id)
        {
            if (db.Employes == null)
            {
                return NotFound();
            }
            var employe = await db.Employes.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }

            db.Employes.Remove(employe);
            await db.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeExists(int id)
        {
            return (db.Employes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
