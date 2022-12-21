using Microsoft.AspNetCore.Mvc;
using SeBook.DataAccess;
using SeBook.DataAccess.Repository.IRepository;
using SeBook.Models;

namespace SeBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;
        public CategoryController(ICategoryRepository db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.GetAll();
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //https://www.devcurry.com/2013/01/what-is-antiforgerytoken-and-why-do-i.html
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("TempCustomValidation", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            //var category = _db.Categories.Find(id);
            var categoryFirst = _db.GetFirstOrDefault(u=>u.Name == "id"); // if many records: returns the first record
            //var categorySingle = _db.Categories.SingleOrDefault(u => u.Id == id); //if many records: throws an exception

            if(categoryFirst == null)
            {
                return NotFound();
            }
            return View(categoryFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //https://www.devcurry.com/2013/01/what-is-antiforgerytoken-and-why-do-i.html
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("TempCustomValidation", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var category = _db.Find(id);
            var categoryFirst = _db.GetFirstOrDefault(u=>u.Id == id); // if many records: returns the first record
            //var categorySingle = _db.Categories.SingleOrDefault(u => u.Id == id); //if many records: throws an exception

            if (categoryFirst == null)
            {
                return NotFound();
            }
            return View(categoryFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //https://www.devcurry.com/2013/01/what-is-antiforgerytoken-and-why-do-i.html
        public IActionResult Delete(Category obj)
        {
            _db.Remove(obj);
            _db.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
