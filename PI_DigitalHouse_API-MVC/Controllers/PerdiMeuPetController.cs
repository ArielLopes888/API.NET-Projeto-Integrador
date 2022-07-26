﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PI_DigitalHouse_API_MVC.Models;

namespace PI_DigitalHouse_API_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerdiMeuPetController : ControllerBase
    {
        private readonly MeuPetContext _context;

        public PerdiMeuPetController(MeuPetContext context)
        {
            _context = context;
        }

        // GET: api/PerdiMeusPets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerdiMeuPet>>> GetPerdiMeuPet()
        {
          if (_context.PerdiMeusPets == null)
          {
              return NotFound();
          }
            return await _context.PerdiMeusPets.ToListAsync();
        }

        // GET: api/PerdiMeusPets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PerdiMeuPet>> GetPerdiMeuPet(int id)
        {
          if (_context.PerdiMeusPets == null)
          {
              return NotFound();
          }
            var perdiMeuPet = await _context.PerdiMeusPets.FindAsync(id);

            if (perdiMeuPet == null)
            {
                return NotFound();
            }

            return perdiMeuPet;
        }

        // PUT: api/PerdiMeusPets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerdiMeuPet(int id, PerdiMeuPet perdiMeuPet)
        {
            if (id != perdiMeuPet.Id)
            {
                return BadRequest();
            }

            _context.Entry(perdiMeuPet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerdiMeuPetExists(id))
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

        // POST: api/PerdiMeusPets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PerdiMeuPet>> PostPerdiMeuPet(PerdiMeuPet perdiMeuPet)
        {
          if (_context.PerdiMeusPets == null)
          {
              return Problem("Entity set 'MeuPetContext.PerdiMeusPets'  is null.");
          }
            _context.PerdiMeusPets.Add(perdiMeuPet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerdiMeuPet", new { id = perdiMeuPet.Id }, perdiMeuPet);
        }

        // DELETE: api/PerdiMeusPets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerdiMeuPet(int id)
        {
            if (_context.PerdiMeusPets == null)
            {
                return NotFound();
            }
            var perdiMeuPet = await _context.PerdiMeusPets.FindAsync(id);
            if (perdiMeuPet == null)
            {
                return NotFound();
            }

            _context.PerdiMeusPets.Remove(perdiMeuPet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerdiMeuPetExists(int id)
        {
            return (_context.PerdiMeusPets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
