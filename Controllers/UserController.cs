using articles.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace articles.Controllers
{
    public class UserController : Controller
    {
        protected UserDbContext _context = new UserDbContext();
        // GET: User
        public ActionResult Leo()
        {
            var user = _context.Users.Where(x => x.Id == 1).FirstOrDefault();
            _context.Users.Remove(user);
            _context.SaveChanges();

            return View(user);
        }


        public void CreateUser()
        {
            User user = new User()
            {
                Name = "leo",
                Email = "bzishvili@gmail.com",
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public ActionResult GetUsers()
        {
            var flag = true;
            ViewBag.flag = flag;

            var users = _context.Users.ToList();
            return View(users);
        }
    }
}