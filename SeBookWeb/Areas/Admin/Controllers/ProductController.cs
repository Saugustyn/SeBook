using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeBook.DataAccess;
using SeBook.DataAccess.Repository.IRepository;
using SeBook.Models;

namespace SeBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            Product product = new Product();
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = id.ToString()
                });
            IEnumerable<SelectListItem> CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = id.ToString()
                });

            if (id == null || id == 0)
            {
                return View(product);
            }
            else
            {

            }

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //https://www.devcurry.com/2013/01/what-is-antiforgerytoken-and-why-do-i.html
        public IActionResult Upsert(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "CoverType updated successfully";
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
            var coverTypeFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id); // if many records: returns the first record
            //var categorySingle = _db.Categories.SingleOrDefault(u => u.Id == id); //if many records: throws an exception

            if (coverTypeFirst == null)
            {
                return NotFound();
            }
            return View(coverTypeFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //https://www.devcurry.com/2013/01/what-is-antiforgerytoken-and-why-do-i.html
        public IActionResult Delete(CoverType obj)
        {
            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
