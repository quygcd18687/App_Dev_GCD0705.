using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TTMS.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;
        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View(_context.Categories.ToList());
        }


		//Create category
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Category category)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var newCategory = new Category()
			{
				Name = category.Name,
				Description = category.Description
			};

			_context.Categories.Add(newCategory);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == id);

			if (categoryInDb == null) return HttpNotFound();

			return View(categoryInDb);
		}

		[HttpPost]
		public ActionResult Edit(Category category)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var InforCategoryInDb = _context.Categories.SingleOrDefault(t => t.Id == category.Id);

			if (InforCategoryInDb == null) return HttpNotFound();

			var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == category.Id);

			categoryInDb.Name = category.Name;
			categoryInDb.Description = category.Description;

			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)

		{

			var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == id);

			if (categoryInDb == null) return HttpNotFound();

			_context.Categories.Remove(categoryInDb);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}