using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITest.Data;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackDatasController : ControllerBase
    {
        private readonly WebAPITestContext _context;

        public FeedbackDatasController(WebAPITestContext context)
        {
            _context = context;
        }

        // GET: api/FeedbackDatas
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackData>>> GetFeedbackData()
        {
            return await _context.FeedbackData.ToListAsync();
        }

        // GET: api/FeedbackDatas/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackData>> GetFeedbackData(int id)
        {
            var feedbackData = await _context.FeedbackData.FindAsync(id);

            if (feedbackData == null)
            {
                return NotFound();
            }

            return feedbackData;
        }

        // PUT: api/FeedbackDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedbackData(int id, FeedbackData feedbackData)
        {
            if (id != feedbackData.FeedbackId)
            {
                return BadRequest();
            }

            _context.Entry(feedbackData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackDataExists(id))
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

        // POST: api/FeedbackDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedbackData>> PostFeedbackData(FeedbackData feedbackData)
        {
            _context.FeedbackData.Add(feedbackData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedbackData", new { id = feedbackData.FeedbackId }, feedbackData);
        }

        // DELETE: api/FeedbackDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbackData(int id)
        {
            var feedbackData = await _context.FeedbackData.FindAsync(id);
            if (feedbackData == null)
            {
                return NotFound();
            }

            _context.FeedbackData.Remove(feedbackData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedbackDataExists(int id)
        {
            return _context.FeedbackData.Any(e => e.FeedbackId == id);
        }
    }
}
