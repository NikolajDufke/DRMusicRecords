using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly RecordDBContext _context;

        public RecordsController(RecordDBContext context)
        {
            _context = context;

            AddRecords();



        }

        private async void AddRecords()
        {
            if (_context.Records.Count() == 0)
            {
                _context.Records.Add(new RecordDB()
                    {Artist = "JAAIIL", Duration = 150, Title = "Superhelten", YearOfPublication = 2020});
                _context.Records.Add(new RecordDB()
                { Artist = "Karla og Liva", Duration = 150, Title = "Brug din fantasi", YearOfPublication = 2020 });
                _context.Records.Add(new RecordDB()
                { Artist = "Julie", Duration = 150, Title = "Stjernen i det blå", YearOfPublication = 2020 });
                _context.Records.Add(new RecordDB()
                { Artist = "Siff", Duration = 150, Title = "Mit hjerte der griner", YearOfPublication = 2020 });
                _context.Records.Add(new RecordDB()
                { Artist = "Mynthe", Duration = 150, Title = "Syng det ud", YearOfPublication = 2020 });
                _context.Records.Add(new RecordDB()
                { Artist = "Liva", Duration = 150, Title = "Ingen plan B", YearOfPublication = 2020 });
                _context.Records.Add(new RecordDB()
                { Artist = "William", Duration = 150, Title = "Stjerneskud", YearOfPublication = 2020 });
                _context.Records.Add(new RecordDB()
                { Artist = "D&A", Duration = 150, Title = "Boombadah basta", YearOfPublication = 2020 });
                await _context.SaveChangesAsync();
            }

        }

        // GET: api/Records
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecordDB>>> GetRecords()
        {
            return await _context.Records.ToListAsync();
        }

        // GET: api/Records/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecordDB>> GetRecord(int id)
        {
            var record = await _context.Records.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            return record;
        }

        // PUT: api/Records/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord(int id, RecordDB recordDb)
        {
            if (id != recordDb.Id)
            {
                return BadRequest();
            }

            _context.Entry(recordDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(id))
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

        // POST: api/Records
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RecordDB>> PostRecord(RecordDB recordDb)
        {
            _context.Records.Add(recordDb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecord", new { id = recordDb.Id }, recordDb);
        }

        // DELETE: api/Records/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecordDB>> DeleteRecord(int id)
        {
            var record = await _context.Records.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.Records.Remove(record);
            await _context.SaveChangesAsync();

            return record;
        }

        private bool RecordExists(int id)
        {
            return _context.Records.Any(e => e.Id == id);
        }
    }
}
