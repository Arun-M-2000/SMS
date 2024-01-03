using SMS.Models;
using SMS.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Repository
{
    public interface ICustRegRepository
    {

        Task<List<TblCustomerRegistration>> GetAllCustomer();
        Task<int> AddCustomer(TblCustomerRegistration tblCustomerRegistration);

        Task UpdateCustomer(TblCustomerRegistration tblCustomerRegistration);

        Task<TblCustomerRegistration> GetCustomerById(int? id);
        Task<int> DeleteCustomerById(int? id);
        Task<List<CusPurVM>> GetCusPurDetails();
    }
}
