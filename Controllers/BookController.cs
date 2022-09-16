using BooksCrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BooksCrudOperation.Controllers
{
    public class BookController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }
        public ActionResult AddBook()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult SaveBook(Book b,int catId)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("AddBook");
            }
            db.Books.Add(b);
            b.CategoryId = catId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBook(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var match = db.Books.Where(std => std.Id == Id).FirstOrDefault();
            if(match != null)
            {
                db.Books.Remove(match);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult OpenFormEdit(int Id)
        {
            var match = db.Books.Find(Id);
            return View(match);
        }
        public ActionResult Edit(int? Id,Book newBook)
        {    
            if(Id == null)
            {
                return NotFound();
            }
            var match = db.Books.Find(Id);
            if(match != null)
            {
                match.Title = newBook.Title;
                match.Author = newBook.Author;
                match.Description = newBook.Description;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            var book = db.Books.Find(id);
            if(book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        public ActionResult Search(string Title)
        {
            ViewBag.val = Title;
            var ans = db.Books.Where(b => b.Title.ToLower().Contains(Title.ToLower())).ToList();
            return View("Index",ans);
        }
    }
}
