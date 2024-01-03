

using SMS.Models;
using System.Linq;

namespace SMS.Repository
{
    public class LoginRepositoty: ILoginRepository
    {
        #region Find user by Credentials

        private readonly SMSContext _context;

        public LoginRepositoty(SMSContext context)
        {
            _context = context;
        }

        public TblLogin UserValidation(string un, string pwd)
        {
            if (_context != null)
            {
                TblLogin user = _context.TblLogin.FirstOrDefault(u => u.Username == un && u.Password == pwd);
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        #endregion



    }
}
