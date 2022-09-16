using Microsoft.AspNetCore.Mvc;
using BooksCrudOperation.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BooksCrudOperation.Models
{
    public class CategoryController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Categories()
        {
            var ans = db.Categories.Include(b => b.Books).ToList();
            return View(ans);
        }
        public ActionResult Openform()
        {
            return View();
        }
        public ActionResult AddCategory(Category c)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Openform");
            }
            db.Categories.Add(c);
            db.SaveChanges();
            return RedirectToAction("Categories");
        }
        public ActionResult MathFilter()
        {
            var ans = db.Categories.Where(c => c.Name == "Math").Include(b => b.Books).ToList();
            return View("Categories",ans);
        }

        public ActionResult ProgrammingFilter()
        {
            var ans = db.Categories.Where(c => c.Name == "Programming").Include(b =>b.Books).ToList();

            return View("Categories", ans);
        }

        public ActionResult ScienceFilter()
        {
            var ans = db.Categories.Where(c => c.Name == "Science").Include(b => b.Books).ToList();

            return View("Categories", ans);
        }

    }
}
