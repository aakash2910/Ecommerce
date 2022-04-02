using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET : admin/pages
        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from page in _context.Pages orderby page.Sorting select page;

            List<Page> pagesList = await pages.ToListAsync();

            return View(pagesList);
        }

        // GET : admin/pages/details/{id?}
        public async Task<IActionResult> Details(int id)
        {
            Page page = await _context.Pages.FirstOrDefaultAsync(x => x.Id == id);
            
            if(page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        // GET : admin/pages/create
        public IActionResult Create()
        {
            return View();
        }

        // POST : admin/pages/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                page.Sorting = 100;

                var slug = await _context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if(slug != null)
                {
                    ModelState.AddModelError("", "Page already exists");
                    return View(page);
                }
                _context.Add(page);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Page Created Successfully";

                return RedirectToAction("Index");
            }
            return View(page);
        }

        // GET : admin/pages/edit/{id?}
        public async Task<IActionResult> Edit(int id)
        {
            Page page = await _context.Pages.FindAsync(id);

            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }


        // POST : admin/pages/edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Id == 1 ? "home" : page.Title.ToLower().Replace(" ", "-");
                
                var slug = await _context.Pages.Where(x => x.Id != page.Id).FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Page already exists");
                    return View(page);
                }
                _context.Update(page);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Page Edited Successfully";

                return RedirectToAction("Index");
            }
            return View(page);
        }

        // GET admin/pages/delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var page = await _context.Pages.FindAsync(id);
            if(page == null)
            {
                TempData["Error"] = "Page does not exists!!";
            }
            else
            {
                _context.Pages.Remove(page);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Page deleted successfully";
            }

            return RedirectToAction("Index");
        }
    }
}
