using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMS.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {

        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderController(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        #region Get PurchaseOrder
        [HttpGet("GetProOrder")]


        public async Task<ActionResult<IEnumerable<TblPurchaseOrder>>> GetPurchaseOrder()
        {
            return await _purchaseOrderRepository.GetAllPurchaseOrder();
        }
        #endregion

        #region Add PurchaseOrder
        [HttpPost]
        public async Task<IActionResult> AddingPurchaseOrder([FromBody] TblPurchaseOrder tblPurchaseOrder)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cusId = await _purchaseOrderRepository.AddPurchaseOrder(tblPurchaseOrder);
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

        #region Update PurchaseOrder

        [HttpPut]
        public async Task<IActionResult> UpdatingPurchaseOrder([FromBody] TblPurchaseOrder tblPurchaseOrder)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _purchaseOrderRepository.UpdatePurchaseOrder(tblPurchaseOrder);
                    return Ok(tblPurchaseOrder);

                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
        #endregion


        #region get and PurchaseOrder by 
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPurchaseOrder>> GetPurchaseOrder(int? id)
        {
            try
            {
                var cust = await _purchaseOrderRepository.GetPurchaseOrderById(id);
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


        #region Delete an PurchaseOrder

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletingPurchaseOrder(int? id)
        {
            try
            {
                int crid = await _purchaseOrderRepository.DeletePurchaseOrderById(id);
                if (crid > 0)
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



    }
}
