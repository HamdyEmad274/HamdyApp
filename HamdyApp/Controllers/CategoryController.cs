using HamdyApp.Data;
using HamdyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HamdyApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HamdyAppDbContext db;

        public CategoryController(HamdyAppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<Category> categoriesList = db.Categories.ToList();
            return View(categoriesList);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name != null && category.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", $"Name Cannot be {category.Name}");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                TempData["Success"] = $"Category {category.Name} Created Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = db.Categories.FirstOrDefault(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category.Name != null && category.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", $"Name Cannot be {category.Name}");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Update(category);
                db.SaveChanges();
                TempData["Success"] = $"Category {category.Name} Updated Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = db.Categories.FirstOrDefault(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? categoryFromDb = db.Categories.FirstOrDefault(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            db.Categories.Remove(categoryFromDb);
            db.SaveChanges();
            TempData["Success"] = $"Category {categoryFromDb.Name} Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}
