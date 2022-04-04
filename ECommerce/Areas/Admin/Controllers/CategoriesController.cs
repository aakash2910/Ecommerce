using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET : /admin/categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET : /admin/categories/create
        public IActionResult Create()
        {
            return View();
        }

        // POST : /admin/categories/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {   
                category.Slug = category.Name.ToLower().Replace(" ", "-");

                var slug = await _context.Categories.FirstOrDefaultAsync(x => x.Slug == category.Slug);

                if (slug != null)
                {
                    ModelState.AddModelError("", "Category already exists");
                    return View(category);
                }

                _context.Add(category);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Category Created Successfully";

                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET : /admin/categories/edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            Category category = await _context.Categories.FindAsync(id);

            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST : admin/categories/edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                category.Slug = category.Name.ToLower().Replace(" ", "-");

                var slug = await _context.Categories.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Slug == category.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Category already exists");
                    return View(category);
                }
                _context.Update(category);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Category Edited Successfully";

                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET admin/categories/delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                TempData["Error"] = "Category does not exists!!";
            }
            else
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Category deleted successfully";
            }

            return RedirectToAction("Index");
        }
    }
}
