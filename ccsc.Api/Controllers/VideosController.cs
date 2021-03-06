﻿using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Tutorials;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccsc.Api.Controllers
{
	[Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class VideosController : ControllerBase
    {
        private readonly CcscContext _context;

        public VideosController(CcscContext context)
        {
            _context = context;
        }

        // GET: /Videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Video>>> GetVideos()
        {
            var result = await _context.Videos
	            .Where(v=>v.PublishedOn.HasValue)
	            .Include(v=>v.SubSystems)
	            .Include(v=>v.UserTypes)
	            .Include(v=>v.Customers)
	            .ToListAsync();
            Request.HttpContext.Response.Headers.Add("x-New", "30");
            return result;
        }

        [HttpGet("subsystem/{id}")]
        public async Task<ActionResult<IEnumerable<Video>>> GetProductVideos(int id)
        {

            var result = await _context.Videos
				.Where(v=>v.SubSystems.Any(p=>p.SubSystemId == id))
		        
		        .ToListAsync();
	        return result;
        }

        [HttpGet("Usertype/{id}")]
        public async Task<ActionResult<IEnumerable<Video>>> GetAudiencVideos(int id)
        {
	        var result = await _context.Videos
		        .Include(v=>v.SubSystems)
		        .Where(v=>v.UserTypes.Any(a=>a.UserTypeId==id))
		        .ToListAsync();
	        return result;
        }

        [HttpGet("Usertype/{id}")]
        public async Task<ActionResult<IEnumerable<Video>>> GetCustomerVideos(int id)
        {
	        var result = await _context.Videos
		        .Include(v => v.Customers)
		        .Where(v => v.Customers.Any(a => a.CustomerId == id))
		        .ToListAsync();
	        return result;
        }
        
        // GET: api/Videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideo(int id)
        {
	        var video = await _context.Videos.Where(v=>v.VideoId == id)
		        .Include(v => v.SubSystems.Where(p=>p.IsActive))
		        .Include(v => v.UserTypes)
		        .Include(v=>v.Customers)
		        .FirstOrDefaultAsync();
	            //.FindAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }

        // PUT: api/Videos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideo(int id, Video video)
        {
            if (id != video.VideoId)
            {
                return BadRequest();
            }

            _context.Entry(video).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(id))
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

        // POST: api/Videos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Video>> PostVideo(Video video)
        {
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideo", new { id = video.VideoId }, video);
        }

        // DELETE: api/Videos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Video>> DeleteVideo(int id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();

            return video;
        }

        private bool VideoExists(int id)
        {
            return _context.Videos.Any(e => e.VideoId == id);
        }
    }
}
