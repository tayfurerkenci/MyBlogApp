using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tayfur.Blog.Service.Abstract;
using Tayfur.Blog.Service.ViewModels;
using Tayfur.Blog.Service.ValidationRules.FluentValidation;
using FluentValidation.Results;

namespace Tayfur.Blog.Mvc.Controllers
{
    /// <summary>
    /// This class manages the categories of the application.
    /// </summary>
    [Authorize]
    public class CategoryController : Controller
    {
        //private BlogContext db = new BlogContext();

        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index()
        {
            //return View(await db.Categories.Include(a=>a.Admin).ToListAsync());
            return View(categoryService.GetCategories());
        }

        // GET: Category/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryViewModel category = categoryService.GetCategory(id ?? default(Guid));
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName,Description")] CategoryViewModel category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);

            if (results.IsValid)
            {
                category.Id = Guid.NewGuid();
                category.CreatedDate = DateTime.Now;
                category.CreatedBy = Guid.Parse(User.Identity.Name);
                category.IsDeleted = false;

                bool result = categoryService.AddCategory(category);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                }
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryViewModel category = categoryService.GetCategory(id ?? default(Guid));
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName,Description,CreatedDate,ModifiedBy,ModifiedDate,CreatedBy,IsDeleted")] CategoryViewModel category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                category.ModifiedDate = DateTime.Now;
                if (Session["UserId"] != null)
                {
                    category.ModifiedBy = Guid.Parse(User.Identity.Name);
                }

                bool result = categoryService.UpdateCategory(category);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                }
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CategoryViewModel category = categoryService.GetCategory(id??default(Guid));
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CategoryViewModel category = categoryService.GetCategory(id);
            categoryService.DeleteCategory(category);
            return RedirectToAction("Index");
        }
    }
}
