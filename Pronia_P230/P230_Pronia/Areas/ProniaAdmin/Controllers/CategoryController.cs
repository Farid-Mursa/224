using Microsoft.AspNetCore.Mvc;
using P230_Pronia.DAL;
using P230_Pronia.Entities;

namespace P230_Pronia.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class CategoryController : Controller
    {
        private readonly ProniaDbContext _context;

        public CategoryController(ProniaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Categories> categories = _context.Categories.AsEnumerable();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Creates(Categories newCategory)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Name","You cannot duplicate category name");
                return View();
            }
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            Console.WriteLine("Hello World");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            if (id == 0) return NotFound();
            Categories category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category is null) return NotFound();
            return View(category);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, Categories edited)
        {
            if (id != edited.Id) return BadRequest();
            Categories category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category is null) return NotFound();
            bool duplicate = _context.Categories.Any(c => c.Name == edited.Name);
            if(duplicate)
            {
                ModelState.AddModelError("","You cannot duplicate category name");
                return View();
            }
            category.Name = edited.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
