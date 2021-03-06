using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public ProductsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this._context = context;
            this._environment = environment; 
        }

        // GET : /admin/products
        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 5;
            var products = _context.Products.Include(x => x.Category).Skip((p-1) * pageSize).Take(pageSize);

            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Products.Count() / pageSize);

            return View(await products.ToListAsync());
        }

        // GET : /admin/products/create
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories,"Id", "Name");
            return View();
        }

        // POST : /admin/products/create
        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            if (ModelState.IsValid)
            {
                product.Slug = product.Name.ToLower().Replace(" ", "-");

                var slug = await _context.Products.FirstOrDefaultAsync(x => x.Slug == product.Slug);
                
                if (slug != null)
                {
                    ModelState.AddModelError("", "Product already exists");
                    return View(product);
                }

                string imageName = "NoImage.jpg";
                if (product.ImageUpload != null)
                {
                    string uploadDir = Path.Combine(_environment.WebRootPath, "Images/Products");
                    imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                }

                product.Image = imageName;

                _context.Add(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Product has been added";

                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET : admin/products/details/{id?}
        public async Task<IActionResult> Details(int id)
        {
            Product product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        // GET : admin/products/edit/{id?}
        public async Task<IActionResult> Edit(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);

            return View(product);
        }


        // POST : /admin/products/edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            
            if (ModelState.IsValid)
            {
                product.Slug = product.Name.ToLower().Replace(" ", "-");

                var slug = await _context.Products.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Slug == product.Slug);

                if (slug != null)
                {
                    ModelState.AddModelError("", "Product already exists");
                    return View(product);
                }

                if(product.ImageUpload != null)
                {
                    string uploadDir = Path.Combine(_environment.WebRootPath, "Images/Products");

                    if(!string.Equals(product.Image, "NoImage.jpg"))
                    {
                        string oldImagePath = Path.Combine(uploadDir, product.Image);

                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    product.Image = imageName;
                }

                _context.Update(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Product has been Edited";

                return RedirectToAction("Index");
            }
            return View(product);
        }


        // GET admin/products/delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                TempData["Error"] = "Product does not exists!!";
            }
            else
            {
                if (!string.Equals(product.Image, "NoImage.jpg"))
                {
                    string uploadDir = Path.Combine(_environment.WebRootPath, "Images/Products");

                    string oldImagePath = Path.Combine(uploadDir, product.Image);

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Product deleted successfully";
            }

            return RedirectToAction("Index");
        }
    }
}
