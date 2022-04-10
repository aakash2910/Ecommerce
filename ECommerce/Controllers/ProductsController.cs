using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET : /products
        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 5;
            var products = _context.Products.Skip((p - 1) * pageSize).Take(pageSize);

            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Products.Count() / pageSize);

            return View(await products.ToListAsync());
        }

        // GET : /products/category
        public async Task<IActionResult> ProductsByCategory(string categorySlug, int p = 1)
        {
            Category category = await _context.Categories.Where(x => x.Slug == categorySlug).FirstOrDefaultAsync();

            if(category == null)
            {
                return RedirectToAction("Index");
            }

            int pageSize = 5;
            var products = _context.Products.
                                    Where(x => x.CategoryId == category.Id)
                                    .Skip((p - 1) * pageSize).Take(pageSize);

            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Products.Where(x => x.CategoryId == category.Id).Count() / pageSize);
            ViewBag.CategoryName = category.Name;
            ViewBag.CategorySlug = categorySlug;

            return View(await products.ToListAsync());
        }
    }
}
