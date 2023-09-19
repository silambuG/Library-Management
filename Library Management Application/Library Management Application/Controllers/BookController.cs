using Library_Management_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_Application.Controllers
{
    public class BookController : Controller
    {
        private ApplicationContext _db;

        public BookController(ApplicationContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Books> list = _db.books.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Books books)
        {
            if ((int)books.PublishYear > 2022)
            {
                ModelState.AddModelError("PublishYear", "Year should be below 2023");
            }
            if ((int)books.BookcategoryId == 0)
            {
                ModelState.AddModelError("BookcategoryId", "You should Select Department");
            }
            var retriveBook = _db.books.Where(b => b.BookName == books.BookName);

            if (retriveBook.Count()>0)
            {
                ModelState.AddModelError("BookName", "The Book Already Exists");
            }
            if (ModelState.IsValid)
            {
                _db.books.Add(books);
                _db.SaveChanges();
                TempData["success"] = "Book Details Created Successfully";
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                if (id == null || id == 0)
                {
                    return View("Edit");
                }
                var retriveBook = _db.books.Find(id);
                return View(retriveBook);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Books update)
        {
            if ((int)update.PublishYear > 2022)
            {
                ModelState.AddModelError("PublishYear", "Year should be below 2023");
            }
            if ((int)update.BookcategoryId == 0)
            {
                ModelState.AddModelError("BookcategoryId", "You should Select Department");
            }
            var retriveBook = _db.books.Where(b => b.BookName == update.BookName);
            int a = retriveBook.Count();
            if (retriveBook.Count() > 1)
            {
                if (true)
                {
                    ModelState.AddModelError("BookName", "The Book Already Exists");
                }
                
            }
            if (ModelState.IsValid)
            {
                _db.books.Update(update);
                _db.SaveChanges();
                TempData["success"] = "Book Details Updated Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult ViewBook(int id)
        {
            if (id!=null)
            {
                var BookDeails = _db.books.Find(id);
                return View(BookDeails);
            }
            TempData["success"] = "Book Details Updated Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }
            var data = _db.books.Find(id);
            _db.Remove(data);
            _db.SaveChanges();
            TempData["success"] = "Book Details Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
