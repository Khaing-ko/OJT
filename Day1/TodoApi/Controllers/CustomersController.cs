using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CustomersController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResult>>> GetCus()
        {
            var Cus =  await _repositoryWrapper.Customer.ListCustomer();
            return Ok(Cus);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCus(long id)
        {
            var cus = await _repositoryWrapper.Customer.FindByIDAsync(id);
            if (cus == null)
            {
                return NotFound();
            }
            return cus;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCus(long id, Customer item)
        {
            if (id != item.CustomerId)
            {
                return BadRequest();
            }

            Customer? objCustomer;
            try
            {
                objCustomer = await _repositoryWrapper.Customer.FindByIDAsync(id);
                if (objCustomer == null) 
                    throw new Exception("Invalid Customer ID");
                
                objCustomer.CustomerName = item.CustomerName;
                
                await _repositoryWrapper.Customer.UpdateAsync(objCustomer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Accepted();
        }


        [HttpPost("search/{term}")]
        public async Task<ActionResult<IEnumerable<Customer>>>  SearchCustomer(string term)
        {
            var cusList = await _repositoryWrapper.Customer.SearchCustomer(term);
            return Ok(cusList);           
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCus(Customer item)
        {
            await _repositoryWrapper.Customer.CreateAsync(item, true);
            return CreatedAtAction(nameof(GetCus), new { id = item.CustomerId }, item);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var item = await _repositoryWrapper.Customer.FindByIDAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            await _repositoryWrapper.Customer.DeleteAsync(item, true);
            
            return NoContent();
        }


        private bool CusExists(long id)
        {
            return _repositoryWrapper.Customer.IsExists(id);
        }
    }
}
