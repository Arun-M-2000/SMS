using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMS.Repository;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustRegRepositoryController : ControllerBase
    {

        private readonly ICustRegRepository _custRegRepository;

        public CustRegRepositoryController(ICustRegRepository custRegRepository)
        {
            _custRegRepository = custRegRepository;
        }

        #region Get All Customers
        [HttpGet("GetCustomer")]


        public async Task<ActionResult<IEnumerable<TblCustomerRegistration>>> GetCust()
        {
            return await _custRegRepository.GetAllCustomer();
        }
        #endregion

        #region Add Customer
        [HttpPost]
        public async Task<IActionResult> AddingEmployee([FromBody] TblCustomerRegistration  tblCustomerRegistration)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cusId = await _custRegRepository.AddCustomer(tblCustomerRegistration);
                    if (cusId > 0)
                    {
                        return Ok(cusId);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }

        #endregion

        #region Update Customer

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdatingCustomer([FromBody] TblCustomerRegistration tblCustomerRegistration)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _custRegRepository.UpdateCustomer(tblCustomerRegistration);
                    return Ok(tblCustomerRegistration);

                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
        #endregion


        #region get and Customer by crid 
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCustomerRegistration>> GetcustById(int? id)
        {
            try
            {
                var cust = await _custRegRepository.GetCustomerById(id);
                if (cust == null)
                {
                    return NotFound();
                }
                return Ok(cust);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion


        #region Delete an customer

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletingCustomer(int? id)
        {
            try
            {
                int crid = await _custRegRepository.DeleteCustomerById(id);
                if (crid> 0)
                {
                    return Ok(crid);

                }
                return NotFound();

            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion

        #region getCUSTOMER AND PURCHASE
        [HttpGet("Gets")]

        public async Task<ActionResult<IEnumerable<CusPurVM>>> GetDepEmpVM()
        {
            return await _custRegRepository.GetCusPurDetails();
        }

        #endregion 
    }
}
