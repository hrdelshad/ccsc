﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Products;

namespace ccsc.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChangeSetsController : ControllerBase
    {
        private readonly CcscContext _context;

        public ChangeSetsController(CcscContext context)
        {
            _context = context;
        }

        // GET: api/ChangeSets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChangeSet>>> GetChangeSets()
        {
            return await _context.ChangeSets.OrderByDescending(c=>c.ChangeSetId).ToListAsync();
        }

        // GET: api/ChangeSets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChangeSet>> GetChangeSet(int id)
        {
            var changeSet = await _context.ChangeSets.FindAsync(id);

            if (changeSet == null)
            {
                return NotFound();
            }

            return changeSet;
        }

        // PUT: api/ChangeSets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChangeSet(int id, ChangeSet changeSet)
        {
            if (id != changeSet.ChangeSetId)
            {
                return BadRequest();
            }

            _context.Entry(changeSet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChangeSetExists(id))
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

        // POST: api/ChangeSets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChangeSet>> PostChangeSet(ChangeSet changeSet)
        {
            _context.ChangeSets.Add(changeSet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChangeSetExists(changeSet.ChangeSetId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChangeSet", new { id = changeSet.ChangeSetId }, changeSet);
        }

        // DELETE: api/ChangeSets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChangeSet>> DeleteChangeSet(int id)
        {
            var changeSet = await _context.ChangeSets.FindAsync(id);
            if (changeSet == null)
            {
                return NotFound();
            }

            _context.ChangeSets.Remove(changeSet);
            await _context.SaveChangesAsync();

            return changeSet;
        }

        private bool ChangeSetExists(int id)
        {
            return _context.ChangeSets.Any(e => e.ChangeSetId == id);
        }
    }
}