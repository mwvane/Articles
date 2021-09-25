using articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace articles.Controllers
{
    public class ArticlesController : Controller
    {
        protected UserDbContext _context = new UserDbContext();
        // GET: Articles
        public ActionResult Index(string message = null)
        {
            ViewBag.Message = message;
            var articles = _context.Articles.ToList();
            return View(articles);
        }
        public ActionResult Create()
        {

            return View(new Article());
        }

        public ActionResult Update(int id)
        {
            var article = _context.Articles
                .Where(e => e.Id == id)
                .FirstOrDefault();
            if(article != null)
            {
                return View("Create",article);
            }
            throw new Exception("Such article does not exist");
        }
        [ValidateAntiForgeryToken]
        public RedirectResult CreateOrUpdate([Bind(Include = "Title,Description,Id")] Article article)
        {
            if (ModelState.IsValid)
            {
                if (article.Id > 0)
                {
                    var exitingArticle = _context.Articles.Where(m => m.Id == article.Id).FirstOrDefault();
                    if (exitingArticle != null)
                    {
                        exitingArticle.Title = article.Title;
                        exitingArticle.Description = article.Description;
                        _context.SaveChanges();
                    }
                }
                _context.Articles.Add(article);
                _context.SaveChanges();
            }
            return Redirect(Url.Action("Index"));
        }

        public RedirectToRouteResult Delete(int id)
        {
            var article = _context.Articles
                .Where(a=>a.Id == id)
                .FirstOrDefault();
            if(article != null)
            {
                _context.Articles.Remove(article);
                _context.SaveChanges();
                return RedirectToAction("Index",new { message = "Article successfully deleted" });
            }
            throw new Exception("Such article does not exist");
        }

    }
}