
using SMS.Models;

namespace SMS.Repository
{
    public interface ILoginRepository
    {
        public TblLogin UserValidation(string userName, string password);

    }
}
