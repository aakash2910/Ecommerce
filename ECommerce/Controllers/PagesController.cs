using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class PagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET : /
        public async Task<IActionResult> Page(string slug)
        {
            if(slug == null)
            {
                return View(await _context.Pages.Where(x => x.Slug == "home").FirstOrDefaultAsync());
            }

            Page page = await _context.Pages.Where(x => x.Slug == slug).FirstOrDefaultAsync();

            if(page == null)
            {
                return NotFound();
            }

            return View(page);
        }
    }
}
