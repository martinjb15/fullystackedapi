using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fullystackedapi.Models.insurance;

namespace fullystackedapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly customerDetailContext _context;

        public CustomerDetailsController(customerDetailContext context)
        {
            _context = context;
        }

        // GET: api/CustomerDetails
        [HttpGet("/insurance/customer")]
        public async Task<ActionResult<IEnumerable<CustomerDetail>>> GetCustomerDetails()
        {
            return await _context.CustomerDetails.ToListAsync();
        }

        // GET: api/CustomerDetails/5
        [HttpGet("/insurance/customer/{id}")]
        public async Task<ActionResult<CustomerDetail>> GetCustomerDetail(int id)
        {
            var customerDetail = await _context.CustomerDetails.FindAsync(id);

            if (customerDetail == null)
            {
                return NotFound();
            }

            return customerDetail;
        }

        // PUT: api/CustomerDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("/insurance/customer/{id}")]
        public async Task<IActionResult> PutCustomerDetail(int id, CustomerDetail customerDetail)
        {
            if (id != customerDetail.generatedKeyId)
            {
                return BadRequest();
            }

            _context.Entry(customerDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDetailExists(id))
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

        // POST: api/CustomerDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost ("/insurance/customer/")]
        public async Task<ActionResult<CustomerDetail>> PostCustomerDetail(CustomerDetail customerDetail)
        {
            _context.CustomerDetails.Add(customerDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerDetail", new { id = customerDetail.generatedKeyId }, customerDetail);
        }

        // DELETE: api/CustomerDetails/5
        [HttpDelete("/insurance/customer/{id}")]
        public async Task<ActionResult<CustomerDetail>> DeleteCustomerDetail(int id)
        {
            var customerDetail = await _context.CustomerDetails.FindAsync(id);
            if (customerDetail == null)
            {
                return NotFound();
            }

            _context.CustomerDetails.Remove(customerDetail);
            await _context.SaveChangesAsync();

            return customerDetail;
        }

        private bool CustomerDetailExists(int id)
        {
            return _context.CustomerDetails.Any(e => e.generatedKeyId == id);
        }
    }
}
