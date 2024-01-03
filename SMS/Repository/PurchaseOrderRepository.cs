using Microsoft.EntityFrameworkCore;
using SMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Repository
{
    public class PurchaseOrderRepository: IPurchaseOrderRepository
    {

        private readonly SMSContext _context;

        public PurchaseOrderRepository(SMSContext context)
        {
            _context = context;
        }

        #region//Get all PurchaseOrder
        public async Task<List<TblPurchaseOrder>> GetAllPurchaseOrder()
        {
            if (_context != null)
            {
                return await _context.TblPurchaseOrder.ToListAsync();
            }
            return null;
        }
        #endregion


        #region Add PurchaseOrder

        public async Task<int> AddPurchaseOrder(TblPurchaseOrder tblPurchaseOrder)
        {
            if (_context != null)
            {
                await _context.TblPurchaseOrder.AddAsync(tblPurchaseOrder);
                await _context.SaveChangesAsync();
                return (int)tblPurchaseOrder.CrId;

            }
            return 0;
        }

        #endregion

        #region update PurchaseOrder
        public async Task UpdatePurchaseOrder(TblPurchaseOrder tblPurchaseOrder)
        {
            if (_context != null)
            {
                _context.Entry(tblPurchaseOrder).State = EntityState.Modified;
                _context.TblPurchaseOrder.Update(tblPurchaseOrder);
                await _context.SaveChangesAsync();

            }

        }
        #endregion


        #region Get PurchaseOrder by id

        public async Task<TblPurchaseOrder> GetPurchaseOrderById(int? id)
        {
            if (_context != null)
            {
                var cust = await _context.TblPurchaseOrder.FindAsync(id);
                return cust;
            }
            return null;

        }

        #endregion

        #region Delete  PurchaseOrder by id
        public async Task<int> DeletePurchaseOrderById(int? id)
        {
            if (_context != null)
            {
                var cust = await _context.TblPurchaseOrder.FirstOrDefaultAsync(cus => cus.Oid == id);
                if (cust != null)
                {
                    //Delete
                    _context.TblPurchaseOrder.Remove(cust);

                    //commit
                    await _context.SaveChangesAsync();
                    return cust.Oid;
                }

            }
            return 0;
        }

        #endregion





    }
}
