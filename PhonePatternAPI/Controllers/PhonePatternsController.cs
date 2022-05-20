using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhonePatternAPI.Models;

namespace PhonePatternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonePatternsController : ControllerBase
    {
        private readonly PatternContext _context;

        private readonly string[] _lines = System.IO.File.ReadLines(@"C:\Users\chri615w\Desktop\PhonePattern\PhonePatternAPIapp\PhonePatternAPI\wwwroot\misc\TextFile.txt").ToArray();

        public PhonePatternsController(PatternContext context)
        {
            _context = context;
        }

        // GET: api/PhonePatterns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhonePattern>>> GetPhonePatterns()
        {
          if (_context.PhonePatterns == null)
          {
              return NotFound();
          }
            return await _context.PhonePatterns.ToListAsync();
        }

        // GET: api/PhonePatterns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetPhonePattern(long id)
        {
            if (_context.PhonePatterns == null)
            {
                return NotFound();
            }
            var phonePattern = _lines[id];

            if (phonePattern == null)
            {
                return NotFound();
            }

            return phonePattern;
        }

        // PUT: api/PhonePatterns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhonePattern(long id, PhonePattern phonePattern)
        {
            if (id != phonePattern.Id)
            {
                return BadRequest();
            }

            _context.Entry(phonePattern).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhonePatternExists(id))
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

        // POST: api/PhonePatterns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhonePattern>> PostPhonePattern(PhonePattern phonePattern)
        {
          if (_context.PhonePatterns == null)
          {
              return Problem("Entity set 'PatternContext.PhonePatterns'  is null.");
          }
            _context.PhonePatterns.Add(phonePattern);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhonePattern", new { id = phonePattern.Id }, phonePattern);
        }

        // DELETE: api/PhonePatterns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhonePattern(long id)
        {
            if (_context.PhonePatterns == null)
            {
                return NotFound();
            }
            var phonePattern = await _context.PhonePatterns.FindAsync(id);
            if (phonePattern == null)
            {
                return NotFound();
            }

            _context.PhonePatterns.Remove(phonePattern);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhonePatternExists(long id)
        {
            return (_context.PhonePatterns?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
