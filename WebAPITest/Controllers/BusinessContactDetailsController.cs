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
    public class BusinessContactDetailsController : ControllerBase
    {
        private readonly WebAPITestContext _context;

        public BusinessContactDetailsController(WebAPITestContext context)
        {
            _context = context;
        }

        // GET: api/BusinessContactDetails
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessContactDetails>>> GetBusinessContactDetails()
        {
            return await _context.BusinessContactDetails.ToListAsync();
        }

        // GET: api/BusinessContactDetails/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessContactDetails>> GetBusinessContactDetails(int id)
        {
            var businessContactDetails = await _context.BusinessContactDetails.FindAsync(id);

            if (businessContactDetails == null)
            {
                return NotFound();
            }

            return businessContactDetails;
        }

        // PUT: api/BusinessContactDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessContactDetails(int id, BusinessContactDetails businessContactDetails)
        {
            if (id != businessContactDetails.BusinessId)
            {
                return BadRequest();
            }

            _context.Entry(businessContactDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessContactDetailsExists(id))
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

        // POST: api/BusinessContactDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusinessContactDetails>> PostBusinessContactDetails(BusinessContactDetails businessContactDetails)
        {
            _context.BusinessContactDetails.Add(businessContactDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessContactDetails", new { id = businessContactDetails.BusinessId }, businessContactDetails);
        }

        // DELETE: api/BusinessContactDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessContactDetails(int id)
        {
            var businessContactDetails = await _context.BusinessContactDetails.FindAsync(id);
            if (businessContactDetails == null)
            {
                return NotFound();
            }

            _context.BusinessContactDetails.Remove(businessContactDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusinessContactDetailsExists(int id)
        {
            return _context.BusinessContactDetails.Any(e => e.BusinessId == id);
        }
    }
}
