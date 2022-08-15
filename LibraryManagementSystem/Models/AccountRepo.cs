using System.Collections.Generic;
using System.Linq;
namespace LibraryManagementSystem.Models
{
    public class AccountRepo: IAccountRepo
    {
        private readonly Library_Management_SystemContext _librarymanagementsystemcontext;
        public AccountRepo(Library_Management_SystemContext context)
        {
            _librarymanagementsystemcontext = context;
        }
        public Account getUserByName(string username)
        {
            return _librarymanagementsystemcontext.Accounts.FirstOrDefault(u => u.UserName == username);
        }
    }
}
