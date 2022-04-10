using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public CategoriesViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await GetCategoriesAsync();
            return View(categories);
        }

        private Task<List<Category>> GetCategoriesAsync()
        {
            return _context.Categories.ToListAsync();
        }
    }
}
