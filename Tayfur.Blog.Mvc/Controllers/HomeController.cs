using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tayfur.Blog.Service.Abstract;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Mvc.Controllers
{
    /// <summary>
    /// This class manages the user interfaces of the application.
    /// To sign in you need this creds :
    ///         Email = "terkenci@gmail.com",
    ///         Password = "123456",
    /// </summary>
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly ICommentService commentService;
        public HomeController(IArticleService articleService, ICategoryService categoryService,
            ICommentService commentService)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.commentService = commentService;
        }
        public ActionResult Index(int? page)
        {

            //var articles = null; db.Articles.Include(a => a.Category).Include(b=>b.Admin).OrderByDescending(x=>x.CreatedDate).ToPagedList(page ?? 1, 2);
            //    return View(articles);

            var articles = articleService.GetArticlesWithCategoryAndAdmin().ToPagedList(page ?? 1, 2);
            return View(articles);
        }
        //public async Task<ActionResult> GetAllArticles()
        //{
        //        //var articles =db.Articles.Include(a => a.Category).Include(a => a.Admin).OrderByDescending(x => x.CreatedDate);
        //        //return View("Index", await articles.ToListAsync());
        //        return View("Index");
          
        //}
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        // GET: Articles/5
        //[Route("/articles/{id?}")]
        public ActionResult ArticleDetails(Guid? id)
        {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

            ArticleCategoryAdminViewModel article = articleService.GetArtWithCatAdmWithId(id??default(Guid));

            if (article == null)
            {
                return HttpNotFound();
            }

            //return View("ArticleDetails", article);
            return View(article);
            }
        }
    }
