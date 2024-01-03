using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Models;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace SMS.Repository
{
    public class CustRegRepository: ICustRegRepository
    {

        private readonly SMSContext _context;

        public CustRegRepository(SMSContext context)
        {
            _context = context;
        }

        #region//Get all Customer
        public async Task<List<TblCustomerRegistration>> GetAllCustomer()
        {
            if (_context != null)
            {
                return await _context.TblCustomerRegistration.ToListAsync();
            }
            return null;
        }
        #endregion


        #region Add Customer

        public async Task<int> AddCustomer(TblCustomerRegistration tblCustomerRegistration)
        {
            if (_context != null)
            {
                await _context.TblCustomerRegistration.AddAsync(tblCustomerRegistration);
                await _context.SaveChangesAsync();
                return (int)tblCustomerRegistration.CrId;

            }
            return 0;
        }

        #endregion

        #region update customer
        public async Task UpdateCustomer(TblCustomerRegistration tblCustomerRegistration)
        {
            if (_context != null)
            {
                _context.Entry(tblCustomerRegistration).State = EntityState.Modified;
                _context.TblCustomerRegistration.Update(tblCustomerRegistration);
                await _context.SaveChangesAsync();

            }

        }
        #endregion


        #region Get Customer by id

        public async Task<TblCustomerRegistration> GetCustomerById(int? id)
        {
            if (_context != null)
            {
                var cust = await _context.TblCustomerRegistration.FindAsync(id);
                return cust;
            }
            return null;

        }

        #endregion

        #region Delete  Customer by id
        public async Task<int> DeleteCustomerById(int? id)
        {
            if (_context != null)
            {
                var cust= await _context.TblCustomerRegistration.FirstOrDefaultAsync(cus => cus.CrId == id);
                if (cust != null)
                {
                    //Delete
                    _context.TblCustomerRegistration.Remove(cust);

                    //commit
                    await _context.SaveChangesAsync();
                    return cust.CrId;
                }

            }
            return 0;
        }

        #endregion



        #region  get values from two tables

        public async Task<List<CusPurVM>> GetCusPurDetails()
        {
            if (_context != null)
            {

                var result = from c in _context.TblCustomerRegistration
                             join p in _context.TblPurchaseOrder
                             on c.CrId equals p.CrId
                             select new CusPurVM
                             {
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,
                                 Gender = c.Gender,
                                 PhoneNumber = c.PhoneNumber,
                                 PurchaseOrderNumber = p.PurchaseOrderNumber,
                                 ItemName = p.ItemName,
                                 Quantity = p.Quantity,
                                 OrderDate = p.OrderDate,
                                 DeliveryDate = p.DeliveryDate,
                                 Status = p.Status
                             };
                return await result.ToListAsync();
            }

            return null;
        }


        #endregion



    }
}
