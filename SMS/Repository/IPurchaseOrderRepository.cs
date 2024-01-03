using SMS.Models;
using SMS.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Repository
{
    public interface IPurchaseOrderRepository
    {


        Task<List<TblPurchaseOrder>> GetAllPurchaseOrder();
        Task<int> AddPurchaseOrder(TblPurchaseOrder tblPurchaseOrder);

        Task UpdatePurchaseOrder(TblPurchaseOrder tblPurchaseOrder);

        Task<TblPurchaseOrder> GetPurchaseOrderById(int? id);
        Task<int> DeletePurchaseOrderById(int? id);
    }
}
