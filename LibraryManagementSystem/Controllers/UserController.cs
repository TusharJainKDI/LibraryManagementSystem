using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly Library_Management_SystemContext _context;
        private readonly IAccountRepo _accountRepo;
        public UserController(Library_Management_SystemContext context, IAccountRepo accountRepo)
        {
            _context = context;
            _accountRepo = accountRepo;
        }
        public ViewResult Index(string searchString)
        {
            var bookCard = from b in _context.Books.Include(c => c.Author) select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                bookCard = bookCard.Where(s =>
                    s.BookTitle.Contains(searchString) ||
                    s.NoOfCopies.ToString().Contains(searchString) ||
                    s.Author.AuthorName.Contains(searchString) ||
                    s.Category.Contains(searchString)
                );
            }
            return View(bookCard.ToList());
        }

        public ViewResult RequestToLend(int bookId)
        {
            var username = HttpContext.Session.GetString("Uname");
            var user = _accountRepo.getUserByName(username);
            var noofcopies = _context.Books.SingleOrDefault(b => b.BookId == bookId).NoOfCopies;
            if (noofcopies <= 0)
            {
                return View("RequestedError");
            }
            _context.Books.SingleOrDefault(b => b.BookId == bookId).NoOfCopies--;
            LendRequest lendRequest = new LendRequest()
            {
                LendStatus = "Requested",
                LendDate = System.DateTime.Now,
                BookId = bookId,
                UserId = user.UserId,
                Book = _context.Books.SingleOrDefault(b => b.BookId == bookId),
                User = _context.Accounts.SingleOrDefault(u => u.UserId == user.UserId),
            };
            _context.LendRequests.Add(lendRequest);
            _context.SaveChanges();

            return View("Requested");
        }

        public IActionResult Issue()
        {
            var lendBooks = from b in _context.LendRequests.Include(x => x.User).Include(y => y.Book) 
                            select b;
            return View(lendBooks.ToList());
        }
        public async Task<IActionResult> Record()
        {
            var username = HttpContext.Session.GetString("Uname");
            var user = _context.Accounts.Where(b => b.UserName == username).FirstOrDefault();
            var lmscontext = _context.LendRequests.Where(b => b.UserId == user.UserId).Include(x => x.User).Include(y => y.Book);
            return View(await lmscontext.ToListAsync());
        }
    }
}
