using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;


namespace LibraryManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly Library_Management_SystemContext _context;
        private readonly IAccountRepo _accountRepo;
        public AdminController(Library_Management_SystemContext context, IAccountRepo accountRepo)
        {
            _context = context;
            _accountRepo = accountRepo;
        }



        public IActionResult Index()
        {
            var lendData = from b in _context.LendRequests.Include(x => x.User).Include(y => y.Book) select b;
            return View(lendData.ToList());
        }
        public IActionResult LentBooks()
        {
            var lendData = from b in _context.LendRequests.Include(x => x.User).Include(y => y.Book) select b;
            return View(lendData.ToList());
        }
        public ActionResult RequestApproved(int lendId)
        {
            var lendedBook = _context.LendRequests.FirstOrDefault(b => b.LendId == lendId);
            lendedBook.LendStatus = "Approved";
            lendedBook.ReturnDate = lendedBook.LendDate.AddDays(14);
            var bookid = lendedBook.BookId;
            _context.Books.FirstOrDefault(b => b.BookId == bookid).IssuedBooks++;
            _context.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
        public ActionResult RequestDeclined(int lendId)
        {
            var lendedBook = _context.LendRequests.FirstOrDefault(b => b.LendId == lendId);
            lendedBook.LendStatus = "Declined";
            lendedBook.ReturnDate = lendedBook.LendDate;
            _context.Books.SingleOrDefault(b => b.BookId == lendedBook.BookId).NoOfCopies++;
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }



    }
}