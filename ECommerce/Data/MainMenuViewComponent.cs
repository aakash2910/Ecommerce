using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class MainMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public MainMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pages = await GetPagesAsync();
            return View(pages);  
        }

        private Task<List<Page>> GetPagesAsync()
        {
            return _context.Pages.ToListAsync();
        }
    }
}
