using FluentValidation.Results;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tayfur.Blog.Service.Abstract;
using Tayfur.Blog.Service.ValidationRules.FluentValidation;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Mvc.Controllers
{
    /// <summary>
    /// This class manages the articles of the application.
    /// </summary>
    [Authorize]
    public class ArticleController : Controller
    {
        //private readonly BlogContext db = new BlogContext();

        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        public ArticleController(IArticleService articleService, ICategoryService categoryService)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
        }
        // GET: Article
        public ActionResult Index()
        {
            //var articles = db.Articles.Include(a => a.Category).Include(a=>a.Admin).OrderByDescending(x=>x.CreatedDate).Take(10);
            //return View(await articles.ToListAsync());
            return View(articleService.GetArticlesWithCategoryAndAdmin());
        }
   

        // GET: Article/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleCategoryAdminViewModel article = articleService.GetArtWithCatAdmWithId(id ?? default(Guid));
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categoryService.GetCategories(), "Id", "CategoryName");
            return View();
        }

        // POST: Article/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryId,Title,Context")] ArticleViewModel article)
        {
            ArticleValidator articleValidator = new ArticleValidator();
            ValidationResult results = articleValidator.Validate(article);
            if (results.IsValid)
            {
                article.Id = Guid.NewGuid();
                article.CreatedDate = DateTime.Now;
                article.CreatedBy = Guid.Parse(User.Identity.Name);
                article.IsDeleted = false;

                bool result = articleService.AddArticle(article);

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
            ViewBag.CategoryId = new SelectList(categoryService.GetCategories(), "Id", "CategoryName");
            return View(article);
        }

        // GET: Article/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleViewModel article = articleService.GetArticle(id??default(Guid));
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(categoryService.GetCategories(), "Id", "CategoryName", article.CategoryId);
            return View(article);
        }

        // POST: Article/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryId,Title,Context,CreatedDate,ModifiedBy,ModifiedDate,CreatedBy,IsDeleted")] ArticleViewModel article)
        {
            ArticleValidator articleValidator = new ArticleValidator();
            ValidationResult results = articleValidator.Validate(article);
            if (results.IsValid)
            {
                article.ModifiedDate = DateTime.Now;
                if (Session["UserId"] != null)
                {
                    article.ModifiedBy = Guid.Parse(User.Identity.Name);
                }

                bool result = articleService.UpdateArticle(article);
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
            ViewBag.CategoryId = new SelectList(categoryService.GetCategories(), "Id", "CategoryName", article.CategoryId);
            return View(article);
        }

        // GET: Article/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleCategoryAdminViewModel article = articleService.GetArtWithCatAdmWithId(id ?? default(Guid));
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ArticleViewModel article = articleService.GetArticle(id);
            articleService.DeleteArticle(article);
            return RedirectToAction("Index");
        }
    }
}
